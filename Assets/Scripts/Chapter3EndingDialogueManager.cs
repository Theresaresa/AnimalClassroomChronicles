using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chapter3EndingDialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button nextButton;

    private int dialogueIndex = 0;

    private string[] dialogueLines =
    {
        "Thank you so much for helping me.",
        
        "Now the shop is finally clean again.",

        "I remembered something important...",

        "The Golden Speaking Ball can open locked doors.",

        "This morning I saw suspicious pirates near the harbor.",

        "Maybe they wanted to steal the ball to use it for robberies...",

        "If you want to continue the investigation, you should visit the pirate ship at the harbor."
    };

    void Start()
    {
        dialogueText.text = dialogueLines[0];
    }

    public void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            GoToHarbor();
        }
    }

   void GoToHarbor()
{
    nextButton.interactable = false;

    PlayerPrefs.SetString("LastScene", "HarborScene");

    PlayerPrefs.SetInt("CostumeProgress", 4);
    PlayerPrefs.SetInt("CostumeBadge", 1);
    PlayerPrefs.SetInt("DetectiveHatUnlocked", 1);

    PlayerPrefs.SetInt(
        "UnlockedChapter",
        Mathf.Max(PlayerPrefs.GetInt("UnlockedChapter", 1), 4)
    );

    PlayerPrefs.Save();

    SceneManager.LoadScene("HarborScene");
}
}