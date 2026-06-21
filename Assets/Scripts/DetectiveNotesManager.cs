using UnityEngine;
using TMPro;

public class DetectiveNotesManager : MonoBehaviour
{
    public TMP_InputField note1Input;
    public TMP_InputField note2Input;
    public TMP_InputField note3Input;
    public TMP_InputField note4Input;
    public TMP_InputField note5Input;
    public TMP_InputField note6Input;

    public TextMeshProUGUI feedbackText;

    public GameObject detectiveNotesPanel;
    public GameObject secretWordPanel;

    public void CheckNotes()
    {
        string answer1 = CleanAnswer(note1Input.text);
        string answer2 = CleanAnswer(note2Input.text);
        string answer3 = CleanAnswer(note3Input.text);
        string answer4 = CleanAnswer(note4Input.text);
        string answer5 = CleanAnswer(note5Input.text);
        string answer6 = CleanAnswer(note6Input.text);

        bool allCorrect =
            answer1 == "teaches" &&
            answer2 == "felt" &&
            answer3 == "is looking" &&
            answer4 == "asks" &&
            answer5 == "took" &&
            answer6 == "was";

        if (allCorrect)
        {
            feedbackText.text =
                "Excellent detective work! The notes helped you think clearly. Have a closer look at the bookshelves.";
            ProgressHelper.SetMissionProgress("LibraryProgress", 2);
            Invoke("OpenSecretWordPanel", 2f);
        }
        else
        {
            feedbackText.text =
                "Some notes are not correct yet. Look carefully at the signal words.";
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.ToLower().Trim();

        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace("!", "");
        answer = answer.Replace("?", "");

        while (answer.Contains("  "))
        {
            answer = answer.Replace("  ", " ");
        }

        return answer;
    }

    void OpenSecretWordPanel()
    {
        detectiveNotesPanel.SetActive(false);

        if (secretWordPanel != null)
        {
            secretWordPanel.SetActive(true);
        }
    }
}