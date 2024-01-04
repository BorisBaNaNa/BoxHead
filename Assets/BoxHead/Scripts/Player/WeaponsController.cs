using ModestTree;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(CharacterShooting))]
public class WeaponsController : MonoBehaviour
{
    [SerializeField] private CharacterShooting _shootController;

    [Header("Stats")]
    [SerializeField] private List<Weapon> _weaponList = new();

    private PlayerInputActions _inputActions;

    [Inject]
    public void Construct(PlayerInputActions inputActions)
    {
        _inputActions = inputActions;
    }

    private void Awake()
    {
        Init();
    }

    private void OnDestroy()
    {
        DisableWeaponActions();
    }

    private void OnValidate()
    {
        if (_shootController == null)
            _shootController = GetComponent<CharacterShooting>();
    }

    private void Init()
    {
        if (_weaponList != null && !_weaponList.IsEmpty())
        {
            _shootController.SetWeapon(_weaponList.First());
            _weaponList.ForEach(weapon => weapon.Init(_shootController));
        }
        InitWeaponActions();
    }

    private void InitWeaponActions()
    {
        _inputActions.Weapons.Enable();
        _inputActions.Weapons.Slot1.performed += SelectWeapon0;
        _inputActions.Weapons.Slot2.performed += SelectWeapon1;
        _inputActions.Weapons.Slot3.performed += SelectWeapon2;
        _inputActions.Weapons.Slot4.performed += SelectWeapon3;
        _inputActions.Weapons.Slot5.performed += SelectWeapon4;
        _inputActions.Weapons.Slot6.performed += SelectWeapon5;
        _inputActions.Weapons.Slot7.performed += SelectWeapon6;
        _inputActions.Weapons.Slot8.performed += SelectWeapon7;
        _inputActions.Weapons.Slot9.performed += SelectWeapon8;
    }

    private void DisableWeaponActions()
    {
        _inputActions.Weapons.Disable();
        _inputActions.Weapons.Slot1.performed -= SelectWeapon0;
        _inputActions.Weapons.Slot2.performed -= SelectWeapon1;
        _inputActions.Weapons.Slot3.performed -= SelectWeapon2;
        _inputActions.Weapons.Slot4.performed -= SelectWeapon3;
        _inputActions.Weapons.Slot5.performed -= SelectWeapon4;
        _inputActions.Weapons.Slot6.performed -= SelectWeapon5;
        _inputActions.Weapons.Slot7.performed -= SelectWeapon6;
        _inputActions.Weapons.Slot8.performed -= SelectWeapon7;
        _inputActions.Weapons.Slot9.performed -= SelectWeapon8;
    }

    private void SelectWeapon0(InputAction.CallbackContext _) => SelectWeapon(0);
    private void SelectWeapon1(InputAction.CallbackContext _) => SelectWeapon(1);
    private void SelectWeapon2(InputAction.CallbackContext _) => SelectWeapon(2);
    private void SelectWeapon3(InputAction.CallbackContext _) => SelectWeapon(3);
    private void SelectWeapon4(InputAction.CallbackContext _) => SelectWeapon(4);
    private void SelectWeapon5(InputAction.CallbackContext _) => SelectWeapon(5);
    private void SelectWeapon6(InputAction.CallbackContext _) => SelectWeapon(6);
    private void SelectWeapon7(InputAction.CallbackContext _) => SelectWeapon(7);
    private void SelectWeapon8(InputAction.CallbackContext _) => SelectWeapon(8);

    private void SelectWeapon(int id) => _shootController.SetWeapon(_weaponList.ElementAt(id));
}
