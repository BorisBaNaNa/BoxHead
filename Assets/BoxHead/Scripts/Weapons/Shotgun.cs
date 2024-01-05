using UnityEngine;
using Zenject;

public class Shotgun : Weapon
{
    [Space, Header("Unique stats")]
    [SerializeField] private int _bulletCount = 5;
    [SerializeField] private int _maxSpreadAngle = 15;

    private LineBulletFactory _bulletFactory;

    [Inject]
    public void Construct(LineBulletFactory bulletFactory)
    {
        _bulletFactory = bulletFactory;
    }

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        DecrementAmmoAndRecordTime();

        Vector3 baseShootDir = (worldHit.point - transform.position).normalized;
        for (int i = 0; i < _bulletCount; i++)
            _bulletFactory.Build(_spawnPoint.position, GetSpreadDir(baseShootDir), _damage, _attackDistance);

        return ShootResult.Success;
    }

    private Vector3 GetSpreadDir(Vector3 baseDir)
    {
        float randomAngle = Random.Range(-_maxSpreadAngle, _maxSpreadAngle);
        Quaternion randomRotation = Quaternion.Euler(0, 0, randomAngle);
        return randomRotation * baseDir;
    }
}


