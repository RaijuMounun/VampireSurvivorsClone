using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    WeaponManager _weaponManager;
    [SerializeField, Range(0, 5)] float bulletLifeTime = 3f;
    private void Awake() => _weaponManager = WeaponManager.Instance;
    private void OnEnable() => StartCoroutine(BulletLifeTime());

    public void ReturnBullet()
    {
        StopAllCoroutines();
        //transform.parent = _weaponManager.bulletPrefab.transform;
        transform.position = _weaponManager.transform.position;
        _weaponManager.playerBulletPool.Add(gameObject);
        gameObject.SetActive(false);
    }

    IEnumerator BulletLifeTime()
    {
        yield return Helpers.GetWait(bulletLifeTime);
        ReturnBullet();
    }
}
