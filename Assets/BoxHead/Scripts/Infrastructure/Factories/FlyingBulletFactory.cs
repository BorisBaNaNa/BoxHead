using UnityEngine;
using Zenject;

public class FlyingBulletFactory : BulletFactoryBase
{
    private readonly FlyingBullet _flyBulletPrefab;

    public FlyingBulletFactory(DiContainer container, Transform bulletParent, FlyingBullet flyBulletPrefab) : base(container, bulletParent)
    {
        _flyBulletPrefab = flyBulletPrefab;
    }

    public FlyingBullet Build(Transform spawnPoint)
    {
        var bullet = _container.InstantiatePrefabForComponent<FlyingBullet>(_flyBulletPrefab);
        bullet.transform.SetParent(spawnPoint, false);
        bullet.transform.localPosition = Vector3.zero;
        return bullet;
    }
}
