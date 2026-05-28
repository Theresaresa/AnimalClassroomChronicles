using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CleanupListeningManager : MonoBehaviour
{
    public AudioSource audioSource;

    public TMP_InputField question1Input;
    public TMP_InputField question2Input;
    public TMP_InputField question3Input;

    public TextMeshProUGUI feedbackText;

    public void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            feedbackText.text = "Audio is missing.";
        }
    }

    public void CheckAnswers()
    {
        string answer1 = CleanAnswer(question1Input.text);
        string answer2 = CleanAnswer(question2Input.text);
        string answer3 = CleanAnswer(question3Input.text);

        bool q1Correct =
            answer1 == "his favourite cape is purple" ||
            answer1 == "his favorite cape is purple" ||
            answer1 == "the purple cape is his favourite" ||
            answer1 == "the purple cape is his favorite" ||
            answer1 == "the purple cape is his favourite cape" ||
            answer1 == "it is purple";

        bool q2Correct =
            answer2 == "the shirts are white pink and light blue" ||
            answer2 == "they are white pink and light blue" ||
            answer2 == "white pink and light blue" ||
            answer2 == "white light blue and pink" ||
            answer2 == "they are white light blue and pink" ||
            answer2 == "the shirts are white light blue and pink" ||
            answer2 == "the shirts are pink white and light blue" ||
            answer2 == "there are pink, white and light blue shirts";

        bool q3Correct =
            answer3 == "he finds the dark blue socks behind the door" ||
            answer3 == "he found the dark blue socks behind the door" ||
            answer3 == "behind the door" ||
            answer3 == "he finds the dark blue socks are behind the door" ||
            answer3 == "he found the dark blue socks are behind the door";

        if (q1Correct && q2Correct && q3Correct)
        {
            feedbackText.text = "Excellent listening! You helped Mr Whinnyham clean up the shop.";
            Invoke("GoToEndingScene", 2f);
        }
        else
        {
            feedbackText.text = "Some answers are not correct yet. Listen again and check colours, clothes and places carefully.";
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.ToLower().Trim();

        answer = answer.Replace(".", "");
        answer = answer.Replace(",", "");
        answer = answer.Replace("!", "");
        answer = answer.Replace("?", "");
        answer = answer.Replace("’", "'");
        answer = answer.Replace("  ", " ");

        return answer;
    }

void GoToEndingScene()
{
    PlayerPrefs.SetString("LastScene", "Chapter3EndingScene");
    PlayerPrefs.Save();

    SceneManager.LoadScene("Chapter3EndingScene");
}

}