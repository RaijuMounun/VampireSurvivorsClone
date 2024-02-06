using System.Reflection.Emit;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponManager))]
public class EditorWeaponManager : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WeaponManager weaponManager = (WeaponManager)target;
        weaponManager.activeWeapon = (Weapon)EditorGUILayout.ObjectField("Active Weapon", weaponManager.activeWeapon, typeof(Weapon), true);

        GUILayout.Space(30);
        GUILayout.Label("Select Weapon");

        // Add three buttons
        if (GUILayout.Button("Pistol"))
        {
            weaponManager.activeWeapon = weaponManager.weapons[0];
            weaponManager.weapons[0].gameObject.SetActive(true);
            weaponManager.weapons[1].gameObject.SetActive(false);
            weaponManager.weapons[2].gameObject.SetActive(false);
        }

        if (GUILayout.Button("Minigun"))
        {
            weaponManager.activeWeapon = weaponManager.weapons[1];
            weaponManager.weapons[0].gameObject.SetActive(false);
            weaponManager.weapons[1].gameObject.SetActive(true);
            weaponManager.weapons[2].gameObject.SetActive(false);
        }

        if (GUILayout.Button("Shotgun"))
        {
            weaponManager.activeWeapon = weaponManager.weapons[2];
            weaponManager.weapons[0].gameObject.SetActive(false);
            weaponManager.weapons[1].gameObject.SetActive(false);
            weaponManager.weapons[2].gameObject.SetActive(true);
        }
    }
}
