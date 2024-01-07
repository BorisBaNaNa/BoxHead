using UnityEngine;

public static class ComponentExt
{
    public static bool TryGetComponentInParent<T>(this Component _this, out T component, bool includeInactive = false)
    {
        component = _this.GetComponentInParent<T>(includeInactive);
        return component != null;
    }
}
