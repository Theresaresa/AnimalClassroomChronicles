using UnityEngine;
using TMPro;

public class HarborDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialoguePanel;
    public GameObject listeningMissionPanel;

    private int currentLine = 0;

    private string[] speakers =
    {
        "Captain Jax",
        "Ripley",
        "Hook",
        "Slash",
        "Bane",
        "Captain Jax"
    };

    private string[] dialogueLines =
    {
        "Ahoy, Detective! Welcome to the harbor.",
        "We heard you are looking for the Golden Speaking Ball.",
        "We can help you with your investigation.",
        "But first, you must prove that you are a real detective.",
        "I-I hope it isn't me...",
        "Listen carefully and tell us exactly which pirate you want to talk to."
    };

    void Start()
    {
        if (listeningMissionPanel != null)
        {
            listeningMissionPanel.SetActive(false);
        }

        ShowLine();
    }

    void ShowLine()
    {
        speakerNameText.text = speakers[currentLine];
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

            if (listeningMissionPanel != null)
            {
                listeningMissionPanel.SetActive(true);
            }
        }
    }
}