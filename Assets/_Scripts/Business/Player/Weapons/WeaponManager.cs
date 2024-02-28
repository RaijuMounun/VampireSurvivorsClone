using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : PersistentSingleton<WeaponManager>
{
    /*[HideInInspector]*/
    public IWeapon activeWeapon;
    public Player player;
    public Transform playerMouse;
    public List<Weapon> weapons = new List<Weapon>();

    [Space(10), Header("Bullet Pool")]
    public GameObject bulletPrefab;
    public List<GameObject> playerBulletPool = new List<GameObject>();
    public Transform playerBulletParent;
    public int playerBulletPoolCounter = 0, playerBulletPoolSize = 30;



    private void Start()
    {
        Helpers.MakePool(bulletPrefab, playerBulletPoolSize, playerBulletParent, playerBulletPool);
        player = PlayerManager.Instance.activeChar;
        activeWeapon = weapons[0].weaponSO;
    }
}



