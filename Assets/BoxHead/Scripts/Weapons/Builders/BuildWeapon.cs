using UnityEngine;
using Zenject;

public abstract class BuildWeapon : Weapon
{
    [Header("Build weapon stats")]
    [SerializeField] protected LayerMask _buildAllowMask;
    [SerializeField] protected LayerMask _buildForbidMask;
    [SerializeField] protected Vector3 _checkBoxHalfExtents = new(0.5f, 2f, 0.5f);

    protected Blueprint _blueprint;
    protected PlayerInputActions _inputActions;

    [Inject]
    public void Construct(PlayerInputActions inputActions)
    {
        _inputActions = inputActions;
    }

    protected override void Awake()
    {
        base.Awake();
        _blueprint = new(BuildPreview(), _buildAllowMask, _buildForbidMask, _checkBoxHalfExtents, _attackDistance);
    }

    protected virtual void Update()
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

    protected abstract PreviewObject BuildPreview();
}
