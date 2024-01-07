using System;
using UnityEngine;
using Zenject;

public class Barrel : MonoBehaviour, IDamagable, IExplosive
{
    [Header("Components")]
    [SerializeField] private Collider[] _colliders;

    [Header("Stats")]
    [SerializeField] private LayerMask _exploseTarget;
    [SerializeField] private float _maxTriggers = 2;
    [SerializeField] private float _exploseRadius = 5f;
    [SerializeField] private float _explosePushForce = 10f;

    private Exploder _exploder;
    private float _curTriggersCount;
    private float _damage;

    private void OnValidate()
    {
        if (_colliders == null || _colliders.Length == 0)
            _colliders = GetComponentsInChildren<Collider>();
    }

    [Inject]
    public void Construct(Exploder exploder)
    {
        _exploder = exploder;
    }

    public void TakeDamage(float damage, Action effectAction = null)
    {
        if (++_curTriggersCount == _maxTriggers)
            ExplodeThis();
    }

    public void ExplodeThis()
    {
        SetCollidersEnable(false);
        _exploder.Explode(transform.position, _damage, _exploseTarget, _exploseRadius, _explosePushForce);
        Debug.Log("Barrel exploded!");
        Destroy(gameObject);
    }

    public void SetCollidersEnable(bool enable)
    {
        foreach (var collider in _colliders)
            collider.enabled = enable;
    }

    public void Initialize(float damage)
    {
        _damage = damage;
    }
}
