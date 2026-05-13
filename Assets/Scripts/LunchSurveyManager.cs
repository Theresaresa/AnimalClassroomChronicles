using UnityEngine;
using TMPro;

public class LunchSurveyManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TMP_InputField surveyInputField;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI progressText;

    public GameObject surveyPanel;
    public GameObject storageRoomPanel;

    private int currentQuestion = 0;

    private string[] questions =
    {
        "Do you like pizza?",
        "Do you like soup?",
        "Do you like spinach?",
        "Do you like burgers?",
        "Do you like bananas?",
        "Do you like chocolate?"
    };

    void Start()
    {
        ShowQuestion();

        if (storageRoomPanel != null)
        {
            storageRoomPanel.SetActive(false);
        }
    }

    void ShowQuestion()
    {
        questionText.text = questions[currentQuestion];
        progressText.text = "Question " + (currentQuestion + 1) + " / " + questions.Length;
        feedbackText.text = "";
        surveyInputField.text = "";
    }

    public void CheckAnswer()
    {
        string originalAnswer = surveyInputField.text.Trim();

        if (originalAnswer == "")
        {
            feedbackText.text = "Please write an answer.";
            return;
        }

        string cleanedAnswer = CleanAnswer(originalAnswer);

        if (cleanedAnswer == "yes i do" || cleanedAnswer == "no i dont")
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

            feedbackText.text = "Good answer!";

            currentQuestion++;

            if (currentQuestion < questions.Length)
            {
                Invoke("ShowQuestion", 1.0f);
            }
            else
            {
                feedbackText.text = "Thank you for helping Mrs Ladybug!";
                Invoke("OpenStorageRoom", 2.0f);
            }
        }
        else
        {
            feedbackText.text = "Check your spelling carefully. Use: Yes I do / No I don't.";
        }
    }

    void OpenStorageRoom()
    {
        surveyPanel.SetActive(false);

        if (storageRoomPanel != null)
        {
            storageRoomPanel.SetActive(true);
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.ToLower().Trim();

        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace("'", "");
        answer = answer.Replace("’", "");
        answer = answer.Replace("!", "");
        answer = answer.Replace("?", "");

        return answer;
    }
}
