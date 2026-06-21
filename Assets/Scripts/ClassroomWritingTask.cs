using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ClassroomWritingTask : MonoBehaviour
{
    [Header("Golden Ball Grammar Task")]
    public GameObject goldenBallInfoPanel;
    public TMP_InputField correctionInput1;
    public TMP_InputField correctionInput2;
    public TMP_InputField correctionInput3;
    public TMP_InputField correctionInput4;
    public TextMeshProUGUI goldenBallFeedbackText;

    [Header("Investigation Task")]
    public TMP_InputField sentence1;
    public TMP_InputField sentence2;
    public TMP_InputField sentence3;
    public TMP_InputField sentence4;
    public TMP_InputField sentence5;

    public TextMeshProUGUI feedbackText;
    public Button continueButton;

    [Header("Panels")]
    public GameObject dialoguePanel;
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

        if (dialoguePanel != null)
            dialoguePanel.SetActive(true);

        if (goldenBallInfoPanel != null)
            goldenBallInfoPanel.SetActive(false);

        if (investigationPanel != null)
            investigationPanel.SetActive(false);

        if (wordSearchPanel != null)
            wordSearchPanel.SetActive(false);

        if (hintText != null)
            hintText.SetActive(false);
    }

    public void OpenGoldenBallInfoPanel()
    {
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        if (goldenBallInfoPanel != null)
            goldenBallInfoPanel.SetActive(true);
    }

    public void CheckGoldenBallInfo()
    {
        string answer1 = CleanAnswer(correctionInput1.text);
        string answer2 = CleanAnswer(correctionInput2.text);
        string answer3 = CleanAnswer(correctionInput3.text);
        string answer4 = CleanAnswer(correctionInput4.text);

        bool allCorrect =
            answer1 == "it speaks and answers questions" &&
            answer2 == "the ball has magical powers" &&
            answer3 == "students use the ball to learn" &&
            answer4 == "teachers can move the ball";

        if (allCorrect)
        {
            goldenBallFeedbackText.text =
                "Excellent detective work! You now understand the most important facts about the Golden Speaking Ball.";

            Invoke("OpenInvestigationPanel", 2f);
            
        }
        else
        {
            goldenBallFeedbackText.text =
                "Some sentences are not correct yet. Rewrite the full sentences and check the grammar carefully.";
        }
    }

    void OpenInvestigationPanel()
    {

        PlayerPrefs.SetInt("ClassroomProgress", 1);
        PlayerPrefs.Save();

        goldenBallInfoPanel.SetActive(false);
        investigationPanel.SetActive(true);
    }

    public void CheckAnswers()
{
    int goodSentences = 0;
    List<string> usedObjects = new List<string>();

    if (IsGoodSentence(sentence1.text, usedObjects)) goodSentences++;
    if (IsGoodSentence(sentence2.text, usedObjects)) goodSentences++;
    if (IsGoodSentence(sentence3.text, usedObjects)) goodSentences++;
    if (IsGoodSentence(sentence4.text, usedObjects)) goodSentences++;
    if (IsGoodSentence(sentence5.text, usedObjects)) goodSentences++;

    if (goodSentences >= 3)
    {
        feedbackText.text = "Excellent detective work! You found an anonymous note behind the board.";
        continueButton.interactable = true;

        PlayerPrefs.SetInt("ClassroomProgress", 2);
        PlayerPrefs.Save();
    }
    else
    {
        feedbackText.text = "You found " + goodSentences +
            " good clue(s). Use there is / there are and write about different classroom objects.";
        continueButton.interactable = false;
    }
}

    bool IsGoodSentence(string sentence, List<string> usedObjects)
{
    sentence = sentence.ToLower().Trim();

    string[,] singularWords =
    {
        { "desk", "desk" },
        { "chair", "chair" },
        { "board", "board" },
        { "book", "book" },
        { "clock", "clock" },
        { "window", "window" },
        { "door", "door" },
        { "pencil", "pencil" },
        { "table", "table" },
        { "notebook", "notebook" },
        { "computer", "computer" },
        { "speaker", "speaker" },
        { "sound system", "sound system" }
    };

    string[,] pluralWords =
    {
        { "desks", "desk" },
        { "chairs", "chair" },
        { "books", "book" },
        { "windows", "window" },
        { "doors", "door" },
        { "pencils", "pencil" },
        { "tables", "table" },
        { "notebooks", "notebook" },
        { "computers", "computer" },
        { "speakers", "speaker" }
    };

    if (sentence.StartsWith("there is "))
    {
        return CheckWordList(sentence, singularWords, usedObjects);
    }

    if (sentence.StartsWith("there are "))
    {
        return CheckWordList(sentence, pluralWords, usedObjects);
    }

    return false;
}

bool CheckWordList(string sentence, string[,] wordList, List<string> usedObjects)
{
    for (int i = 0; i < wordList.GetLength(0); i++)
    {
        string wordInSentence = wordList[i, 0];
        string baseWord = wordList[i, 1];

        if (sentence.Contains(wordInSentence))
        {
            if (usedObjects.Contains(baseWord))
            {
                return false;
            }

            usedObjects.Add(baseWord);
            return true;
        }
    }

    return false;
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

            PlayerPrefs.SetInt("ClassroomProgress", 3);
            PlayerPrefs.SetInt("ClassroomBadge", 1);
            PlayerPrefs.SetInt("MagnifyingGlassUnlocked", 1);
            PlayerPrefs.Save();
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

    PlayerPrefs.SetInt(
        "UnlockedChapter",
        Mathf.Max(PlayerPrefs.GetInt("UnlockedChapter", 1), 2)
    );

    PlayerPrefs.Save();

    SceneManager.LoadScene("CafeteriaScene");
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
}