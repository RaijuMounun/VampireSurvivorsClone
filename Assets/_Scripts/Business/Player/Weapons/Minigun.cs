using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : Weapon, IFullAutoWeapon
{
    [SerializeField] float warmUpTime;
    [SerializeField] int maxAmmo, currentAmmo;
    Coroutine firingCoroutine;


    public override void Start()
    {
        base.Start();
        maxAmmo = weaponSO.maxAmmo;
        currentAmmo = weaponSO.currentAmmo;
    }

    public override void Update()
    {
        base.Update();
        StopFiring();
    }

    public void Shoot()
    {
        firingCoroutine = StartCoroutine(FireAfterDelay(warmUpTime));
    }

    IEnumerator FireAfterDelay(float delay)
    {
        if (reloading) yield break;
        if (weaponM.playerBulletPool.Count == 0) yield break;
        if (coolDown) yield break;

        yield return Helpers.GetWait(delay);

        print("Firing");
        var bullet = weaponM.playerBulletPool[weaponM.playerBulletPoolCounter];
        weaponM.playerBulletPoolCounter++;
        if (weaponM.playerBulletPoolCounter == weaponM.playerBulletPool.Count) weaponM.playerBulletPoolCounter = 0;

        bullet.SetActive(true);
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * weaponSO.bulletSpeed;
        currentAmmo--;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        if (currentAmmo <= 0) StartCoroutine(Reload());
        coolDown = true;
        yield return Helpers.GetWait(2f);
        coolDown = false;
    }

    void StopFiring()
    {
        if (!Input.GetButtonUp("Fire1")) return;
        print("Stop firing");
        StopAllCoroutines();
        if (firingCoroutine != null) StopCoroutine(firingCoroutine);
        firingCoroutine = null;
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
