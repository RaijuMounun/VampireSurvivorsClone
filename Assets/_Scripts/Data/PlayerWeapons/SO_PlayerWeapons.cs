using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "New Player Weapon")]
public class SO_PlayerWeapons : ScriptableObject
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

}
