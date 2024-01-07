using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Vector3Ext
{
    public static Vector3 Rounded(this Vector3 v, Axis axis = Axis.XYZ) => new()
    {
        x = axis.Contains(Axis.X) ? Mathf.Round(v.x) : v.x,
        y = axis.Contains(Axis.Y) ? Mathf.Round(v.y) : v.y,
        z = axis.Contains(Axis.Z) ? Mathf.Round(v.z) : v.z,
    };

    public static Vector3 Floor(this Vector3 v, Axis axis = Axis.XYZ) => new()
    {
        x = axis.Contains(Axis.X) ? Mathf.Floor(v.x) : v.x,
        y = axis.Contains(Axis.Y) ? Mathf.Floor(v.y) : v.y,
        z = axis.Contains(Axis.Z) ? Mathf.Floor(v.z) : v.z,
    };
}
