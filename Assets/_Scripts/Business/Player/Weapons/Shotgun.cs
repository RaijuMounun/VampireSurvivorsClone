using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon, IWeapon
{
    int maxAmmo, currentAmmo;
    [Range(2, 10)]
    public int bulletPerShot = 3;
    [SerializeField] int distributionDegree = 60;


    public override void Start()
    {
        base.Start();
        maxAmmo = weaponSO.maxAmmo;
        currentAmmo = weaponSO.currentAmmo;
    }

    public void Shoot()
    {
        if (reloading) return;
        if (weaponM.playerBulletPool.Count == 0) return;
        if (coolDown) return;
        for (int i = 0; i < bulletPerShot; i++)
        {

            var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
            bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);

            //Distribution of bullets
            bullet.transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                (transform.rotation.eulerAngles.y - (distributionDegree / 2)) + ((distributionDegree / (bulletPerShot - 1)) * i),
                transform.rotation.eulerAngles.z);

            //Firing the bullet
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * weaponSO.bulletSpeed;

            //Updating the bullet pool counter
            weaponM.playerBulletPoolCounter++;
            if (weaponM.playerBulletPoolCounter == weaponM.playerBulletPool.Count) weaponM.playerBulletPoolCounter = 0;
        }

        currentAmmo--;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        if (currentAmmo <= 0) StartCoroutine(Reload());
        StartCoroutine(CoolDown(1 / weaponSO.fireRate));
    }

    public IEnumerator Reload()
    {
        reloading = true;
        yield return Helpers.GetWait(weaponSO.reloadTime);
        currentAmmo = maxAmmo;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        reloading = false;
    }
}
