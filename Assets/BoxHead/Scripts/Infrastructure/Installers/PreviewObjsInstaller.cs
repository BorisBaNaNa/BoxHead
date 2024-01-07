using UnityEngine;
using Zenject;

public class PreviewObjsInstaller : MonoInstaller
{
    [SerializeField] private Transform _parent;
    [SerializeField] private PreviewObject _minePreviewPref;
    [SerializeField] private PreviewObject _distanceBombPreviewPref;
    [SerializeField] private PreviewObject _barrelPreviewPref;
    [SerializeField] private PreviewObject _baseWallPreviewPref;

    public override void InstallBindings()
    {
        Container.Bind<MinePreviewFactory>()
            .AsSingle()
            .WithArguments(_parent, _minePreviewPref);

        Container.Bind<DistanceBombPreviewFactory>()
            .AsSingle()
            .WithArguments(_parent, _distanceBombPreviewPref);

        Container.Bind<BarrelPreviewFactory>()
            .AsSingle()
            .WithArguments(_parent, _barrelPreviewPref);

        Container.Bind<BaseWallPreviewFactory>()
            .AsSingle()
            .WithArguments(_parent, _baseWallPreviewPref);
    }
}
