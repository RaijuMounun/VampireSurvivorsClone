using System.Collections.Generic;
using UnityEngine;

public class Player : PersistentSingleton<Player>
{
    public int exp;

    public void AddExp(int expValue)
    {
        exp += expValue;
    }
}
