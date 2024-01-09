using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRadiusController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _explodeSphereMesh;
    [SerializeField] private float _showAnimDur;
    [SerializeField] private float _hideAnimDur;

    private Material _material;
    private Tween _showAnim;
    private Sequence _hideAnim;
    private float _diametr;
    private float _alphaOriginal;
    private float _depthAmountOriginal;
    private float _ambientOcclusionOriginal;

    private int _alphaPropID;
    private int _depthAmountPropID;
    private int _ambientOcclusionPropID;

    private void OnValidate()
    {
        if (_explodeSphereMesh == null)
            _explodeSphereMesh = GetComponent<MeshRenderer>();
    }

    private void OnDestroy()
    {
        _showAnim?.Kill();
        _hideAnim?.Kill();
    }

    public void Initialize(float explodeRadius)
    {
        _diametr = explodeRadius * 2f;

        SetupMaterial();
    }

    private void SetupMaterial()
    {
        _material = _explodeSphereMesh.material;

        _alphaPropID = Shader.PropertyToID("_Alpha");
        _depthAmountPropID = Shader.PropertyToID("_DepthAmount");
        _ambientOcclusionPropID = Shader.PropertyToID("_AmbientOcclusion");

        _alphaOriginal = _material.GetFloat(_alphaPropID);
        _depthAmountOriginal = _material.GetFloat(_depthAmountPropID);
        _ambientOcclusionOriginal = _material.GetFloat(_ambientOcclusionPropID);
    }

    public void Show()
    {
        _hideAnim?.Kill();

        _material.SetFloat(_alphaPropID, _alphaOriginal);
        _material.SetFloat(_depthAmountPropID, _depthAmountOriginal);
        _material.SetFloat(_ambientOcclusionPropID, _ambientOcclusionOriginal);
        gameObject.SetActive(true);

        transform.localScale = Vector3.zero;
        _showAnim = transform.DOScale(_diametr, _showAnimDur);
    }

    public void Hide()
    {
        _showAnim?.Kill();
        _hideAnim = DOTween.Sequence();
        _hideAnim
            .Append(_material.DOFloat(0f, _alphaPropID, _hideAnimDur))
            .Insert(0, _material.DOFloat(0, _depthAmountPropID, _hideAnimDur))
            .Insert(0, _material.DOFloat(0, _ambientOcclusionPropID, _hideAnimDur))
            .OnComplete(() => gameObject.SetActive(false));
    }
}
