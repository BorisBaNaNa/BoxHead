using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class DistanceBombGun : BuildWeapon
{
    private DistanceBombPreviewFactory _bombPrevFactory;
    private DistanceBombFactory _bombFactory;
    private List<DistanceBomb> _buildingBombs = new();
    private bool _abilityIsActive;

    [Inject]
    public void Construct(DistanceBombPreviewFactory bombPrevFactory, DistanceBombFactory bombFactory)
    {
        _bombPrevFactory = bombPrevFactory;
        _bombFactory = bombFactory;
    }

    protected override PreviewObject BuildPreview() => _bombPrevFactory.Build();

    public override ShootResult Shoot(RaycastHit worldHit)
    {
        if (_abilityIsActive)
            return ExplodeAll();
        return base.Shoot(worldHit);
    }

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        return BuildNewBomb(worldHit);
    }

    private ShootResult ExplodeAll()
    {
        if (_buildingBombs.Count == 0)
            return ShootResult.Fail;

        _buildingBombs.ForEach(bomb => bomb.Explode());
        _buildingBombs.Clear();
        return ShootResult.Success;
    }

    private ShootResult BuildNewBomb(RaycastHit worldHit)
    {
        if (!_blueprint.AllowBuild)
            return ShootResult.Fail;

        DecrementAmmoAndRecordTime();
        Reload();

        Vector3 centeredPos = _blueprint.GetBuildingPos();
        var newBomb = _bombFactory.Build(centeredPos, _damage);
        _buildingBombs.Add(newBomb);

        return ShootResult.Success;
    }

    public override void StartAbility(InputAction.CallbackContext context)
    {
        _abilityIsActive = true;
        _blueprint.Hide();
        _buildingBombs.ForEach(bomb => bomb.ShowExplodeSphere());
    }

    public override void StopAbility(InputAction.CallbackContext context)
    {
        _abilityIsActive = false;
        _blueprint.Show();
        _buildingBombs.ForEach(bomb => bomb.HideExplodeSphere());
    }
}
