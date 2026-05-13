using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //nötig für das Laden von Szenen

public class AvatarSelectionController : MonoBehaviour
{
    public Button continueButton;

    private string selectAvatar = "";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        continueButton.interactable = false; // Continue-Button zu Beginn deaktivieren
    }

    public void SelectAvatar(string avatarName)
    {
        selectAvatar = avatarName;
        Debug.Log("Gewählter Avatar: " + selectAvatar);

        PlayerPrefs.SetString("SelectedAvatar", selectAvatar); // Gewählten Avatar in PlayerPrefs speichern
        continueButton.interactable = true; // Continue-Button aktivieren, wenn ein Avatar ausgewählt wurde
    }
    // Update is called once per frame
    public void ContinueToClassroom()
    {
        SceneManager.LoadScene("ClassroomScene");
    }
}
