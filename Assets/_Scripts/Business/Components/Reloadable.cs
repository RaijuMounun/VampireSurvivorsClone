using UnityEngine;
using UnityEngine.Events;

public class Reloadable : MonoBehaviour
{
    Weapon weapon;
    private void Awake() => weapon = GetComponent<Weapon>();
    void Update() => weapon.Reload();
}
