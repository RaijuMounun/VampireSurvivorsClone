using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects", menuName = "New Shotgun")]
public class Shotgun : SO_PlayerWeapons
{
    [Range(2, 10)]
    [SerializeField] int _bulletPerShot = 3;
    [SerializeField] int _distributionDegree = 60;

    public override void Shoot()
    {
        if (!canFire) return;


        for (int i = 0; i < _bulletPerShot; i++)
        {

            var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
            bullet.transform.SetPositionAndRotation(weapon.transform.position, weapon.transform.rotation);

            //Distribution of bullets
            bullet.transform.rotation = Quaternion.Euler(
                weapon.transform.rotation.eulerAngles.x,
                weapon.transform.rotation.eulerAngles.y - (_distributionDegree / 2) + (_distributionDegree / (_bulletPerShot - 1) * i),
                weapon.transform.rotation.eulerAngles.z);

            //Firing the bullet
            bullet.transform.SetParent(null);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

            //Updating the bullet pool counter
            weaponM.playerBulletPoolCounter++;
            if (weaponM.playerBulletPoolCounter == weaponM.playerBulletPool.Count) weaponM.playerBulletPoolCounter = 0;
        }

        weapon.UpdateAmmoAndBulletText(this);

        //Cooldown
        weapon.GetCooldown(1 / fireRate);
    }
}
