using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class DistanceBomb : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private LayerMask _exploseTarget;
    [SerializeField] private float _exploseDelay = 0.1f;
    [SerializeField] private float _exploseRadius = 5f;
    [SerializeField] private float _explosePushForce = 10f;

    private Exploder _exploder;
    private float _damage;
    private bool isDestroyed;

    [Inject]
    public void Construct(Exploder exploder)
    {
        _exploder = exploder;
    }

    internal void Initialize(float damage)
    {
        _damage = damage;
    }

    internal void ShowExplodeSphere()
    {
        Debug.Log($"ShowExplodeSphere {name}");
    }

    internal void HideExplodeSphere()
    {
        Debug.Log($"HideExplodeSphere {name}");
    }

    internal void Explode()
    {
        StartCoroutine(ExploseRoutine());
    }

    private IEnumerator ExploseRoutine()
    {
        yield return new WaitForSeconds(_exploseDelay);
        _exploder.Explode(transform.position, _damage, _exploseTarget, _exploseRadius, _explosePushForce);
        Destroy(gameObject);
    }
}