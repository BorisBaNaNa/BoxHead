using System;
using UnityEngine;
using Zenject;

public class BulletFactory
{
    public Transform BulletParent => _bulletParent;

    private DiContainer _container;
    private LineBullet _lineBulletPrefab;
    private FlyingBullet _flyBulletPrefab;
    private GranadeBullet _granadeBulletPrefab;
    private BaseMine _baseMinePrefab;
    private Transform _bulletParent;

    public BulletFactory(DiContainer container, Transform bulletParent,
        LineBullet lineBulletPrefab, FlyingBullet flyBulletPrefab, GranadeBullet granadeBulletPrefab, BaseMine baseMinePrefab)
    {
        _container = container;
        _bulletParent = bulletParent;

        _lineBulletPrefab = lineBulletPrefab;
        _flyBulletPrefab = flyBulletPrefab;
        _granadeBulletPrefab = granadeBulletPrefab;
        _baseMinePrefab = baseMinePrefab;
    }

    public LineBullet BuildLineType(Vector3 pos, Vector3 dir, float damage, float attackDistance)
    {
        var bullet = _container.InstantiatePrefabForComponent<LineBullet>(_lineBulletPrefab, pos, Quaternion.LookRotation(dir), _bulletParent);
        bullet.Construct(damage, attackDistance, dir);
        return bullet;
    }

    public FlyingBullet BuildFlyType(Transform spawnPoint)
    {
        var bullet = _container.InstantiatePrefabForComponent<FlyingBullet>(_flyBulletPrefab);
        bullet.transform.SetParent(spawnPoint, false);
        bullet.transform.localPosition = Vector3.zero;
        return bullet;
    }

    public GranadeBullet BuildGranade(Transform spawnPoint)
    {
        var bullet = _container.InstantiatePrefabForComponent<GranadeBullet>(_granadeBulletPrefab);
        bullet.transform.SetParent(spawnPoint, false);
        bullet.transform.localPosition = Vector3.zero;
        return bullet;
    }

    public BaseMine BuildBaseMine(Vector3 position)
    {
        var bullet = _container.InstantiatePrefabForComponent<BaseMine>(_baseMinePrefab);
        bullet.transform.SetParent(_bulletParent);
        bullet.transform.position = position;
        return bullet;
    }
}
