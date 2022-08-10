using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI gemsText;
    public GameObject optionsUI;

    #region MAIN MENU
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenOptionsUI()
    {
        optionsUI.SetActive(true);
    }

    #endregion
    private void Start()
    {
        int gems = PlayerPrefs.GetInt("Gems");
        gemsText.text = gems.ToString();
        optionsUI.SetActive(false);
    }

    public void CloseUI(GameObject UI)
    {
        UI.SetActive(false);
    }

    public void OpenUI(GameObject UI)
    {
        UI.SetActive(true);
    }
}
