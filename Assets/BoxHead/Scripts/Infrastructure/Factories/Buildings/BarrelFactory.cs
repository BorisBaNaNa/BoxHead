using UnityEngine;
using Zenject;

public class BarrelFactory : BulletFactoryBase
{
    private readonly Barrel _barrelPrefab;

    public BarrelFactory(DiContainer container, Transform bulletParent, Barrel barrelPrefab) : base(container, bulletParent)
    {
        _barrelPrefab = barrelPrefab;
    }

    public Barrel Build(Vector3 position, float damage)
    {
        var barrel = _container.InstantiatePrefabForComponent<Barrel>(_barrelPrefab);
        barrel.transform.SetParent(_bulletsParent);
        barrel.transform.position = position;
        barrel.Initialize(damage);
        return barrel;
    }
}
