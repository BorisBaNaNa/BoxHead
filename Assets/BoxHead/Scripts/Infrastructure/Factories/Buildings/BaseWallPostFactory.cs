using UnityEngine;
using Zenject;

public class BaseWallPostFactory : BulletFactoryBase
{
    private readonly BaseWallPost _baseWallPostPrefab;

    public BaseWallPostFactory(DiContainer container, Transform bulletParent, BaseWallPost baseWallPostPrefab) : base(container, bulletParent)
    {
        _baseWallPostPrefab = baseWallPostPrefab;
    }

    public BaseWallPost Build(Vector3 position)
    {
        var wall = _container.InstantiatePrefabForComponent<BaseWallPost>(_baseWallPostPrefab);
        wall.transform.SetParent(_bulletsParent);
        wall.transform.position = position;
        wall.CheckAndBuildWalls();
        return wall;
    }
}
