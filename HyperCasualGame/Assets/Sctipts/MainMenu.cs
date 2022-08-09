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

    public void OpenScinsUI()
    {

    }

    public void OpenShopUI()
    {

    }
    #endregion
    private void Start()
    {
        gemsText.text = PlayerPrefs.GetInt("Gems").ToString();
        optionsUI.SetActive(false);
    }

    #region OPTIONS 
    public void BackButton(GameObject UI)
    {
        UI.SetActive(false);
    }
    #endregion

}
