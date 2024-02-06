using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public SO_PlayerWeapons weaponSO;
    protected WeaponTypeEnum weaponType;
    protected WeaponManager weaponM;
    protected bool reloading;
    protected bool coolDown;
    public int maxAmmo, currentAmmo;


    public virtual void Start()
    {
        weaponM = WeaponManager.Instance;
        maxAmmo = weaponSO.maxAmmo;
        currentAmmo = weaponSO.currentAmmo;
    }

    public virtual void Update() => transform.LookAt(weaponM.playerMouse);

    public IEnumerator CoolDown(float time)
    {
        coolDown = true;
        yield return Helpers.GetWait(time);
        coolDown = false;
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

public enum WeaponTypeEnum
{
    Pistol,
    Shotgun,
    Minigun
}

