using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterMovement))]
public class Player : MonoBehaviour, IDamagable, IMovable
{
    [Header("Components")]
    [SerializeField] private CharacterMovement _moveController;

    private void OnValidate()
    {
        if (_moveController == null)
            _moveController = GetComponent<CharacterMovement>();
    }

    public void TakeDamage(float damage, Action effectAction = null)
    {
        Debug.Log($"Player get damage: {damage}");
        effectAction?.Invoke();
    }

    public Vector3 GetVelocity() => _moveController.Velocity;
}

