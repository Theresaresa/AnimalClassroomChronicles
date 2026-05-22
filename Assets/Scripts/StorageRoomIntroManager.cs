using UnityEngine;
using TMPro;

public class StorageRoomIntroManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject introPanel;
    public GameObject countingPanel;

    private string[] dialogueLines;
    private int currentLine = 0;

    void Start()
    {
        dialogueLines = new string[]
        {
            "Could you help me count the food for next week?",
            "I cannot find my glasses, and everything looks blurry.",
            "Maybe you can also look for clues about the Golden Speaking Ball.",
            "Please count the food carefully and write your answers in full sentences."
        };

        ShowLine();

        if (countingPanel != null)
        {
            countingPanel.SetActive(false);
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
            introPanel.SetActive(false);

            if (countingPanel != null)
            {
                countingPanel.SetActive(true);
            }
        }
    }
}