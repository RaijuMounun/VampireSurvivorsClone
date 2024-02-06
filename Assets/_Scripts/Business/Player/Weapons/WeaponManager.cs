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
        if (activeWeapon.TryGetComponent(out IWeapon weapon)) weapon.Shoot();
        firing = true;
    }

    void Reload()
    {
        if (!Input.GetKeyDown(KeyCode.R)) return;
        if (activeWeapon.TryGetComponent(out IWeapon weapon)) StartCoroutine(weapon.Reload());
    }

    public void UpdateAmmoBulletText(Weapon weapon)
    {
        weapon.currentAmmo--;
        BulletCanvas.Instance.UpdateBulletCount(weapon.currentAmmo, weapon.maxAmmo);
        if (weapon.currentAmmo <= 0) StartCoroutine(weapon.Reload());
    }
}

interface IWeapon
{
    void Shoot();
    IEnumerator Reload();
}
