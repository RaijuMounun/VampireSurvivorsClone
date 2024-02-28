using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : PersistentSingleton<PlayerManager>
{
    public Player activePlayer;
    [HideInInspector] public Player activeChar;
    public List<Player> chars = new List<Player>();

    private void Start()
    {
        activePlayer = activeChar;
    }

}
