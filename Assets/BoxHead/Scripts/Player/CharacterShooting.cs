using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(CharacterLooking))]
public class CharacterShooting : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterLooking _characterLooking;

    [Header("Stats")]
    [SerializeField] private bool _autoReload = true;
    [SerializeField] private float _baseShootDelay = 0.5f;
    [SerializeField] private float _pitchLimitX = 45f;
    [SerializeField] private float _pitchLimitY = 85f;

    private PlayerInputActions _inputActions;
    private Weapon _curWeapon;
    private float _lastShootTime;

    [Inject]
    public void Construct(PlayerInputActions inputActions)
    {
        _inputActions = inputActions;
    }

    private void Awake()
    {
        InitInput();
    }

    private void OnDestroy()
    {
        DisableInput();
    }

    private void OnValidate()
    {
        if (_characterLooking == null)
            _characterLooking = GetComponent<CharacterLooking>();
    }

    private void Update()
    {
        RaycastHit worldHit = _characterLooking.LookToMousePos();
        bool rotationWasClamped = RotateWeaponToTarget(worldHit);
        TryShoot(worldHit, rotationWasClamped);
    }

    public void SetWeapon(Weapon weapon)
    {
        _curWeapon?.Hide();
        _curWeapon = weapon;
        _curWeapon?.Show();
    }

    private void InitInput()
    {
        _inputActions.Player.Shoot.Enable();
        _inputActions.Player.Shoot.started += ShootStarted;
        _inputActions.Player.Shoot.canceled += ShootStoped;

        _inputActions.Player.WeaponAbility.Enable();
        _inputActions.Player.WeaponAbility.started += WeaponAbilityStarted;
        _inputActions.Player.WeaponAbility.canceled += WeaponAbilityStoped;
    }

    private void DisableInput()
    {
        _inputActions.Player.Shoot.Disable();
        _inputActions.Player.Shoot.started -= ShootStarted;
        _inputActions.Player.Shoot.canceled -= ShootStoped;

        _inputActions.Player.WeaponAbility.Disable();
        _inputActions.Player.WeaponAbility.started -= WeaponAbilityStarted;
        _inputActions.Player.WeaponAbility.canceled -= WeaponAbilityStoped;
    }

    private bool RotateWeaponToTarget(RaycastHit worldHit)
    {
        Vector3 playerLocHitDir = transform.InverseTransformDirection(worldHit.point - _curWeapon.transform.position);
        var targetRotation = Quaternion.LookRotation(playerLocHitDir.normalized).eulerAngles;

        targetRotation.x = Mathf.DeltaAngle(0, targetRotation.x);
        targetRotation.y = Mathf.DeltaAngle(0, targetRotation.y);

        float clampedRotX = Mathf.Clamp(targetRotation.x, -_pitchLimitX, _pitchLimitX);
        float clampedRotY = Mathf.Clamp(targetRotation.y, -_pitchLimitY, _pitchLimitY);

        _curWeapon.transform.localEulerAngles = new (clampedRotX, clampedRotY, targetRotation.z);

        return !Mathf.Approximately(clampedRotX, targetRotation.x) || !Mathf.Approximately(clampedRotY, targetRotation.y);
    }

    private void WeaponAbilityStarted(InputAction.CallbackContext context) => _curWeapon.StartAbility(context);

    private void WeaponAbilityStoped(InputAction.CallbackContext context) => _curWeapon.StopAbility(context);

    private void ShootStarted(InputAction.CallbackContext context) => _curWeapon.StartShoot(context);

    private void ShootStoped(InputAction.CallbackContext context) => _curWeapon.StopShoot(context);

    private void TryShoot(RaycastHit worldHit, bool rotationWasClamped)
    {
        if (!_inputActions.Player.Shoot.IsPressed())
            return;

        if (_curWeapon == null)
        {
            BaseShotAction();
            return;
        }

        if (rotationWasClamped)
            worldHit = GetAimPoint();
        HandleShotResult(_curWeapon.Shoot(worldHit));
    }

    private RaycastHit GetAimPoint()
    {
        Ray weaponRay = new Ray(_curWeapon.transform.position, _curWeapon.transform.forward);
        Physics.Raycast(weaponRay, out RaycastHit hitInfo, 1000, ~_characterLooking.IgnoredLayerMask);

        return hitInfo;
    }

    private bool TryReload()
    {
        if (_curWeapon == null)
            return false;

        var reloadResult = _curWeapon.Reload();

        switch (reloadResult)
        {
            case Weapon.ShootResult.OutOfAmmo:
                Debug.Log("Ammo rezerve is empty!");
                break;
            case Weapon.ShootResult.Reloading:
                break;
        }

        return reloadResult == Weapon.ShootResult.Success;
    }

    private void HandleShotResult(Weapon.ShootResult shootResult)
    {
        switch (shootResult)
        {
            case Weapon.ShootResult.OutOfAmmo:
                NoAmmoAction();
                break;
            case Weapon.ShootResult.Reloading:
                break;
            case Weapon.ShootResult.Success:
                break;
            case Weapon.ShootResult.CooldownInProgress:
                break;
            case Weapon.ShootResult.Fail:
                break;
        }
    }

    private void BaseShotAction()
    {
        float curShootDelay = Time.time - _lastShootTime;
        if (curShootDelay >= _baseShootDelay)
        {
            Debug.Log("Оружие не выбрано!");
            _lastShootTime = Time.time;
        }
    }

    private void NoAmmoAction()
    {
        if (_autoReload)
        {
            if (TryReload())
                Debug.Log($"{_curWeapon.name} Reloading...");
        }
        else
            Debug.Log("No Ammo");
    }
}
