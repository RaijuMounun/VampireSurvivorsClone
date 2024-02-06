using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public SO_PlayerWeapons weaponSO;
    protected WeaponManager weaponM;
    protected bool reloading;
    protected bool coolDown;


    public virtual void Start() => weaponM = WeaponManager.Instance;
    public virtual void Update() => transform.LookAt(weaponM.playerMouse);
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 10);
    }

    public IEnumerator CoolDown(float time)
    {
        coolDown = true;
        yield return Helpers.GetWait(time);
        coolDown = false;
    }
}

