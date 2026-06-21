using UnityEngine;
using TMPro;

public class FinalAccusationManager : MonoBehaviour
{
    public TMP_InputField culpritInput;
    public TextMeshProUGUI feedbackText;

    public GameObject accusationPanel;
    public GameObject confessionPanel;

    public void CheckCulprit()
    {
        string answer =
            culpritInput.text
            .ToLower()
            .Trim();

        bool correct =
            answer == "frogman" ||
            answer == "mrs frogman" ||
            answer == "fiona frogman" ||
            answer == "fiona";

        if(correct)
        {
            feedbackText.text =
                "Correct! You solved the mystery.";
                ProgressHelper.CompleteChapter(
                    "LibraryProgress",
                    "LibraryBadge",
                    "GoldenSpeakingBallUnlocked",
                    5
                );

            Invoke("OpenConfession", 2f);
        }
        else
        {
            feedbackText.text =
                "That suspect does not match all the clues.";
        }
    }

    void OpenConfession()
    {
        accusationPanel.SetActive(false);

        if(confessionPanel != null)
        {
            confessionPanel.SetActive(true);
        }
    }
}