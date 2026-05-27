using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        if (!PlayerPrefs.HasKey("LastScene"))
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteKey("LastScene");
        PlayerPrefs.DeleteKey("SelectedAvatar");
        PlayerPrefs.Save();

        SceneManager.LoadScene("AvatarSelection");
    }

    public void ContinueGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "AvatarSelection");
        SceneManager.LoadScene(lastScene);
    }

    public void QuitGame()
    {
        Debug.Log("Game was closed.");
        Application.Quit();
    }
}