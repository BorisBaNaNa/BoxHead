using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class DistanceBomb : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ExplodeRadiusController _explodeRadiusController;

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
        _explodeRadiusController.Initialize(_exploseRadius);
    }

    internal void ShowExplodeSphere()
    {
        _explodeRadiusController.Show();
    }

    internal void HideExplodeSphere()
    {
        _explodeRadiusController.Hide();
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