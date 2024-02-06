using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "New Player Weapon")]
public class SO_PlayerWeapons : ScriptableObject
{
    public int damage;
    public float fireRate;
    public float bulletSpeed;
    public float bulletLifeTime;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;

}
