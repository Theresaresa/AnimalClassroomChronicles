using UnityEngine;

public static class ProgressHelper
{
    public static void SetMissionProgress(string progressKey, int missionNumber)
    {
        int currentProgress = PlayerPrefs.GetInt(progressKey, 0);

        if (missionNumber > currentProgress)
        {
            PlayerPrefs.SetInt(progressKey, missionNumber);
            PlayerPrefs.Save();
        }
    }

    public static void CompleteChapter(
        string progressKey,
        string badgeKey,
        string rewardKey,
        int unlockedChapter
    )
    {
        PlayerPrefs.SetInt(progressKey, 3);
        PlayerPrefs.SetInt(badgeKey, 1);
        PlayerPrefs.SetInt(rewardKey, 1);

        PlayerPrefs.SetInt(
            "UnlockedChapter",
            Mathf.Max(PlayerPrefs.GetInt("UnlockedChapter", 1), unlockedChapter)
        );

        PlayerPrefs.Save();
    }
}