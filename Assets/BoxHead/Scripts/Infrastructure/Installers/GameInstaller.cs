using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller, IInitializable
{

    public void Initialize()
    {

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
