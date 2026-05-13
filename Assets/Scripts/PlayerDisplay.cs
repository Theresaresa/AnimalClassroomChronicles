using UnityEngine;
using TMPro;

public class PlayerDisplay : MonoBehaviour
{
    public TextMeshProUGUI avatarText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string selectedAvatar = PlayerPrefs.GetString("SelectedAvatar", "None");
        if (avatarText != null)
        {
            avatarText.text = "Avatar: " + selectedAvatar;
        }
        else {
            Debug.LogWarning("avatarText ist nicht verbunden"); 
        }
    }
}
