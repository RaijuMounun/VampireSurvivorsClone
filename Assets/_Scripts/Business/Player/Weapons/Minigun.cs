using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Weapon, IWeapon
{
    [SerializeField] float warmUpTime;
    [SerializeField] int maxAmmo, currentAmmo;
    Coroutine firingCoroutine;
    float cooldownTime;


    public override void Start()
    {
        base.Start();
        maxAmmo = weaponSO.maxAmmo;
        currentAmmo = weaponSO.currentAmmo;
        cooldownTime = 1 / weaponSO.fireRate;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
    }

    public override void Update()
    {
        base.Update();
    }

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

        //update ammo and bullet count text
        currentAmmo--;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        if (currentAmmo <= 0) StartCoroutine(Reload());

        //cooldown
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
