using System;
using UnityEngine;
using Zenject;

public class BaseMineFactory : BulletFactoryBase
{
    private readonly BaseMine _baseMinePrefab;

    public BaseMineFactory(DiContainer container, Transform bulletParent, BaseMine baseMinePrefab) : base(container, bulletParent)
    {
        _baseMinePrefab = baseMinePrefab;
    }

    public BaseMine Build(Vector3 position, float damage)
    {
        var bullet = _container.InstantiatePrefabForComponent<BaseMine>(_baseMinePrefab);
        bullet.transform.SetParent(_bulletsParent);
        bullet.transform.position = position;
        bullet.Initialize(damage);
        return bullet;
    }
}
