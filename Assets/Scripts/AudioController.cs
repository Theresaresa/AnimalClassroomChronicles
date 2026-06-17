using UnityEngine;
using TMPro;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public TextMeshProUGUI buttonText;

    public void ToggleAudio()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is missing.");
            return;
        }

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            buttonText.text = "Play Listening";
        }
        else
        {
            audioSource.Play();
            buttonText.text = "Stop Listening";
        }
    }
}