using System;
using UnityEngine;

public class BaseWall : MonoBehaviour, IDamagable
{
    [Header("Components")]
    [SerializeField] private Collider[] _colliders;

    [Header("Neighbors")]
    [SerializeField] private BaseWallPost _wallPost1;
    [SerializeField] private BaseWallPost _wallPost2;

    private void OnValidate()
    {
        if (_colliders == null || _colliders.Length == 0)
            _colliders = GetComponentsInChildren<Collider>();
    }

    public void TakeDamage(float damage, Action effectAction = null)
    {
        float halfDamage = damage * 0.5f;
        _wallPost1.TakeDamage(halfDamage);
        _wallPost2.TakeDamage(halfDamage);
    }

    public void AddNeighbors(BaseWallPost wallPost1, BaseWallPost wallPost2)
    {
        _wallPost1 = wallPost1;
        _wallPost2 = wallPost2;
    }

    public void DestroySelf()
    {
        Debug.Log($"{name} was destroyed");

        foreach (var collider in _colliders)
            collider.enabled = false;

        Destroy(gameObject);
    }
}