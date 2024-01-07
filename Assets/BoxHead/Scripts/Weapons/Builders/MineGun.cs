using UnityEngine;
using Zenject;

public class MineGun : BuildWeapon
{
    private MinePreviewFactory _minePreviewFactory;
    private BaseMineFactory _bulletFactory;

    [Inject]
    public void Construct(MinePreviewFactory minePreviewFactory, BaseMineFactory bulletFactory)
    {
        _minePreviewFactory = minePreviewFactory;
        _bulletFactory = bulletFactory;
    }

    protected override PreviewObject BuildPreview() => _minePreviewFactory.Build();

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        if (!_blueprint.AllowBuild)
            return ShootResult.Fail;

        DecrementAmmoAndRecordTime();
        Reload();

        Vector3 centeredPos = _blueprint.GetBuildingPos();
        _bulletFactory.Build(centeredPos, _damage);
        return ShootResult.Success;
    }
}
