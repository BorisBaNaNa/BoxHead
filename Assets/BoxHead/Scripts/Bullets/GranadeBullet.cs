using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GranadeBullet : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private Rigidbody _rb;

    [Header("Stats")]
    [SerializeField] private Vector3 _rotateAxis = Vector3.one;
    [SerializeField] private LayerMask _exploseTarget;
    [SerializeField] private bool _exploseOnContact;
    [SerializeField] private float _exploseRadius = 5f;
    [SerializeField] private float _explosePushForce = 10f;
    [SerializeField] private float _forceRotation = 15f;
    [SerializeField] private float _explodeTimeDelay = 3f;

    private Coroutine _explodeCorutine;
    private Exploder _exploder;
    private float _damage;
    private bool isDestroyed;

    [Inject]
    public void Construct(Exploder exploder)
    {
        _exploder = exploder;
    }

    private void Awake()
    {
        _collider.enabled = false;
        _rb.isKinematic = true;
    }

    private void OnValidate()
    {
        if (_collider == null)
            _collider = GetComponent<CapsuleCollider>();
        if (_rb == null)
            _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDestroyed || !_exploseOnContact) return;

        Debug.Log("GranadeBullet is collided!");
        ExplodeThis();
    }

    public void Activate(float damage, float force, Vector3 dir, Vector3 startVelocity)
    {
        _damage = damage;
        _collider.enabled = true;

        _rb.isKinematic = false;
        _rb.AddForce(force * dir, ForceMode.Impulse);
        _rb.angularVelocity = Random.rotation * _rotateAxis * _forceRotation;
        _rb.velocity = startVelocity;

        _explodeCorutine = StartCoroutine(ExplodeAfterWaitRoutine());
    }

    private void ExplodeThis()
    {
        if (_explodeCorutine != null)
        {
            StopCoroutine(_explodeCorutine);
            _explodeCorutine = null;
        }

        Vector3 explodePos = transform.position;
        _exploder.Explode(explodePos, _damage, _exploseTarget, _exploseRadius, _explosePushForce);
        isDestroyed = true;
        Destroy(gameObject);
        Debug.Log("GranadeBullet is EXPLODED!!!");
    }

    private IEnumerator ExplodeAfterWaitRoutine()
    {
        yield return new WaitForSeconds(_explodeTimeDelay);
        _explodeCorutine = null;
        ExplodeThis();
    }
}