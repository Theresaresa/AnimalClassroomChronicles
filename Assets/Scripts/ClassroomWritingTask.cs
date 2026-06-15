using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClassroomWritingTask : MonoBehaviour
{
    [Header("Investigation Task")]
    public TMP_InputField sentence1;
    public TMP_InputField sentence2;
    public TMP_InputField sentence3;
    public TMP_InputField sentence4;
    public TMP_InputField sentence5;

    public TextMeshProUGUI feedbackText;
    public Button continueButton;

    [Header("Panels")]
    public GameObject investigationPanel;
    public GameObject wordSearchPanel;

    [Header("Word Search Task")]
    public TMP_InputField wordSearchInputField;
    public TextMeshProUGUI wordSearchFeedbackText;
    public GameObject hintText;
    public Button goToCafeteriaButton;

    void Start()
    {
        continueButton.interactable = false;
        goToCafeteriaButton.interactable = false;

        if (wordSearchPanel != null)
        {
            wordSearchPanel.SetActive(false);
        }

        if (hintText != null)
        {
            hintText.SetActive(false);
        }
    }

    public void CheckAnswers()
    {
        int goodSentences = 0;

        if (IsGoodSentence(sentence1.text)) goodSentences++;
        if (IsGoodSentence(sentence2.text)) goodSentences++;
        if (IsGoodSentence(sentence3.text)) goodSentences++;
        if (IsGoodSentence(sentence4.text)) goodSentences++;
        if (IsGoodSentence(sentence5.text)) goodSentences++;

        if (goodSentences >= 3)
        {
            feedbackText.text = "Excellent detective work! You found an anonymous note behind the board.";
            continueButton.interactable = true;
        }
        else
        {
            feedbackText.text = "You found " + goodSentences +
                " good clue(s). Write more classroom observations using there is / there are.";
            continueButton.interactable = false;
        }
    }

    bool IsGoodSentence(string sentence)
    {
        sentence = sentence.ToLower().Trim();

        bool startsCorrectly =
            sentence.StartsWith("there is ") ||
            sentence.StartsWith("there are ");

        string[] classroomWords =
        {
            "desk", "desks",
            "chair", "chairs",
            "board",
            "book", "books",
            "clock",
            "window", "windows",
            "door", "doors",
            "pencil", "pencils",
            "table", "tables",
            "notebook", "notebooks",
            "computer", "computers",
            "speaker", "speakers",
            "sound system"
        };

        bool hasClassroomWord = false;

        foreach (string word in classroomWords)
        {
            if (sentence.Contains(word))
            {
                hasClassroomWord = true;
                break;
            }
        }

        return startsCorrectly && hasClassroomWord;
    }

    public void ContinueInvestigation()
    {
        investigationPanel.SetActive(false);
        wordSearchPanel.SetActive(true);
    }

    public void CheckWordSearchAnswer()
{
    wordSearchFeedbackText.gameObject.SetActive(true);

    string answer = wordSearchInputField.text.ToLower().Trim();

    if (answer == "cafeteria")
    {
        wordSearchFeedbackText.text =
            "Correct! Someone in the cafeteria may know more.";

        goToCafeteriaButton.gameObject.SetActive(true);
        goToCafeteriaButton.interactable = true;
    }
    else
    {
        wordSearchFeedbackText.text =
            "Try again. Look carefully in the word search.";
    }
}

    public void ShowHint()
{
    hintText.gameObject.SetActive(true);
}
public void GoToCafeteria()
{
    PlayerPrefs.SetString("LastScene", "CafeteriaScene");
    PlayerPrefs.SetInt("UnlockedChapter", Mathf.Max(PlayerPrefs.GetInt("UnlockedChapter", 1), 2));
    PlayerPrefs.Save();

    SceneManager.LoadScene("CafeteriaScene");
}
    
}