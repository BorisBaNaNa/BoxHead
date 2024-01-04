﻿using UnityEngine;

public class Uzi : Weapon
{
    protected override ShootResult ShootImplementation(RaycastHit worldHit)
    {
        DecrementAmmoAndRecordTime();

        Vector3 shootDir = (worldHit.point - transform.position).normalized;
        _bulletFactory.BuildLineType(_spawnPoint.position, shootDir, _damage, _attackDistance);
        return ShootResult.Success;
    }
}

