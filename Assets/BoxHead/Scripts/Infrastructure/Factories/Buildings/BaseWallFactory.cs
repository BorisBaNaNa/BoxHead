using UnityEngine;
using Zenject;

public class BaseWallFactory : BulletFactoryBase
{
    private readonly BaseWall _baseWallPrefab;

    public BaseWallFactory(DiContainer container, Transform bulletParent, BaseWall baseWallPrefab) : base(container, bulletParent)
    {
        _baseWallPrefab = baseWallPrefab;
    }

    public BaseWall Build(Vector3 position)
    {
        var wall = _container.InstantiatePrefabForComponent<BaseWall>(_baseWallPrefab);
        wall.transform.SetParent(_bulletsParent);
        wall.transform.position = position;
        return wall;
    }
}
