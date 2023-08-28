using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    [SerializeField] Image characterImage;
    [SerializeField] Sprite[] characters;
    [SerializeField] TMP_InputField nicknameInputField;

    [SerializeField] int currentCharacter;

    private MainMenu menu;

    private void Awake()
    {
        menu = FindObjectOfType<MainMenu>();
    }

    public void SelectCharacter(int increment)
    {
        if (currentCharacter + increment <= characters.Length && currentCharacter + increment > 0)
        {
            currentCharacter += increment;
        }

        characterImage.sprite = characters[currentCharacter];
    }

    public void SetPlayer()
    {
        MainMenu.MainMenuPlayer player = new MainMenu.MainMenuPlayer();
        player.character = currentCharacter;
        player.name = nicknameInputField.text;

        menu.playerList.list.Add(player);
    }
}
