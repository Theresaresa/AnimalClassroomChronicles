using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AvatarSelectionController : MonoBehaviour
{
    public Button continueButton;
    public TextMeshProUGUI selectedAvatarText;

    private string selectedAvatar = "";

    void Start()
    {
        continueButton.interactable = false;

        if (selectedAvatarText != null)
        {
            selectedAvatarText.text = "No avatar selected yet.";
        }
    }

    public void SelectAvatar(string avatarName)
    {
        selectedAvatar = avatarName;

        Debug.Log("Selected avatar: " + selectedAvatar);

        PlayerPrefs.SetString("SelectedAvatar", selectedAvatar);
        PlayerPrefs.Save();

        continueButton.interactable = true;

        if (selectedAvatarText != null)
        {
            selectedAvatarText.text = "Selected avatar: " + selectedAvatar;
        }
    }

    public void ContinueToClassroom()
    {
        SceneManager.LoadScene("ClassroomScene");
    }
}