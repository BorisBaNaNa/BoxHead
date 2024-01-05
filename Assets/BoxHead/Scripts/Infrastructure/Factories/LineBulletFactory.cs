using UnityEngine;
using Zenject;

public class LineBulletFactory : BulletFactoryBase
{
    private readonly LineBullet _lineBulletPrefab;

    public LineBulletFactory(DiContainer container, Transform bulletParent, LineBullet lineBulletPrefab) : base (container, bulletParent)
    {
        _lineBulletPrefab = lineBulletPrefab;
    }

    public LineBullet Build(Vector3 pos, Vector3 dir, float damage, float attackDistance)
    {
        var bullet = _container.InstantiatePrefabForComponent<LineBullet>(_lineBulletPrefab, pos, Quaternion.LookRotation(dir), _bulletsParent);
        bullet.Construct(damage, attackDistance, dir);
        return bullet;
    }
}
