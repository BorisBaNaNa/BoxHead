using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Pistol : Weapon
{
    private LineBulletFactory _bulletFactory;

    [Inject]
    public void Construct(LineBulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        DecrementAmmoAndRecordTime();

        Vector3 shootDir = (worldHit.point - transform.position).normalized;
        _bulletFactory.Build(_spawnPoint.position, shootDir, _damage, _attackDistance);
        return ShootResult.Success;
    }
}


