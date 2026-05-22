using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeCodeManager : MonoBehaviour
{
    public TextMeshProUGUI clueText;
    public TMP_InputField codeInputField;
    public TextMeshProUGUI feedbackText;
    public Button goToCostumeShopButton;

    private int currentStep = 0;

    private string[] clues =
    {
        "There are 35 apples.",
        "There are 47 carrots.",
        "There are 12 tomatoes.",
        "There are 15 loaves of bread."
    };

    private string[] answers =
    {
        "thirty-five",
        "forty-seven",
        "twelve",
        "fifteen"
    };

    void Start()
    {
        ShowClue();
        goToCostumeShopButton.gameObject.SetActive(false);
    }

    void ShowClue()
    {
        clueText.text = clues[currentStep];
        codeInputField.text = "";
        feedbackText.text = "";
    }

    public void CheckCode()
    {
        string answer = CleanAnswer(codeInputField.text);
        string correctAnswer = answers[currentStep];

        if (answer == correctAnswer)
        {
            currentStep++;

            if (currentStep < clues.Length)
            {
                feedbackText.text = "Correct! Next number.";
                Invoke("ShowClue", 1.0f);
            }
            else
            {
                feedbackText.text = "Great! The door unlocked. Ms Ladybug told you to go to Mr Whinnyham's shop and to bring him some food. He looked upset today. Maybe he knows something.";
                goToCostumeShopButton.gameObject.SetActive(true);
            }
        }
        else
        {
            if (answer.Contains("fourty"))
            {
                feedbackText.text = "Careful: 40 is spelled \"forty\", not \"fourty\".";
            }
            else if ((answer.Contains("thirty") || answer.Contains("forty")) && !answer.Contains("-"))
            {
                feedbackText.text = "Remember: numbers from 21 to 99 need a hyphen, for example thirty-five.";
            }
            else
            {
                feedbackText.text = "Check the spelling of the number word carefully.";
            }
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.ToLower().Trim();
        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace(" ", "");
        return answer;
    }

    public void GoToCostumeShop()
{
    SceneManager.LoadScene("CostumeShopScene");
}
}