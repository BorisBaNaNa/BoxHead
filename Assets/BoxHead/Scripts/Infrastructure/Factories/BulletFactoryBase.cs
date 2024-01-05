using UnityEngine;
using Zenject;

public abstract class BulletFactoryBase
{
    public Transform BulletsParent => _bulletsParent;

    protected readonly DiContainer _container;
    protected readonly Transform _bulletsParent;

    public BulletFactoryBase(DiContainer container, Transform bulletParent)
    {
        _container = container;
        _bulletsParent = bulletParent;
    }
}
