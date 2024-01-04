using UnityEngine;

public class Exploder
{
    public void Explode(Vector3 explodePoint, float damage, LayerMask exploseTarget, float exploseRadius, float explosePushForce)
    {
        var colliders = Physics.OverlapSphere(explodePoint, exploseRadius, exploseTarget.value);

        foreach (var collider in colliders)
        {
            if (!collider.TryGetComponent<IDamagable>(out var damagable))
                continue;

            Vector3 closectPointOnCollider = collider.bounds.ClosestPoint(explodePoint);
            Vector3 dirToCollider = closectPointOnCollider - explodePoint;
            float distanceFactor = Mathf.Clamp01(1 - dirToCollider.magnitude / exploseRadius);

            Vector3 pushForce = distanceFactor * explosePushForce * dirToCollider.normalized;
            damagable.TakeDamage(damage * distanceFactor, () => ApplyExploseFoce(collider, pushForce));
        }
    }

    private void ApplyExploseFoce(Collider obj, Vector3 pushForce)
    {
        if (!obj.TryGetComponent<IPushable>(out var body))
            return;

        pushForce.y *= 0.35f;// !!!
        body.Push(pushForce);
    }
}
