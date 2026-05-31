using UnityEngine;
using TMPro;

public class BaneDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialoguePanel;
    public GameObject readingMissionPanel;

    private int currentLine = 0;

    private string[] dialogueLines =
    {
        "Oh... you found me.",
        "I am a little nervous.",
        "I did not want to cause trouble.",
        "You seem kind for a detective.",
        "Maybe we can talk about music first.",
        "That always helps me calm down."
    };

    void Start()
    {
        if (readingMissionPanel != null)
        {
            readingMissionPanel.SetActive(false);
        }

        ShowLine();
    }

    void ShowLine()
    {
        speakerNameText.text = "Bane";
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

            if (readingMissionPanel != null)
            {
                readingMissionPanel.SetActive(true);
            }
        }
    }
}