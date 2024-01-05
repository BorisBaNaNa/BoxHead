using System.Collections;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class RPG7 : Weapon
{
    private FlyingBullet _bullet;
    private FlyingBulletFactory _bulletFactory;

    [Inject]
    public void Construct(FlyingBulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    protected override void Awake()
    {
        base.Awake();
        _bullet = BuildRoket();
    }

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        DecrementAmmoAndRecordTime();

        Vector3 shootDir = (worldHit.point - transform.position).normalized;
        _bullet.transform.SetParent(_bulletFactory.BulletsParent);
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
        return _bulletFactory.Build(_spawnPoint);
    }
}
