using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerManager))]
public class EditorPlayerManager : Editor
{
    PlayerManager _playerManager;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        _playerManager = (PlayerManager)target;
        _playerManager.activeChar = (Player)EditorGUILayout.ObjectField("Active Player", _playerManager.activeChar, typeof(PlayerMovement), true);

        GUILayout.Space(30);
        GUILayout.Label("Select Weapon");

        // Add three buttons
        if (GUILayout.Button("Petrov")) SetActiveChar(0);
        if (GUILayout.Button("Tonquedec")) SetActiveChar(1);
        if (GUILayout.Button("Subritzky")) SetActiveChar(2);
    }
    void SetActiveChar(int index)
    {
        for (int i = 0; i < _playerManager.chars.Count; i++)
            _playerManager.chars[i].gameObject.SetActive(false);

        _playerManager.activeChar = _playerManager.chars[index];
        _playerManager.chars[index].gameObject.SetActive(true);
    }
}
