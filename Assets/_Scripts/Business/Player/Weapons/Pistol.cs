using System.Collections;
using UnityEngine;

public class Pistol : Weapon, IWeapon
{
    int maxAmmo, currentAmmo;

    private void Start()
    {
        weaponM = WeaponManager.Instance;
        maxAmmo = weaponSO.maxAmmo;
        currentAmmo = weaponSO.currentAmmo;
    }


    public void Shoot()
    {
        if (reloading) return;
        if (weaponM.playerBulletPool.Count == 0) return;

        var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
        weaponM.playerBulletPoolCounter++;
        if (weaponM.playerBulletPoolCounter == 30) weaponM.playerBulletPoolCounter = 0;
        //return bullet

        bullet.SetActive(true);
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * weaponSO.bulletSpeed;
        currentAmmo--;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        if (currentAmmo <= 0) StartCoroutine(Reload());
    }

    #region ReturnBullet
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        weaponM.playerBulletPool.Add(bullet);
    }
    public void ReturnBullet(GameObject bullet, float time)
    {
        StartCoroutine(ReturnBulletWithDelay(bullet, time));
    }
    private IEnumerator ReturnBulletWithDelay(GameObject bullet, float time)
    {
        yield return Helpers.GetWait(time);
        ReturnBullet(bullet);
    }
    #endregion

    public IEnumerator Reload()
    {
        reloading = true;
        yield return Helpers.GetWait(weaponSO.reloadTime);
        currentAmmo = maxAmmo;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        reloading = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
    }
}
