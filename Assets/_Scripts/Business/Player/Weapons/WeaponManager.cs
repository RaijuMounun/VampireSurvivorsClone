using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : PersistentSingleton<WeaponManager>
{
    public GameObject bulletPrefab;
    public List<GameObject> playerBulletPool = new List<GameObject>();
    public Transform playerBulletParent;
    public int playerBulletPoolCounter = 0, playerBulletPoolSize = 30;
    public Weapon activeWeapon;


    private void Start() => Helpers.MakePool(bulletPrefab, playerBulletPoolSize, playerBulletParent, playerBulletPool);

    private void Update()
    {
        Shoot();
        Reload();
    }

    void Shoot()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        if (activeWeapon.TryGetComponent(out IWeapon weapon)) weapon.Shoot();
    }
    void Reload()
    {
        if (!Input.GetKeyDown(KeyCode.R)) return;
        if (activeWeapon.TryGetComponent(out IWeapon weapon)) StartCoroutine(weapon.Reload());
    }
}
