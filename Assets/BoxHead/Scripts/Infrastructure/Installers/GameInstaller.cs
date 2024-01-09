using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using DG.Tweening;

public class GameInstaller : MonoInstaller, IInitializable
{

    public void Initialize()
    {
        DOTween.Init();
    }

    public override void InstallBindings()
    {
        BindInstallerInterfaces();
    }

    private void BindInstallerInterfaces()
    {
        Container
            .BindInterfacesAndSelfTo<GameInstaller>()
            .FromInstance(this);
    }

}
