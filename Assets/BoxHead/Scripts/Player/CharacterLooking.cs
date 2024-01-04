using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterLooking : MonoBehaviour
{
    public LayerMask IgnoredLayerMask => _ignoredLayerMask;

    [Header("Look stats")]
    [SerializeField] private LayerMask _ignoredLayerMask;
    [SerializeField] private float _rotateDur = 0.1f;

    private PlayerInputActions _inputActions;
    private Camera _cameraMain;
    private Vector3 _curRotateVelocity;
    private Vector3 _lastLookDir = Vector3.forward;

    [Inject]
    public void Construct(PlayerInputActions inputActions)
    {
        _inputActions = inputActions;
    }

    private void Awake()
    {
        _cameraMain= Camera.main;
        _inputActions.Player.Look.Enable();
    }

    private void OnDestroy()
    {
        _inputActions.Player.Look.Disable();
    }

    public RaycastHit LookToMousePos()
    {
        Vector2 mousePos = _inputActions.Player.Look.ReadValue<Vector2>();
        Ray cameraRay = _cameraMain.ScreenPointToRay(mousePos);

        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, 1000, ~_ignoredLayerMask))
        {
            Vector3 rayHitPos = hitInfo.point;
            rayHitPos.y = transform.position.y;

            Vector3 curLookDir = (rayHitPos - transform.position).normalized;
            _lastLookDir = Vector3.SmoothDamp(_lastLookDir, curLookDir, ref _curRotateVelocity, _rotateDur);
            transform.rotation = Quaternion.LookRotation(_lastLookDir);
        }

        return hitInfo;
    }
}
