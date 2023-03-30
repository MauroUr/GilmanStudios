using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacter
{
    Transform transform { get; }
    public void TakeDamage(int damage);
}
