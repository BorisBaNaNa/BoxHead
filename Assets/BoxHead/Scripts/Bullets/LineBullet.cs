using System.Collections;
using UnityEngine;

public class LineBullet : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _fadeAnimDur = 0.3f;

    private Color _startLineRendererColor;
    private Color _endLineRendererColor;

    public void Construct(float damage, float attackDistance, Vector3 dir)
    {
        float distanceToTarget = attackDistance;

        if (Physics.Raycast(transform.position, dir, out var hit, attackDistance))
        {
            distanceToTarget = hit.distance;

            if (hit.transform.TryGetComponent<IDamagable>(out var damagable))
                damagable.TakeDamage(damage);
        }

        InitLineRenderer(dir, distanceToTarget);
    }

    private void InitLineRenderer(Vector3 dir, float distanceToTarget)
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, transform.position + dir * distanceToTarget);

        _startLineRendererColor = _lineRenderer.startColor;
        _endLineRendererColor = _lineRenderer.endColor;
    }

    private void Start()
    {
        StartCoroutine(FadeAndDestroyRoutine());
    }

    IEnumerator FadeAndDestroyRoutine()
    {
        for (float curTime = 0; curTime <= _fadeAnimDur; curTime += Time.deltaTime)
        {
            float t = curTime / _fadeAnimDur;

            Color newColor = Color.Lerp(_startLineRendererColor, new Color(1, 1, 1, 0), t);
            _lineRenderer.startColor = newColor;

            newColor = Color.Lerp(_endLineRendererColor, new Color(1, 1, 1, 0), t);
            _lineRenderer.endColor = newColor;
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnValidate()
    {
        if (_lineRenderer == null) _lineRenderer = GetComponent<LineRenderer>();
    }
}
