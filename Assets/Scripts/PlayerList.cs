using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewPlayerList", menuName = "Values/PlayerList")]
public class PlayerList : ScriptableObject
{
    public List<MainMenu.MainMenuPlayer> list = new List<MainMenu.MainMenuPlayer>();
}
