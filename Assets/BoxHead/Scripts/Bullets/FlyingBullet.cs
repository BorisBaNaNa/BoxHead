using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;

public class FlyingBullet : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CapsuleCollider _collider;

    [Header("Stats")]
    [SerializeField] private LayerMask _exploseTarget;
    [SerializeField] private float _startSpeed = 5f;
    [SerializeField] private float _endSpeed = 10f;
    [SerializeField] private float _accelerationDelay = 0.5f;
    [SerializeField] private float _accelerationDur = 2f;
    [SerializeField] private float _exploseRadius = 5f;
    [SerializeField] private float _explosePushForce = 10f;

    private Exploder _exploder;
    private float _damage;
    private float _curVelocity;
    private float _curSpeed;
    private float _curFlyingTime;
    private bool _isActivated;
    private bool isDestroyed;

    [Inject]
    public void Construct(Exploder exploder)
    {
        _exploder = exploder;
    }

    private void Awake()
    {
        _collider.enabled = false;
    }

    private void Update()
    {
        if (!_isActivated) return;
        ApplyAcceleration();
        Move();
    }

    private void OnValidate()
    {
        if (_collider == null)
            _collider = GetComponent<CapsuleCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDestroyed) return;

        Debug.Log("Rocket is collided!");
        Vector3 explodePos = collision.contacts.First().point;
        _exploder.Explode(explodePos, _damage, _exploseTarget, _exploseRadius, _explosePushForce);
        isDestroyed = true;
        Destroy(gameObject);
    }

    private void ApplyAcceleration()
    {
        if (_curFlyingTime < _accelerationDelay)
            _curFlyingTime += Time.deltaTime;
        else if (_curSpeed < _endSpeed)
            _curSpeed = Mathf.SmoothDamp(_curSpeed, _endSpeed, ref _curVelocity, _accelerationDur);
    }

    private void Move()
    {
        Vector3 translation = _curSpeed * Time.deltaTime * Vector3.forward;
        transform.Translate(translation, Space.Self);
    }

    public void Activate(float damage, Vector3 dir)
    {
        _damage = damage;
        transform.rotation = Quaternion.LookRotation(dir);

        _curSpeed = _startSpeed;
        _isActivated = true;
        _collider.enabled = true;
    }
}
