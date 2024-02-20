using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    WeaponManager weaponM;
    public SO_PlayerWeapons weaponSO;


    private void Start()
    {
        weaponM = WeaponManager.Instance;
        BulletCanvas.Instance.UpdateBulletCount(weaponSO.currentAmmo, weaponSO.maxAmmo);
        weaponSO.weapon = this;
        weaponSO.weaponM = weaponM;
        print(weaponSO.name);
        weaponSO.canFire = true;
        transform.parent = weaponM.player.transform;
    }

    public virtual void Update()
    {
        transform.LookAt(weaponM.playerMouse);
        if (Input.GetButton("Fire1")) weaponSO.Shoot();
        if (Input.GetKeyDown(KeyCode.R)) StartCoroutine(weaponSO.Reload());
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

