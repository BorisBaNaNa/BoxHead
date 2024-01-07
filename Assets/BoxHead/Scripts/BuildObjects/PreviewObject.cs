using System;
using UnityEngine;

public class PreviewObject : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshRenderers;
    [SerializeField] private Material _validMaterial;
    [SerializeField] private Material _invalidMaterial;

    private Material _curMaterial;

    private void Awake()
    {
        SetValidMat();
    }

    private void OnValidate()
    {
        if (_meshRenderers == null || _meshRenderers.Length == 0)
            CashMeshesForThis();
    }

    public void SetValidMat() => SetMaterialOnMesh(_validMaterial);

    public void SetInvalidMat() => SetMaterialOnMesh(_invalidMaterial);

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void SetMaterialOnMesh(Material newMaterial)
    {
        if (_curMaterial == newMaterial)
            return;

        foreach (var mesh in _meshRenderers)
        {
            var materials = mesh.materials;
            for (int i = 0; i < materials.Length; i++)
                materials[i] = newMaterial;
            mesh.materials = materials;
        }
        _curMaterial = newMaterial;
    }

    private void CashMeshesForThis()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }
}
