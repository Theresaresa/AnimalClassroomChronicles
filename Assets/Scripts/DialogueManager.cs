using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialoguePanel;
    public GameObject goldenBallInfoPanel;

    private string[] dialogueLines;
    private int currentLine = 0;

    void Start()
    {
        dialogueLines = new string[]
        {
            "Oh no! Something terrible has happened in our classroom.",
            "The Golden Speaking Ball is missing.",
            "It was last seen at school before the lesson started.",
            "You are one of our best detective students. I need your help.",
            "Please investigate the classroom and look for the first clue."
        };

        ShowLine();
    }

    void ShowLine()
    {
        speakerNameText.text = "Mrs Frogman";
        dialogueText.text = dialogueLines[currentLine];
    }

    public void NextLine()
    {
        Debug.Log("Next button clicked");

        currentLine++;

        if (currentLine < dialogueLines.Length)
        {
            ShowLine();
        }
        else
        {
            Debug.Log("Dialogue finished");

            if (dialoguePanel != null)
    dialoguePanel.SetActive(false);

if (goldenBallInfoPanel != null)
    goldenBallInfoPanel.SetActive(true);
        }
    }
}