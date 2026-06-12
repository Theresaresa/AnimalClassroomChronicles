using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button continueButton;
    public Button chapterSelectButton;

    void Start()
    {
        bool hasSaveGame = PlayerPrefs.HasKey("LastScene");

        continueButton.interactable = hasSaveGame;
        chapterSelectButton.interactable = true;
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt("UnlockedChapter", 1);
        PlayerPrefs.SetString("LastScene", "AvatarSelection");
        PlayerPrefs.Save();

        SceneManager.LoadScene("AvatarSelection");
    }

    public void ContinueGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "AvatarSelection");
        SceneManager.LoadScene(lastScene);
    }

    public void OpenChapterSelect()
    {
        if (!PlayerPrefs.HasKey("UnlockedChapter"))
        {
            PlayerPrefs.SetInt("UnlockedChapter", 1);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("ChapterSelectScene");
    }

    public void QuitGame()
    {
        Debug.Log("Game was closed.");
        Application.Quit();
    }
}