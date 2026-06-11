using UnityEngine;
using UnityEngine.SceneManagement;

public class LibraryTransitionManager : MonoBehaviour
{
    public void ContinueToLibrary()
    {
        PlayerPrefs.SetString("LastScene", "LibraryScene");
        PlayerPrefs.Save();

        SceneManager.LoadScene("LibraryScene");
    }
}