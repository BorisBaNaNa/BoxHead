using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _playerPrefab;

    public override void InstallBindings()
    {
        BindPlayerInput();
        //BindVirtualCamera();

        BuildAndBindPlayer();
    }

    private void BindVirtualCamera()
    {
        Container
            .Bind<CinemachineVirtualCamera>()
            .FromInstance(_virtualCamera)
            .AsSingle();
    }

    private void BindPlayerInput()
    {
        Container
            .Bind<PlayerInputActions>()
            .AsSingle();
    }

    private void BuildAndBindPlayer()
    {
        Container
            .BindInterfacesAndSelfTo<Player>()
            .FromComponentInNewPrefab(_playerPrefab)
            .AsSingle()
            .OnInstantiated<Player>(OnPlayerInstantiated)
            .NonLazy();
    }

    private void OnPlayerInstantiated(InjectContext context, Player player)
    {
        player.transform.position = _spawnPoint.position;
        _virtualCamera.Follow = player.transform;
        _virtualCamera.LookAt = player.transform;
    }
}
