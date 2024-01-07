public interface IExplosive
{
    void ExplodeThis();

    /// <summary>
    /// Необходимо выключать свои коллайдеры перед взрывом чтобы избежать зацикливания
    /// </summary>
    void SetCollidersEnable(bool enable);
}
