using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class GranadeGun : Weapon
{
    [Header("Grenade stats")]
    [SerializeField] private float _baseForce = 0.5f;
    [SerializeField] private float _maxForce = 3f;
    [SerializeField] private float _angleShoot = 45f;

    private IMovable _owner;
    private PlayerInputActions _inputActions;
    private GranadeBullet _bullet;
    private float _secRateForceGrowth;
    private float _force;

    [Inject]
    public void Construct(PlayerInputActions inputActions, IMovable owner)
    {
        _inputActions = inputActions;
        _owner = owner;
    }

    protected override void Awake()
    {
        base.Awake();
        _bullet = BuildGranade();
        _secRateForceGrowth = (_maxForce - _baseForce) * 0.5f;
    }

    private void OnEnable()
    {
        _force = _baseForce;
        _inputActions.Player.Shoot.canceled += DoShot;
    }

    private void OnDisable()
    {
        _inputActions.Player.Shoot.canceled -= DoShot;
    }

    protected override ShootResult ShootImplementation(RaycastHit _)
    {
        _force += _secRateForceGrowth * Time.deltaTime;
        return ShootResult.Success;
    }

    protected override void ReloadImplementation()
    {
        base.ReloadImplementation();
        _bullet = BuildGranade();
    }

    private void DoShot(InputAction.CallbackContext _)
    {
        if (_bullet != null)
        {
            DecrementAmmoAndRecordTime();

            Vector3 shootDir = CalculateShootDir();
            _bullet.transform.SetParent(_bulletFactory.BulletParent);
            _bullet.Activate(_damage, Mathf.Min(_force, _maxForce), shootDir, _owner.GetVelocity());

            _bullet = null;
            Reload();
        }
        _force = _baseForce;
    }

    private Vector3 CalculateShootDir()
    {
        Vector3 locShootDir = transform.InverseTransformDirection(_spawnPoint.forward);
        float gunAngle = Mathf.DeltaAngle(0, transform.localEulerAngles.x);
        locShootDir = Quaternion.Euler(_angleShoot - gunAngle, 0f, 0f) * locShootDir;
        return transform.TransformDirection(locShootDir);
    }

    private GranadeBullet BuildGranade()
    {
        return _bulletFactory.BuildGranade(_spawnPoint);
    }
}
