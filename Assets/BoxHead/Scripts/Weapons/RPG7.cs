using System.Collections;
using UnityEngine;
using Zenject.SpaceFighter;

public class RPG7 : Weapon
{
    private FlyingBullet _bullet;

    protected override void Awake()
    {
        base.Awake();
        _bullet = BuildRoket();
    }

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        DecrementAmmoAndRecordTime();

        Vector3 shootDir = (worldHit.point - transform.position).normalized;
        _bullet.transform.SetParent(_bulletFactory.BulletParent);
        _bullet.Activate(_damage, shootDir);
        _bullet = null;

        return ShootResult.Success;
    }

    protected override void ReloadImplementation()
    {
        base.ReloadImplementation();
        _bullet = BuildRoket();
    }

    private FlyingBullet BuildRoket()
    {
        return _bulletFactory.BuildFlyType(_spawnPoint);
    }
}
