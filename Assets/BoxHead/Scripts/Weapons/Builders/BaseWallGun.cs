using UnityEngine;
using Zenject;

public class BaseWallGun : BuildWeapon
{
    private BaseWallPreviewFactory _baseWallPreviewFactory;
    private BaseWallPostFactory _baseWallFactory;

    [Inject]
    public void Construct(BaseWallPreviewFactory baseWallPreviewFactory, BaseWallPostFactory baseWallFactory)
    {
        _baseWallPreviewFactory = baseWallPreviewFactory;
        _baseWallFactory = baseWallFactory;
    }

    protected override PreviewObject BuildPreview() => _baseWallPreviewFactory.Build();

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        if (!_blueprint.AllowBuild)
            return ShootResult.Fail;

        DecrementAmmoAndRecordTime();
        Reload();

        Vector3 centeredPos = _blueprint.GetBuildingPos();
        _baseWallFactory.Build(centeredPos);
        return ShootResult.Success;
    }
}
