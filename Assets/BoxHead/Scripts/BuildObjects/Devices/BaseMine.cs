using System.Collections;
using UnityEngine;
using Zenject;

public class BaseMine : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private LayerMask _exploseTarget;
    [SerializeField] private float _activateTime = 2f;
    [SerializeField] private float _exploseDelay = 0.1f;
    [SerializeField] private float _exploseRadius = 5f;
    [SerializeField] private float _explosePushForce = 10f;

    private Exploder _exploder;
    private float _damage;
    private bool _isActivated;
    private bool isDestroyed;

    [Inject]
    public void Construct(Exploder exploder)
    {
        _exploder = exploder;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDestroyed || !_isActivated || !HasLayerMask(other.gameObject.layer))
            return;

        isDestroyed = true;
        StartCoroutine(ExploseRoutine());
    }

    public void Initialize(float damage)
    {
        _damage = damage;
        StartCoroutine(ActivateRoutine());
    }

    private IEnumerator ActivateRoutine()
    {
        yield return new WaitForSeconds(_activateTime);
        _isActivated = true;
        Debug.Log("mine is activated!");
    }

    private IEnumerator ExploseRoutine()
    {
        yield return new WaitForSeconds(_exploseDelay);
        _exploder.Explode(transform.position, _damage, _exploseTarget, _exploseRadius, _explosePushForce);
        Destroy(gameObject);
    }

    private bool HasLayerMask(int layer)
    {
        int layerMask = 1 << layer;
        return (_targetMask.value & layerMask) != 0;
    }
}
