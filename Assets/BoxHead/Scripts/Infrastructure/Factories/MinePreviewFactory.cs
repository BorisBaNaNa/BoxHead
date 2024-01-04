using UnityEngine;
using Zenject;

public class MinePreviewFactory
{
    private DiContainer _container;
    private Transform _parent;
    private PreviewObject _minePreviewPref;

    [Inject]
    public void Construct(DiContainer container, Transform parent, PreviewObject minePreviewPref)
    {
        _container = container;
        _parent = parent;
        _minePreviewPref = minePreviewPref;
    }

    public PreviewObject Build()
    {
        return _container.InstantiatePrefabForComponent<PreviewObject>(_minePreviewPref, _parent);
    }
}