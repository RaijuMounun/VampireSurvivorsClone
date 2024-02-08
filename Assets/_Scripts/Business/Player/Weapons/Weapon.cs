using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public SO_PlayerWeapons weaponSO;
    protected WeaponTypeEnum weaponType;
    protected WeaponManager weaponM;
    protected bool isReloading;
    protected bool isInCooldown;
    public int maxAmmo, currentAmmo;


    public virtual void Start()
    {
        weaponM = WeaponManager.Instance;
        maxAmmo = weaponSO.maxAmmo;
        currentAmmo = weaponSO.currentAmmo;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
    }

    public virtual void Update() => transform.LookAt(weaponM.playerMouse);

    public IEnumerator CoolDown(float time)
    {
        isInCooldown = true;
        yield return Helpers.GetWait(time);
        isInCooldown = false;
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return Helpers.GetWait(weaponSO.reloadTime);
        currentAmmo = maxAmmo;
        BulletCanvas.Instance.UpdateBulletCount(currentAmmo, maxAmmo);
        isReloading = false;
    }
}

public enum WeaponTypeEnum
{
    Pistol,
    Shotgun,
    Minigun
}

