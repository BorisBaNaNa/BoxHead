using UnityEngine;
using Zenject;

public class BarrelGun : BuildWeapon
{
    private BarrelPreviewFactory _barrelPreviewFactory;
    private BarrelFactory _barrelFactory;

    [Inject]
    public void Construct(BarrelPreviewFactory barrelPreviewFactory, BarrelFactory barrelFactory)
    {
        _barrelPreviewFactory = barrelPreviewFactory;
        _barrelFactory = barrelFactory;
    }

    protected override PreviewObject BuildPreview() => _barrelPreviewFactory.Build();

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        if (!_blueprint.AllowBuild)
            return ShootResult.Fail;

        DecrementAmmoAndRecordTime();
        Reload();

        Vector3 centeredPos = _blueprint.GetBuildingPos();
        _barrelFactory.Build(centeredPos, _damage);
        return ShootResult.Success;
    }
}
