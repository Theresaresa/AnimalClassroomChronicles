using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalEndingManager : MonoBehaviour
{
    public GameObject confessionPanel;
    public GameObject certificatePanel;

    public Image frogmanPortrait;

    public Sprite normalSprite;
    public Sprite arrestedSprite;

    public void ArrestMrsFrogman()
    {
        frogmanPortrait.sprite = arrestedSprite;

        confessionPanel.SetActive(false);
        certificatePanel.SetActive(true);

        PlayerPrefs.SetInt("UnlockedChapter", 5);
        PlayerPrefs.SetString("LastScene", "MainMenu");
        PlayerPrefs.Save();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}