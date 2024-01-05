using UnityEngine;
using Zenject;

public class DistanceBombPreviewFactory
{
    private DiContainer _container;
    private Transform _parent;
    private PreviewObject _bombPreviewPref;

    [Inject]
    public void Construct(DiContainer container, Transform parent, PreviewObject minePreviewPref)
    {
        _container = container;
        _parent = parent;
        _bombPreviewPref = minePreviewPref;
    }

    public PreviewObject Build()
    {
        return _container.InstantiatePrefabForComponent<PreviewObject>(_bombPreviewPref, _parent);
    }
}