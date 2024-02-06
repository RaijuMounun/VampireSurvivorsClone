using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform playerMouse;
    public SO_PlayerWeapons weaponSO;
    protected WeaponManager weaponM;
    protected bool reloading;
    private void Start()
    {
        playerMouse = PlayerMouse.Instance.transform;
        weaponM = WeaponManager.Instance;
    }
    private void Update() => transform.LookAt(playerMouse);
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
    }
}

interface IWeapon
{
    void Shoot();
    void ReturnBullet(GameObject bullet);
    void ReturnBullet(GameObject bullet, float time);
    IEnumerator Reload();
}