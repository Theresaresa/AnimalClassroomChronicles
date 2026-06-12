using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterSelectManager : MonoBehaviour
{
    public Button chapter1Button;
    public Button chapter2Button;
    public Button chapter3Button;
    public Button chapter4Button;
    public Button chapter5Button;

    void Start()
    {
        int unlockedChapter = PlayerPrefs.GetInt("UnlockedChapter", 1);

        chapter1Button.interactable = unlockedChapter >= 1;
        chapter2Button.interactable = unlockedChapter >= 2;
        chapter3Button.interactable = unlockedChapter >= 3;
        chapter4Button.interactable = unlockedChapter >= 4;
        chapter5Button.interactable = unlockedChapter >= 5;
    }

    public void OpenChapter1()
    {
        SaveAndLoad("ClassroomScene");
    }

    public void OpenChapter2()
    {
        SaveAndLoad("CafeteriaScene");
    }

    public void OpenChapter3()
    {
        SaveAndLoad("CostumeShopScene");
    }

    public void OpenChapter4()
    {
        SaveAndLoad("HarborScene");
    }

    public void OpenChapter5()
    {
        SaveAndLoad("LibraryScene");
    }

    void SaveAndLoad(string sceneName)
    {
        PlayerPrefs.SetString("LastScene", sceneName);
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneName);
    }
}