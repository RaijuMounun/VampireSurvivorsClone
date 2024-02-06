using UnityEngine;

public class Minigun : Weapon, IWeapon
{


    public void Shoot()
    {
        if (reloading) return;
        if (coolDown) return;

        //pick bullet and increase counter
        var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
        weaponM.playerBulletPoolCounter++;
        if (weaponM.playerBulletPoolCounter == weaponM.playerBulletPool.Count) weaponM.playerBulletPoolCounter = 0;

        //set up and fire bullet
        bullet.SetActive(true);
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * weaponSO.bulletSpeed;

        weaponM.UpdateAmmoBulletText(this);

        //cooldown
        StartCoroutine(CoolDown(1 / weaponSO.fireRate));
    }
}
