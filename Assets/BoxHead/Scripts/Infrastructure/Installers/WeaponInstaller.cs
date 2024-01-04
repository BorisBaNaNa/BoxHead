using UnityEngine;
using Zenject;

public class WeaponInstaller : MonoInstaller
{
    [SerializeField] private Transform _bulletParent;
    [SerializeField] private LineBullet _lineBulletPrefab;
    [SerializeField] private FlyingBullet _flyBulletPrefab;
    [SerializeField] private GranadeBullet _granadeBulletPrefab;
    [SerializeField] private BaseMine _baseMinePrefab;

    public override void InstallBindings()
    {
        Container
            .Bind<BulletFactory>()
            .AsSingle()
            .WithArguments(_bulletParent, _lineBulletPrefab, _flyBulletPrefab, _granadeBulletPrefab, _baseMinePrefab);

        Container.Bind<Exploder>()
            .AsSingle();
    }
}
