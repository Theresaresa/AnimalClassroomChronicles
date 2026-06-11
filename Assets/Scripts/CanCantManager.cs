using UnityEngine;
using TMPro;

public class CanCantManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInputField;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI progressText;

    public GameObject canCantPanel;
    public GameObject finalBaneCluePanel;

    private int currentQuestion = 0;

    private string[] questions =
    {
        "Can you wiggle your ears?",
        "Can you stand on your hands?",
        "Can you bake a cake?",
        "Can you sing?",
        "Can you touch your nose with your tongue?"
    };

    void Start()
    {
        ShowQuestion();

        if (finalBaneCluePanel != null)
        {
            finalBaneCluePanel.SetActive(false);
        }
    }

    void ShowQuestion()
    {
        questionText.text = questions[currentQuestion];
        progressText.text = "Question " + (currentQuestion + 1) + " / " + questions.Length;
        feedbackText.text = "";
        answerInputField.text = "";
    }

    public void CheckAnswer()
    {
        string originalAnswer = answerInputField.text.Trim();

        if (originalAnswer == "")
        {
            feedbackText.text = "Please write an answer.";
            return;
        }

        string cleanedAnswer = CleanAnswer(originalAnswer);

        bool validAnswer =
            cleanedAnswer == "yes i can" ||
            cleanedAnswer == "no i cant" ||
            cleanedAnswer == "no i cannot";

        if (validAnswer)
        {
            if (!char.IsUpper(originalAnswer[0]))
            {
                feedbackText.text = "Remember: sentences start with a capital letter.";
                return;
            }

            if (originalAnswer.Contains(" i "))
            {
                feedbackText.text = "Remember: \"I\" is always written with a capital letter.";
                return;
            }

            if (cleanedAnswer == "no i cant" &&
                !originalAnswer.Contains("can't") &&
                !originalAnswer.Contains("can’t"))
            {
                feedbackText.text = "Check your spelling: write \"can't\" with an apostrophe, or use \"cannot\".";
                return;
            }

            feedbackText.text = "Good answer!";

            currentQuestion++;

            if (currentQuestion < questions.Length)
            {
                Invoke("ShowQuestion", 1.0f);
            }
            else
            {
                feedbackText.text = "Great! Bane feels much calmer now.";
                Invoke("OpenFinalBaneClue", 2f);
            }
        }
        else
        {
            feedbackText.text = "Use: Yes I can / No I can't / No I cannot.";
        }
    }

    void OpenFinalBaneClue()
    {
        canCantPanel.SetActive(false);

        if (finalBaneCluePanel != null)
        {
            finalBaneCluePanel.SetActive(true);
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.ToLower().Trim();

        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace("!", "");
        answer = answer.Replace("?", "");
        answer = answer.Replace("’", "'");
        answer = answer.Replace("can't", "cant");

        return answer;
    }
}