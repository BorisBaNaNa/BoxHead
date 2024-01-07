using System;
using UnityEngine;
using Zenject;

public class WeaponInstaller : MonoInstaller
{
    [Header("Bullets")]
    [SerializeField] private Transform _bulletsParent;
    [SerializeField] private LineBullet _lineBulletPrefab;
    [SerializeField] private FlyingBullet _flyBulletPrefab;
    [SerializeField] private GranadeBullet _granadeBulletPrefab;

    [Header("Devices")]
    [SerializeField] private Transform _devicesParent;
    [SerializeField] private BaseMine _baseMinePrefab;
    [SerializeField] private DistanceBomb _distanceBombPrefab;

    [Header("Buildings")]
    [SerializeField] private Transform _buildingsParent;
    [SerializeField] private Barrel _barrelPrefab;
    [SerializeField] private BaseWallPost _baseWallPostPrefab;
    [SerializeField] private BaseWall _baseWallPrefab;

    public override void InstallBindings()
    {
        InstallBulletFactories();
        InstallDevices();
        InstallBuildings();

        Container
            .Bind<Exploder>()
            .AsSingle();
    }

    private void InstallBulletFactories()
    {
        Container
            .Bind<LineBulletFactory>()
            .AsSingle()
            .WithArguments(_bulletsParent, _lineBulletPrefab);

        Container
            .Bind<FlyingBulletFactory>()
            .AsSingle()
            .WithArguments(_bulletsParent, _flyBulletPrefab);

        Container
            .Bind<GranadeBulletFactory>()
            .AsSingle()
            .WithArguments(_bulletsParent, _granadeBulletPrefab);
    }

    private void InstallDevices()
    {
        Container
            .Bind<BaseMineFactory>()
            .AsSingle()
            .WithArguments(_devicesParent, _baseMinePrefab);

        Container
            .Bind<DistanceBombFactory>()
            .AsSingle()
            .WithArguments(_devicesParent, _distanceBombPrefab);
    }

    private void InstallBuildings()
    {
        Container
            .Bind<BarrelFactory>()
            .AsSingle()
            .WithArguments(_buildingsParent, _barrelPrefab);

        Container
            .Bind<BaseWallPostFactory>()
            .AsSingle()
            .WithArguments(_buildingsParent, _baseWallPostPrefab);

        Container
            .Bind<BaseWallFactory>()
            .AsSingle()
            .WithArguments(_buildingsParent, _baseWallPrefab);
    }

}
