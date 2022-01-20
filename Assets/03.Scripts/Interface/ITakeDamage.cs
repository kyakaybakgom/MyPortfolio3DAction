using System.Collections;
using System.Collections.Generic;

public interface ITakeDamage
{
    void TakeDamage();

    void TakeDamage(float _damage);
    
    void TakeDamage(float _damage, string _type);
}
