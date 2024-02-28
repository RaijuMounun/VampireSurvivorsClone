using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    WeaponManager weaponM;
    private void Start() => weaponM = WeaponManager.Instance;
    void FixedUpdate() => transform.LookAt(weaponM.playerMouse);
}
