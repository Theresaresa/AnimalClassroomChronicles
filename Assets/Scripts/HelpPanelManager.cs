using UnityEngine;

public class HelpPanelManager : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject helpButton;

   public void ShowHelp()
{
    helpPanel.SetActive(true);
    helpButton.SetActive(false);
}

   public void HideHelp()
{
    helpPanel.SetActive(false);
    helpButton.SetActive(true);
}
}