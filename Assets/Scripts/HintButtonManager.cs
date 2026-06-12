using UnityEngine;

public class HintButtonManager : MonoBehaviour
{
    public GameObject hintText;

    public void ShowHint()
    {
        if (hintText != null)
        {
            hintText.SetActive(true);
        }
    }
}