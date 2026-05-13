using UnityEngine;
using TMPro;

public class CafeteriaDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialoguePanel;
    public GameObject surveyPanel;

    private string[] dialogueLines;
    private int currentLine = 0;

    void Start()
    {
        dialogueLines = new string[]
        {
            "Oh dear... you found my cafeteria.",
            "Are you investigating the missing Golden Speaking Ball?",
            "I saw someone rushing through here after class.",
            "They were wearing a yellow cap and a black jacket.",
            "Before I tell you more, could you help me with a quick food survey?"
        };

        ShowLine();

        if (surveyPanel != null)
        {
            surveyPanel.SetActive(false);
        }
    }

    void ShowLine()
    {
        speakerNameText.text = "Mrs Ladybug";
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

            if (surveyPanel != null)
            {
                surveyPanel.SetActive(true);
            }
        }
    }
}
