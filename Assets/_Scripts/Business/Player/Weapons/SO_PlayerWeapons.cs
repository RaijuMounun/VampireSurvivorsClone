using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "New Player Weapon")]
public abstract class SO_PlayerWeapons : ScriptableObject, IWeapon
{
    public int damage;

    [Tooltip("Bullets per second")]
    public float fireRate;
    public float FireDelay => 1 / fireRate;
    public float bulletSpeed;
    public float bulletLifeTime;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public bool isReloading;
    public bool isInCooldown;
    public bool canFire = true;
    public WeaponManager weaponM;
    public Weapon weapon;

    public abstract void Shoot();
    public IEnumerator CoolDown(float time)
    {
        canFire = false;
        yield return Helpers.GetWait(time);
        canFire = true;
    }

    public IEnumerator Reload()
    {
        canFire = false;
        yield return Helpers.GetWait(reloadTime);
        currentAmmo = maxAmmo;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        canFire = true;
    }

}
