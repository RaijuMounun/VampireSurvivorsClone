using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponManager weaponM;
    public SO_PlayerWeapons weaponSO;


    private void Start()
    {
        weaponM = WeaponManager.Instance;
        weaponSO.weapon = this;
        weaponSO.weaponM = weaponM;
        weaponSO.canFire = true;
        weaponSO.isReloading = false;
        transform.parent = weaponM.player.transform;
        BulletCanvas.Instance.UpdateBulletCount(weaponSO.currentAmmo, weaponSO.maxAmmo);
    }

    public void Reload()
    {
        if (!Input.GetKeyDown(KeyCode.R)) return;
        StartCoroutine(weaponSO.Reload());
    }


    public void UpdateAmmoAndBulletText(SO_PlayerWeapons weapon)
    {
        weapon.currentAmmo--;
        BulletCanvas.Instance.UpdateBulletCount(weapon.currentAmmo, weapon.maxAmmo);
        if (weapon.currentAmmo <= 0) StartCoroutine(weapon.Reload());
    }

    public void GetCooldown(float time)
    {
        StartCoroutine(weaponSO.CoolDown(time));
    }
}

public interface IWeapon
{
    void Shoot();
    IEnumerator Reload();
}

