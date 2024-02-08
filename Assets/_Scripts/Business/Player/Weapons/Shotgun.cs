using UnityEngine;

public class Shotgun : Weapon, IWeapon
{
    [Range(2, 10)]
    [SerializeField] int _bulletPerShot = 3;
    [SerializeField] int _distributionDegree = 60;


    public void Shoot()
    {
        if (isReloading) return;
        if (isInCooldown) return;


        for (int i = 0; i < _bulletPerShot; i++)
        {

            var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);

            //Distribution of bullets
            bullet.transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y - (_distributionDegree / 2) + (_distributionDegree / (_bulletPerShot - 1) * i),
                transform.rotation.eulerAngles.z);

            //Firing the bullet
            bullet.transform.SetParent(null);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * weaponSO.bulletSpeed;

            //Updating the bullet pool counter
            weaponM.playerBulletPoolCounter++;
            if (weaponM.playerBulletPoolCounter == weaponM.playerBulletPool.Count) weaponM.playerBulletPoolCounter = 0;
        }

        weaponM.UpdateAmmoBulletText(this);

        //Cooldown
        StartCoroutine(CoolDown(1 / weaponSO.fireRate));
    }
}
