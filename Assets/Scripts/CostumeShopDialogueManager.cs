using UnityEngine;
using TMPro;

public class CostumeShopDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialoguePanel;
    public GameObject firstTaskPanel;

    private string[] dialogueLines;
    private int currentLine = 0;

    void Start()
    {
        dialogueLines = new string[]
        {
            "Oh, thank you for bringing the apples!",
            "Something terrible happened in my costume shop.",
            "Someone broke in and threw my clothes everywhere!",
            "I think some clothes are missing, but the shop is such a mess.",
            "Could you help me check the price tags and find out what is gone?"
        };

        ShowLine();

        if (firstTaskPanel != null)
        {
            firstTaskPanel.SetActive(false);
        }
    }

    void ShowLine()
    {
        speakerNameText.text = "Mr Whinnyham";
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

            if (firstTaskPanel != null)
            {
                firstTaskPanel.SetActive(true);
            }
        }
    }
}
