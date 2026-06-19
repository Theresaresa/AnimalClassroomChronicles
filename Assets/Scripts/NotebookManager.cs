using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotebookManager : MonoBehaviour
{
    [Header("Notebook UI")]
    public GameObject notebookPanel;
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI badgeText;
    public TextMeshProUGUI rewardText;

    [Header("Current Chapter")]
    public string chapterName = "Chapter 1: Classroom";
    public string progressKey = "ClassroomProgress";

    public string mission1 = "Mission 1";
    public string mission2 = "Mission 2";
    public string mission3 = "Mission 3";

    [Header("Badge Slots")]
    public Image classroomBadgeSlot;
    public Image cafeteriaBadgeSlot;
    public Image costumeBadgeSlot;
    public Image harborBadgeSlot;
    public Image libraryBadgeSlot;

    public Sprite lockedBadgeSprite;
    public Sprite classroomBadgeSprite;
    public Sprite cafeteriaBadgeSprite;
    public Sprite costumeBadgeSprite;
    public Sprite harborBadgeSprite;
    public Sprite libraryBadgeSprite;

    [Header("Reward Slots")]
    public Image classroomRewardSlot;
    public Image cafeteriaRewardSlot;
    public Image costumeRewardSlot;
    public Image harborRewardSlot;
    public Image libraryRewardSlot;

    public Sprite lockedRewardSprite;
    public Sprite magnifyingGlassSprite;
    public Sprite appleSprite;
    public Sprite detectiveHatSprite;
    public Sprite compassSprite;
    public Sprite goldenSpeakingBallSprite;

    public void OpenNotebook()
    {
        notebookPanel.SetActive(true);
        UpdateNotebook();
    }

    public void CloseNotebook()
    {
        notebookPanel.SetActive(false);
    }

    void UpdateNotebook()
    {
        int progress = PlayerPrefs.GetInt(progressKey, 0);

        progressText.text =
            chapterName + "\n\n" +
            Mark(progress >= 1) + mission1 + "\n" +
            Mark(progress >= 2) + mission2 + "\n" +
            Mark(progress >= 3) + mission3;

        if (badgeText != null)
            badgeText.text = "Chapter Badges";

        if (rewardText != null)
            rewardText.text = "Rewards";

        classroomBadgeSlot.sprite =
            PlayerPrefs.GetInt("ClassroomBadge", 0) == 1 ? classroomBadgeSprite : lockedBadgeSprite;

        cafeteriaBadgeSlot.sprite =
            PlayerPrefs.GetInt("CafeteriaBadge", 0) == 1 ? cafeteriaBadgeSprite : lockedBadgeSprite;

        costumeBadgeSlot.sprite =
            PlayerPrefs.GetInt("CostumeBadge", 0) == 1 ? costumeBadgeSprite : lockedBadgeSprite;

        harborBadgeSlot.sprite =
            PlayerPrefs.GetInt("HarborBadge", 0) == 1 ? harborBadgeSprite : lockedBadgeSprite;

        libraryBadgeSlot.sprite =
            PlayerPrefs.GetInt("LibraryBadge", 0) == 1 ? libraryBadgeSprite : lockedBadgeSprite;

        classroomRewardSlot.sprite =
            PlayerPrefs.GetInt("MagnifyingGlassUnlocked", 0) == 1 ? magnifyingGlassSprite : lockedRewardSprite;

        cafeteriaRewardSlot.sprite =
            PlayerPrefs.GetInt("AppleUnlocked", 0) == 1 ? appleSprite : lockedRewardSprite;

        costumeRewardSlot.sprite =
            PlayerPrefs.GetInt("DetectiveHatUnlocked", 0) == 1 ? detectiveHatSprite : lockedRewardSprite;

        harborRewardSlot.sprite =
            PlayerPrefs.GetInt("CompassUnlocked", 0) == 1 ? compassSprite : lockedRewardSprite;

        libraryRewardSlot.sprite =
            PlayerPrefs.GetInt("GoldenSpeakingBallUnlocked", 0) == 1 ? goldenSpeakingBallSprite : lockedRewardSprite;
    }

    string Mark(bool done)
    {
        return done ? "[x] " : "[ ] ";
    }
}