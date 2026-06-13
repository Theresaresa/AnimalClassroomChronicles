using UnityEngine;
using TMPro;

public class DiaryReadingManager : MonoBehaviour
{
    public TMP_Dropdown statement1Dropdown;
    public TMP_Dropdown statement2Dropdown;
    public TMP_Dropdown statement3Dropdown;
    public TMP_Dropdown statement4Dropdown;
    public TMP_Dropdown statement5Dropdown;

    public TextMeshProUGUI feedbackText;

    public GameObject diaryMissionPanel;
    public GameObject timelinePanel;

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
            answer2 == "True" &&
            answer3 == "False" &&
            answer4 == "False" &&
            answer5 == "True";

        if (allCorrect)
        {
            feedbackText.text = "Excellent reading! This diary gives you an important clue.";
            Invoke("OpenTimelinePanel", 2f);
        }
        else
        {
            feedbackText.text = "Some answers are not correct yet. Read the diary carefully again.";
        }
    }

    void OpenTimelinePanel()
    {
        diaryMissionPanel.SetActive(false);

        if (timelinePanel != null)
        {
            timelinePanel.SetActive(true);
        }
    }
}