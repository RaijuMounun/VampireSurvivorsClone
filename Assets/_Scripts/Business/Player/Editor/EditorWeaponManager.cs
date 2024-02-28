using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WeaponManager))]
public class EditorWeaponManager : Editor
{
    WeaponManager _weaponManager;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _weaponManager = (WeaponManager)target;
        //_weaponManager.activeWeapon = (IWeapon)EditorGUILayout.ObjectField("Active Weapon", _weaponManager.activeWeapon, typeof(IWeapon), true);

        GUILayout.Space(30);
        GUILayout.Label("Select Weapon");

        // Add three buttons
        if (GUILayout.Button("Pistol")) SetActiveWeapon(0);
        if (GUILayout.Button("Minigun")) SetActiveWeapon(1);
        if (GUILayout.Button("Shotgun")) SetActiveWeapon(2);
    }
    void SetActiveWeapon(int index)
    {
        for (int i = 0; i < _weaponManager.weapons.Count; i++)
            _weaponManager.weapons[i].gameObject.SetActive(false);

        //_weaponManager.activeWeapon = _weaponManager.weapons[index];
        _weaponManager.weapons[index].gameObject.SetActive(true);
    }
}
