using UnityEngine;
using TMPro;

public class ListeningMatchingManager : MonoBehaviour
{
    public AudioSource audioSource;

    public TMP_Dropdown redSunglassesDropdown;
    public TMP_Dropdown blueCapDropdown;
    public TMP_Dropdown blackJacketDropdown;

    public TextMeshProUGUI feedbackText;

    public GameObject listeningTaskPanel;
    public GameObject nextTaskPanel;

    void Start()
    {
        if (nextTaskPanel != null)
        {
            nextTaskPanel.SetActive(false);
        }
    }

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

    public void CheckMatches()
    {
        string redSunglassesAnswer = redSunglassesDropdown.options[redSunglassesDropdown.value].text;
        string blueCapAnswer = blueCapDropdown.options[blueCapDropdown.value].text;
        string blackJacketAnswer = blackJacketDropdown.options[blackJacketDropdown.value].text;

        if (redSunglassesAnswer == "Choose..." ||
            blueCapAnswer == "Choose..." ||
            blackJacketAnswer == "Choose...")
        {
            feedbackText.text = "Please choose a price for every item.";
            return;
        }

        bool redSunglassesCorrect = redSunglassesAnswer == "15 pounds";
        bool blueCapCorrect = blueCapAnswer == "23 pounds";
        bool blackJacketCorrect = blackJacketAnswer == "67 pounds";

        if (redSunglassesCorrect && blueCapCorrect && blackJacketCorrect)
        {
            feedbackText.text = "Excellent listening! All prices are correct.";
            ProgressHelper.SetMissionProgress("CostumeProgress", 2);

            if (nextTaskPanel != null)
            {
                Invoke("OpenNextTask", 1.5f);
            }
        }
        else
        {
            feedbackText.text = "Some prices are not correct. Listen again carefully.";
        }
    }

    void OpenNextTask()
    {
        listeningTaskPanel.SetActive(false);

        if (nextTaskPanel != null)
        {
            nextTaskPanel.SetActive(true);
        }
    }
}