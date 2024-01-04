using UnityEngine;
using Zenject;

public class MineGun : Weapon
{
    [Header("Mine gun stats")]
    [SerializeField] private LayerMask _buildAllowMask;
    [SerializeField] private LayerMask _buildForbidMask;
    [SerializeField] private Vector3 _checkBoxHalfExtents = new Vector3(0.5f, 2f, 0.5f);

    private Blueprint _blueprint;
    private MinePreviewFactory _minePreviewFactory;
    private PlayerInputActions _inputActions;

    [Inject]
    public void Construct(MinePreviewFactory minePreviewFactory, PlayerInputActions inputActions)
    {
        _minePreviewFactory = minePreviewFactory;
        _inputActions = inputActions;
    }

    protected override void Awake()
    {
        base.Awake();
        var preview = _minePreviewFactory.Build();
        _blueprint = new(preview, _buildAllowMask, _buildForbidMask, _checkBoxHalfExtents, _attackDistance);
    }

    private void Update()
    {
        Vector2 mousePos = _inputActions.Player.Look.ReadValue<Vector2>();
        _blueprint.Update(mousePos, _characterShooting.transform.position);
    }

    public override void Show()
    {
        base.Show();
        _blueprint.Show();
    }

    public override void Hide()
    {
        base.Hide();
        _blueprint.Hide();
    }

    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        if (!_blueprint.AllowBuild)
            return ShootResult.Fail;

        DecrementAmmoAndRecordTime();
        Reload();

        Vector3 centeredPos = Blueprint.GetCenteredPos(worldHit);
        _bulletFactory.BuildBaseMine(centeredPos);
        return ShootResult.Success;
    }
}
