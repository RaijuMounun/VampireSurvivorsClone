using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "New Pistol")]
public class Pistol : SO_PlayerWeapons
{


    public override void Shoot()
    {
        if (!canFire) return;
        if (isReloading) return;

        //pick bullet and increase counter
        var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
        weaponM.playerBulletPoolCounter++;
        if (weaponM.playerBulletPoolCounter == weaponM.playerBulletPool.Count) weaponM.playerBulletPoolCounter = 0;

        //set up and fire bullet
        bullet.transform.SetParent(null);
        bullet.SetActive(true);
        bullet.transform.SetPositionAndRotation(weapon.transform.position, weapon.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = weapon.transform.forward * bulletSpeed;

        weapon.UpdateAmmoAndBulletText(this);

        //cooldown
        weapon.GetCooldown(1 / fireRate);
    }

}
