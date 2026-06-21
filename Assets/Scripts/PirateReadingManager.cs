using UnityEngine;
using TMPro;

public class PirateReadingManager : MonoBehaviour
{
    public TMP_Dropdown statement1Dropdown;
    public TMP_Dropdown statement2Dropdown;
    public TMP_Dropdown statement3Dropdown;
    public TMP_Dropdown statement4Dropdown;
    public TMP_Dropdown statement5Dropdown;

    public TextMeshProUGUI feedbackText;

    public GameObject readingMissionPanel;
    public GameObject instrumentPuzzlePanel;

    public void CheckAnswers()
    {
        string answer1 = statement1Dropdown.options[statement1Dropdown.value].text;
        string answer2 = statement2Dropdown.options[statement2Dropdown.value].text;
        string answer3 = statement3Dropdown.options[statement3Dropdown.value].text;
        string answer4 = statement4Dropdown.options[statement4Dropdown.value].text;
        string answer5 = statement5Dropdown.options[statement5Dropdown.value].text;

        if (answer1 == "Choose..." ||
            answer2 == "Choose..." ||
            answer3 == "Choose..." ||
            answer4 == "Choose..." ||
            answer5 == "Choose...")
        {
            feedbackText.text = "Please choose True or False for every sentence.";
            return;
        }

        bool allCorrect =
            answer1 == "True" &&
            answer2 == "False" &&
            answer3 == "True" &&
            answer4 == "False" &&
            answer5 == "True";

        if (allCorrect)
        {
            feedbackText.text = "Great reading! Bane trusts you more now.";
            ProgressHelper.SetMissionProgress("HarborProgress", 2);
            Invoke("OpenInstrumentPuzzle", 2f);
        }
        else
        {
            feedbackText.text = "Some answers are not correct yet. Read Bane's story again.";
        }
    }

    void OpenInstrumentPuzzle()
    {
        readingMissionPanel.SetActive(false);

        if (instrumentPuzzlePanel != null)
        {
            instrumentPuzzlePanel.SetActive(true);
        }
    }
}