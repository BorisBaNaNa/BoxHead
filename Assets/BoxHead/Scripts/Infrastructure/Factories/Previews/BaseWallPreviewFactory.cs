using UnityEngine;
using Zenject;

public class BaseWallPreviewFactory
{
    private DiContainer _container;
    private Transform _parent;
    private PreviewObject _baseWallPreviewPref;

    [Inject]
    public void Construct(DiContainer container, Transform parent, PreviewObject baseWallPreviewPref)
    {
        _container = container;
        _parent = parent;
        _baseWallPreviewPref = baseWallPreviewPref;
    }

    public PreviewObject Build()
    {
        return _container.InstantiatePrefabForComponent<PreviewObject>(_baseWallPreviewPref, _parent);
    }
}