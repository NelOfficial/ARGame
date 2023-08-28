using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public PlayerList playerList;

    [System.Serializable]
    public class MainMenuPlayer
    {
        public string name;
        public int character;
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
