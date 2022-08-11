using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI gemsText;
    public GameObject optionsUI;
    public GameObject[] levels;
    private int currentLevel;

    private void Start()
    {
        int gems = PlayerPrefs.GetInt("Gems");
        gemsText.text = gems.ToString();
        optionsUI.SetActive(false);

        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            currentLevel = 1;
        }
        for (int i = 0; i < levels.Length; i++)
        {
            if(i == currentLevel - 1)
            {
                levels[i].GetComponentInChildren<Image>().color = new Color(0.3f, 0.7f,0f);
            }
            else
            {
                levels[i].GetComponentInChildren<Image>().color = new Color(0.35f, 0.9f, 0.1f);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level" + currentLevel.ToString());
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
