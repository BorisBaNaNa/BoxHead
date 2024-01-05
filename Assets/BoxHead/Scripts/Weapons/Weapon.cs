using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public abstract class Weapon : MonoBehaviour
{
    public enum ShootResult
    {
        Success,
        OutOfAmmo,
        CooldownInProgress,
        Reloading,
        Fail
    }

    [Header("Components")]
    [SerializeField] protected Transform _spawnPoint;

    [Header("Base stats")]
    [SerializeField] protected AudioClip _shootClip;
    [SerializeField] protected int _maxAmmoReserve = 90;
    [SerializeField] protected int _maxAmmoMagazine = 10;
    [SerializeField] protected float _shootDelay = 0.5f;
    [SerializeField] protected float _damage = 5f;
    [SerializeField] protected float _attackDistance = 10f;
    [SerializeField] protected float _reloadDuration = 1f;

    protected CharacterShooting _characterShooting;
    protected int _curAmmoCountInReseve;
    protected int _curAmmoCountInMagazine;
    protected float _lastShootingTime;
    protected bool _reloading;

    protected virtual void Awake()
    {
        _curAmmoCountInReseve = _maxAmmoReserve;
        _curAmmoCountInMagazine = _maxAmmoMagazine;
    }

    public void Init(CharacterShooting shootController)
    {
        _characterShooting = shootController;
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject?.SetActive(false);
    }

    public virtual ShootResult Reload()
    {
        if (_reloading)
            return ShootResult.Reloading;
        if (_curAmmoCountInReseve == 0)
            return ShootResult.OutOfAmmo;

        _characterShooting.StartCoroutine(ReloadImitateRoutine());
        return ShootResult.Success;
    }

    public virtual void StartShoot(InputAction.CallbackContext context) { }

    public virtual void StopShoot(InputAction.CallbackContext context) { }

    public virtual void StartAbility(InputAction.CallbackContext context) { }

    public virtual void StopAbility(InputAction.CallbackContext context) { }

    public virtual ShootResult Shoot(RaycastHit worldHit)
    {
        if (_reloading)
            return ShootResult.Reloading;

        if (_curAmmoCountInMagazine == 0)
            return ShootResult.OutOfAmmo;

        if (Time.time - _lastShootingTime < _shootDelay)
            return ShootResult.CooldownInProgress;

        return ShootImplementation(worldHit);
    }

    protected virtual void ReloadImplementation()
    {
        int needAmmoCount = _maxAmmoMagazine - _curAmmoCountInMagazine;
        int takedAmmo = Mathf.Min(needAmmoCount, _curAmmoCountInReseve);

        _curAmmoCountInReseve -= takedAmmo;
        _curAmmoCountInMagazine += takedAmmo;
    }

    protected abstract ShootResult ShootImplementation(RaycastHit worldHit);

    protected void DecrementAmmoAndRecordTime()
    {
        _lastShootingTime = Time.time;
        _curAmmoCountInMagazine--;
    }

    private IEnumerator ReloadImitateRoutine()
    {
        _reloading = true;
        if (_reloadDuration > 0)
            yield return new WaitForSeconds(_reloadDuration);

        ReloadImplementation();
        _reloading = false;
        Debug.Log($"{name} Reloaded!");
    }
}
