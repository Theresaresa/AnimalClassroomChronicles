using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource audioSource;

    
    public AudioClip handcuffSound;
    public AudioClip certificateFanfareSound;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    

    public void PlayHandcuffs()
    {
        PlaySound(handcuffSound);
    }

    public void PlayCertificateFanfare()
    {
        PlaySound(certificateFanfareSound);
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}