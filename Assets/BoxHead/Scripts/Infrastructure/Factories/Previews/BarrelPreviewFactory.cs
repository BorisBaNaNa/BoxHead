using UnityEngine;
using Zenject;

public class BarrelPreviewFactory
{
    private DiContainer _container;
    private Transform _parent;
    private PreviewObject _barrelPreviewPref;

    [Inject]
    public void Construct(DiContainer container, Transform parent, PreviewObject barrelPreviewPref)
    {
        _container = container;
        _parent = parent;
        _barrelPreviewPref = barrelPreviewPref;
    }

    public PreviewObject Build()
    {
        return _container.InstantiatePrefabForComponent<PreviewObject>(_barrelPreviewPref, _parent);
    }
}
