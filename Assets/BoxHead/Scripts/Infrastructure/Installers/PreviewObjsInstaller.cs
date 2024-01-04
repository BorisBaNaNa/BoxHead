using UnityEngine;
using Zenject;

public class PreviewObjsInstaller : MonoInstaller
{
    [SerializeField] private Transform _parent;
    [SerializeField] private PreviewObject _minePreviewPref;

    public override void InstallBindings()
    {
        Container.Bind<MinePreviewFactory>()
            .AsSingle()
            .WithArguments(_parent, _minePreviewPref);
    }
}
