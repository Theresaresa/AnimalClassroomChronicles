using UnityEngine;
using UnityEngine.SceneManagement; //nötig für das Laden von Szenen


public class MainMenuController : MonoBehaviour
{
    // Lädt die Szene "AvatarSelection", wenn der Start-Button gedrückt wird
    public void StartGame()
    {
        SceneManager.LoadScene("AvatarSelection");
    }

    // Beendet das Spiel, wenn der Quit-Button gedrückt wird
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Spiel wurde beendet.");
        
    }
}
