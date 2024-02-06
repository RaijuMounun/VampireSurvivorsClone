using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon, ISemiAutoWeapon
{



    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void ReturnBullet(GameObject bullet)
    {
        throw new System.NotImplementedException();
    }

    public void ReturnBullet(GameObject bullet, float time)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Reload()
    {
        throw new System.NotImplementedException();
    }
}
