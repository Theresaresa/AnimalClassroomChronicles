using UnityEngine;
using TMPro;

public class PirateListeningManager : MonoBehaviour
{
    public AudioSource audioSource;

    public TMP_InputField pirateNameInput;
    public TextMeshProUGUI feedbackText;

    public GameObject listeningMissionPanel;
    public GameObject readingMissionPanel;

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

            Invoke("OpenReadingMission", 2f);
        }
        else
        {
            feedbackText.text = "Not quite. Listen again and check the name tag carefully.";
        }
    }

    void OpenReadingMission()
    {
        listeningMissionPanel.SetActive(false);

        if (readingMissionPanel != null)
        {
            readingMissionPanel.SetActive(true);
        }
    }
}