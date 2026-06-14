using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BookshelfCodeManager : MonoBehaviour
{
    public AudioSource audioSource;
    public TMP_InputField codeInput;
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

    public void CheckCode()
    {
        string answer = CleanAnswer(codeInput.text);

        if (answer == "10 35 45 18 90")
        {
            feedbackText.text = "Correct! The bookshelf moves aside. A secret staircase appears.";
            Invoke("GoToSecretRoom", 2f);
        }
        else
        {
            feedbackText.text = "Not quite. Listen again and write the numbers in the correct order.";
        }
    }

    string CleanAnswer(string answer)
    {
        answer = answer.Trim();

        answer = answer.Replace("-", " ");
        answer = answer.Replace("–", " ");
        answer = answer.Replace(",", " ");
        answer = answer.Replace(".", " ");

        while (answer.Contains("  "))
        {
            answer = answer.Replace("  ", " ");
        }

        return answer;
    }

    void GoToSecretRoom()
    {
        PlayerPrefs.SetString("LastScene", "SecretRoomScene");
        PlayerPrefs.Save();

        SceneManager.LoadScene("SecretRoomScene");
    }
}