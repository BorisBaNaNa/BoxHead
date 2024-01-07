using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BaseWallPost : MonoBehaviour, IDamagable
{
    [Header("Components")]
    [SerializeField] private Collider[] _colliders;

    [Header("Stats")]
    [SerializeField] private float _maxHealth = 150f;

    private Dictionary<BaseWallPost, BaseWall> _neighbors = new Dictionary<BaseWallPost, BaseWall>(4);
    BaseWallFactory _baseWallFactory;
    private float _curHealth;

    [Inject]
    public void Construct(BaseWallFactory baseWallFactory)
    {
        _baseWallFactory = baseWallFactory;
    }

    private void Awake()
    {
        _curHealth = _maxHealth;
    }

    private void OnValidate()
    {
        if (_colliders == null || _colliders.Length == 0)
            _colliders = GetComponentsInChildren<Collider>();
    }

    public void CheckAndBuildWalls()
    {
        Quaternion rotate90 = Quaternion.Euler(0, 90, 0);
        Vector3 checkDir = transform.forward;

        for (int i = 0; i < 4; i++)
        {
            Vector3 rayOrigin = transform.position;
            rayOrigin.y += 1f;

            if (Physics.Raycast(rayOrigin, checkDir, out var hitInfo, 1f, 1 << gameObject.layer))
            {
                if (hitInfo.collider.TryGetComponentInParent<BaseWallPost>(out var wallPost))
                {
                    var wall = _baseWallFactory.Build(wallPost.transform.position);
                    Vector3 toNieghborsDir = (transform.position - wallPost.transform.position).normalized;
                    Quaternion wallRotation = Quaternion.LookRotation(toNieghborsDir, wall.transform.up);

                    wall.transform.rotation = wallRotation;
                    wall.AddNeighbors(wallPost, this);
                    AddNeighbor(wallPost, wall);
                    wallPost.AddNeighbor(this, wall);
                }
            }
            checkDir = rotate90 * checkDir;
        }
    }

    public void AddNeighbor(BaseWallPost wallPost, BaseWall baseWall)
    {
        _neighbors.Add(wallPost, baseWall);
    }

    public void RemoveNeighbor(BaseWallPost wallPost)
    {
        _neighbors.Remove(wallPost);
    }

    public void TakeDamage(float damage, Action effectAction = null)
    {
        _curHealth -= damage;
        if (_curHealth <= 0)
            DestroySelf();
    }

    private void DestroySelf()
    {
        Debug.Log($"{name} was destroyed");
        foreach (var collider in _colliders)
            collider.enabled = false;

        foreach(var neighbor in _neighbors)
        {
            neighbor.Key.RemoveNeighbor(this);
            neighbor.Value.DestroySelf();
        }

        Destroy(gameObject);
    }
}
