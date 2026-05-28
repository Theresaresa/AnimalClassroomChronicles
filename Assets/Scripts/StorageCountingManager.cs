using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StorageCountingManager : MonoBehaviour
{
    public TextMeshProUGUI exampleText;
    public TextMeshProUGUI questionText;
    public TMP_InputField answerInputField;
    public TextMeshProUGUI feedbackText;
    public TextMeshProUGUI progressText;

    private int currentQuestion = 0;

    private string[] questions =
    {
        "How many loaves of bread are there?",
        "How many cloves of garlic are there?",
        "How many pumpkins are there?",
        "How many cucumbers are there?",
        "How many apples are there?"
    };

    private string[] correctAnswers =
    {
        "There are six loaves of bread",
        "There are eleven cloves of garlic",
        "There are two pumpkins",
        "There are seven cucumbers",
        "There are three apples"
    };

    void Start()
    {
        exampleText.text =
            "Example:\nHow many carrots are there?\nThere are nineteen carrots.";

        ShowQuestion();
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
            feedbackText.text = "Please write a full sentence.";
            return;
        }

        string cleanedAnswer = CleanAnswer(originalAnswer);
        string cleanedCorrect = CleanAnswer(correctAnswers[currentQuestion]);

        if (cleanedAnswer == cleanedCorrect)
        {
            if (!char.IsUpper(originalAnswer[0]))
            {
                feedbackText.text = "Remember: sentences start with a capital letter.";
                return;
            }

            if (!originalAnswer.StartsWith("There are"))
            {
                feedbackText.text = "Start your answer with: There are ...";
                return;
            }

            feedbackText.text = "Correct! Great counting.";

            currentQuestion++;

            if (currentQuestion < questions.Length)
            {
                Invoke("ShowQuestion", 1.2f);
            }
            else
            {
                feedbackText.text = "Excellent work! You counted all the food.";
                Invoke("GoToLockedStorage", 2f);
            }
        }
        else
        {
            feedbackText.text = "Check your spelling and write the number as a word.";
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.Trim();
        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace("!", "");
        answer = answer.Replace("?", "");
        return answer;
    }

    void GoToLockedStorage()
{
    PlayerPrefs.SetString("LastScene", "LockedStorageScene");
    PlayerPrefs.Save();

    SceneManager.LoadScene("LockedStorageScene");
}
}