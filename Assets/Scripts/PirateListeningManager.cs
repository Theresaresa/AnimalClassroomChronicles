using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PirateListeningManager : MonoBehaviour
{
    public AudioSource audioSource;

    public TMP_InputField pirateNameInput;
    public TextMeshProUGUI feedbackText;

    public void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            feedbackText.text = "Audio is missing.";
        }
    }

    public void CheckPirate()
    {
        string answer = pirateNameInput.text.ToLower().Trim();

        if (answer == "bane")
        {
            feedbackText.text = "Excellent detective work! You found the correct pirate.";
            ProgressHelper.SetMissionProgress("HarborProgress", 1);
            Invoke("GoToBaneScene", 2f);
        }
        else
        {
            feedbackText.text = "Not quite. Listen again and check the name tag carefully.";
        }
    }

    void GoToBaneScene()
    {
        PlayerPrefs.SetString("LastScene", "HarborBaneScene");
        PlayerPrefs.Save();

        SceneManager.LoadScene("HarborBaneScene");
    }
}