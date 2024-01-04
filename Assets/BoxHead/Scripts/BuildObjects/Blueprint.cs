using UnityEngine;

public class Blueprint
{
    public bool AllowBuild
    {
        get => _allowBuild;
        private set
        {
            _allowBuild = value;
            if (_allowBuild)
                _preview.SetValidMat();
            else
                _preview.SetInvalidMat();
        }
    }

    private PreviewObject _preview;
    private Camera _cameraMain;
    private LayerMask _buildForbidMask;
    private LayerMask _buildAllowMask;
    private Vector3 _checkBoxHalfExtents;
    private float _maxBuildDistance;
    private bool _allowBuild;

    public Blueprint(PreviewObject preview, LayerMask buildAllowMask, LayerMask buildForbidMask, Vector3 checkBoxHalfExtents, float maxBuildDistance)
    {
        _preview = preview;
        _cameraMain = Camera.main;
        _buildAllowMask = buildAllowMask;
        _buildForbidMask = buildForbidMask;
        _checkBoxHalfExtents = checkBoxHalfExtents;
        _maxBuildDistance = maxBuildDistance;
    }

    public void Show()
    {
        _preview.Show();
    }

    public void Hide()
    {
        _preview.Hide();
    }

    public void Update(Vector2 mousePos, Vector3 playerPos)
    {
        RaycastHit? hitInfo = RaycastToGround(mousePos);
        if (hitInfo == null) return;

        Vector3 centeredMinePos = GetCenteredPos(hitInfo.Value);
        _preview.transform.position = centeredMinePos;

        CheckBuildValidity(hitInfo.Value, centeredMinePos, playerPos);
    }

    public static Vector3 GetCenteredPos(RaycastHit hitInfo)
    {
        return hitInfo.point.Floor(Axis.XZ) + new Vector3(0.5f, 0f, 0.5f);
    }

    private void CheckBuildValidity(RaycastHit hitInfo, Vector3 centerCheckPos, Vector3 playerPos)
    {
        float angleNormalToX = Vector3.Angle(hitInfo.normal, Vector3.up);
        bool allowBuild = Mathf.Approximately(angleNormalToX, 0f) && Vector3.Distance(playerPos, centerCheckPos) <= _maxBuildDistance;

        if (allowBuild)
        {
            centerCheckPos.y += _checkBoxHalfExtents.y;
            Collider[] colliders = Physics.OverlapBox(centerCheckPos, _checkBoxHalfExtents, Quaternion.identity, _buildForbidMask.value);
            allowBuild &= colliders.Length == 0;
        }
        AllowBuild = allowBuild;
    }

    private RaycastHit? RaycastToGround(Vector2 mousePos)
    {
        Ray cameraRay = _cameraMain.ScreenPointToRay(mousePos);
        if (Physics.Raycast(cameraRay, out var hitInfo, float.PositiveInfinity, _buildAllowMask.value))
            return hitInfo;
        return null;
    }
}