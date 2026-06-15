using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryTransitionManager : MonoBehaviour
{
    public void ContinueToLibrary()
    {
        PlayerPrefs.SetString("LastScene", "LibraryScene");
PlayerPrefs.SetInt("UnlockedChapter", Mathf.Max(PlayerPrefs.GetInt("UnlockedChapter", 1), 5));
PlayerPrefs.Save();

SceneManager.LoadScene("LibraryScene");
    }
}