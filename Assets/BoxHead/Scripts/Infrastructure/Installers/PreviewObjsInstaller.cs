using UnityEngine;
using Zenject;

public class PreviewObjsInstaller : MonoInstaller
{
    [SerializeField] private Transform _parent;
    [SerializeField] private PreviewObject _minePreviewPref;
    [SerializeField] private PreviewObject _distanceBombPreviewPref;

    public override void InstallBindings()
    {
        Container.Bind<MinePreviewFactory>()
            .AsSingle()
            .WithArguments(_parent, _minePreviewPref);

        Container.Bind<DistanceBombPreviewFactory>()
            .AsSingle()
            .WithArguments(_parent, _distanceBombPreviewPref);
    }
}
