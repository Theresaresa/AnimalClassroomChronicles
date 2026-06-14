using UnityEngine;
using TMPro;

public class SecretRoomDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialoguePanel;
    public GameObject accusationPanel;

    private string[] dialogueLines;
    private int currentLine = 0;

    void Start()
    {
        dialogueLines = new string[]
        {
            "Well done, Detective.",

            "I knew you would investigate carefully.",

            "Now tell me... what did you discover?",

            "Who do you think stole the Golden Speaking Ball?"
        };

        ShowLine();

        if(accusationPanel != null)
        {
            accusationPanel.SetActive(false);
        }
    }

    void ShowLine()
    {
        speakerNameText.text = "Mrs Frogman";
        dialogueText.text = dialogueLines[currentLine];
    }

    public void NextLine()
    {
        currentLine++;

        if(currentLine < dialogueLines.Length)
        {
            ShowLine();
        }
        else
        {
            dialoguePanel.SetActive(false);

            if(accusationPanel != null)
            {
                accusationPanel.SetActive(true);
            }
        }
    }
}