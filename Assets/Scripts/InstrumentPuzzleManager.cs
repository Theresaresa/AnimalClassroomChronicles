using UnityEngine;
using TMPro;

public class InstrumentPuzzleManager : MonoBehaviour
{
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;
    public TMP_InputField input4;

    public TextMeshProUGUI feedbackText;

    public GameObject instrumentPuzzlePanel;
    public GameObject canCantPanel;

    public void CheckInstruments()
    {
        string answer1 = CleanAnswer(input1.text);
        string answer2 = CleanAnswer(input2.text);
        string answer3 = CleanAnswer(input3.text);
        string answer4 = CleanAnswer(input4.text);

        bool allCorrect =
            answer1 == "saxophone" &&
            answer2 == "drums" &&
            answer3 == "keyboard" &&
            answer4 == "guitar";

        if (allCorrect)
        {
            feedbackText.text = "Excellent! You solved the instrument puzzle.";
            Invoke("OpenCanCantPanel", 2f);
        }
        else
        {
            feedbackText.text = "Some instruments are not correct yet. Check the spelling carefully.";
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.ToLower().Trim();
        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace("!", "");
        answer = answer.Replace("?", "");
        return answer;
    }

    void OpenCanCantPanel()
    {
        instrumentPuzzlePanel.SetActive(false);

        if (canCantPanel != null)
        {
            canCantPanel.SetActive(true);
        }
    }
}