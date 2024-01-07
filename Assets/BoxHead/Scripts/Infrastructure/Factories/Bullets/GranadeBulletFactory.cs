using UnityEngine;
using Zenject;

public class GranadeBulletFactory : BulletFactoryBase
{
    private readonly GranadeBullet _granadeBulletPrefab;

    public GranadeBulletFactory(DiContainer container, Transform bulletParent, GranadeBullet granadeBulletPrefab) : base(container, bulletParent)
    {
        _granadeBulletPrefab = granadeBulletPrefab;
    }

    public GranadeBullet Build(Transform spawnPoint)
    {
        var bullet = _container.InstantiatePrefabForComponent<GranadeBullet>(_granadeBulletPrefab);
        bullet.transform.SetParent(spawnPoint, false);
        bullet.transform.localPosition = Vector3.zero;
        return bullet;
    }
}
