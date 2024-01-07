public enum Axis
{
    X = 0b001,
    Y = 0b010,
    Z = 0b100,
    XY = X | Y,
    XZ = X | Z,
    YZ = Y | Z,
    YX = XY,
    ZX = XZ,
    ZY = YZ,
    XYZ = X | YZ
}

public static class AxisExt
{
    public static bool Contains(this Axis _this, Axis other) => (_this & other) != 0;
}