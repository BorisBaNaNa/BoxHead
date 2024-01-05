using UnityEngine;
using Zenject;

public class DistanceBombFactory : BulletFactoryBase
{
    private readonly DistanceBomb _distanceBombPrefab;

    public DistanceBombFactory(DiContainer container, Transform bulletParent, DistanceBomb distanceBombPrefab) : base(container, bulletParent)
    {
        _distanceBombPrefab = distanceBombPrefab;
    }

    public DistanceBomb Build(Vector3 position, float damage)
    {
        var bomb = _container.InstantiatePrefabForComponent<DistanceBomb>(_distanceBombPrefab);
        bomb.transform.SetParent(_bulletsParent);
        bomb.transform.position = position;
        bomb.Initialize(damage);
        return bomb;
    }
}