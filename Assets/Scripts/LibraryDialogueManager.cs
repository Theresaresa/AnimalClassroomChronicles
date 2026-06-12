using UnityEngine;
using TMPro;

public class LibraryDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialoguePanel;
    public GameObject diaryMissionPanel;

    private string[] dialogueLines;

    private int currentLine = 0;

    void Start()
    {
        dialogueLines = new string[]
        {
            "This must be the Academy Library.",

            "Bane said the secret room was hidden here.",

            "The strange letter smelled like an old dusty cellar.",

            "Maybe there is a clue hidden somewhere between these bookshelves.",

            "I should investigate the old diary I found on this table."
        };

        ShowLine();

        if (diaryMissionPanel != null)
        {
            diaryMissionPanel.SetActive(false);
        }
    }

    void ShowLine()
    {
        speakerNameText.text = "Detective";
        dialogueText.text = dialogueLines[currentLine];
    }

    public void NextLine()
    {
        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            ShowLine();
        }
        else
        {
            dialoguePanel.SetActive(false);

            if (diaryMissionPanel != null)
            {
                diaryMissionPanel.SetActive(true);
            }
        }
    }
}