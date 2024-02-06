using System.Collections;
using UnityEngine;

public class Pistol : Weapon, IWeapon
{
    int maxAmmo, currentAmmo;

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

        var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
        weaponM.playerBulletPoolCounter++;
        if (weaponM.playerBulletPoolCounter == weaponM.playerBulletPool.Count) weaponM.playerBulletPoolCounter = 0;

        bullet.SetActive(true);
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * weaponSO.bulletSpeed;
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
