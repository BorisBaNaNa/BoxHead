using System;

public interface IDamagable
{
    void TakeDamage(float damage, Action effectAction = null);
}
