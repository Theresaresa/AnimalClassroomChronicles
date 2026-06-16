using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAvatarUI : MonoBehaviour
{
    public Image avatarImage;
    public TextMeshProUGUI avatarNameText;

    public Sprite owlSprite;
    public Sprite foxSprite;
    public Sprite bearSprite;
    public Sprite capybaraSprite;
    public Sprite crocodileSprite;

    void Start()
    {
        string selectedAvatar = PlayerPrefs.GetString("SelectedAvatar", "Owl");

        if (selectedAvatar == "Owl")
        {
            avatarImage.sprite = owlSprite;
            avatarNameText.text = "Detective Owl";
        }
        else if (selectedAvatar == "Fox")
        {
            avatarImage.sprite = foxSprite;
            avatarNameText.text = "Detective Fox";
        }
        else if (selectedAvatar == "Bear")
        {
            avatarImage.sprite = bearSprite;
            avatarNameText.text = "Detective Bear";
        }
        else if (selectedAvatar == "Capybara")
        {
            avatarImage.sprite = capybaraSprite;
            avatarNameText.text = "Detective Capybara";
        }
        else if (selectedAvatar == "Crocodile")
        {
            avatarImage.sprite = crocodileSprite;
            avatarNameText.text = "Detective Crocodile";
        }
    }
}