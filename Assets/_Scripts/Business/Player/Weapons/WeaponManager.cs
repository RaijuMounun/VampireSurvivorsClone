using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : PersistentSingleton<WeaponManager>
{
    public GameObject bulletPrefab;
    public List<GameObject> playerBulletPool = new List<GameObject>();
    public Transform playerBulletParent;
    public int playerBulletPoolCounter = 0, playerBulletPoolSize = 30;
    public Weapon activeWeapon;
    Coroutine returnBulletCoroutine;
    public Transform playerMouse;
    public bool firing;


    private void Start() => Helpers.MakePool(bulletPrefab, playerBulletPoolSize, playerBulletParent, playerBulletPool);

    private void Update()
    {
        Shoot();
        Reload();
    }

    void Shoot()
    {
        if (!Input.GetButton("Fire1")) return;
        if (activeWeapon.TryGetComponent(out IWeapon semiWeapon)) semiWeapon.Shoot();
        firing = true;
    }

    void Reload()
    {
        if (!Input.GetKeyDown(KeyCode.R)) return;
        if (activeWeapon.TryGetComponent(out IWeapon semiWeapon)) StartCoroutine(semiWeapon.Reload());
        if (activeWeapon.TryGetComponent(out IWeapon autoWeapon)) StartCoroutine(autoWeapon.Reload());
    }

    public void ReturnBullet(GameObject bullet)
    {
        StopCoroutine(returnBulletCoroutine);
        bullet.SetActive(false);
        playerBulletPool.Add(bullet);
    }
    public void ReturnBullet(GameObject bullet, float delay)
    {
        returnBulletCoroutine = StartCoroutine(ReturnBulletWithDelay(bullet, delay));
    }
    private IEnumerator ReturnBulletWithDelay(GameObject bullet, float delay)
    {
        yield return Helpers.GetWait(delay);
        ReturnBullet(bullet);
    }
}

interface IWeapon
{
    void Shoot();
    IEnumerator Reload();
}
