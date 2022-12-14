using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private TextMeshProUGUI gemsText;
    private Player player;

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResumeGame(GameObject UI)
    {
        UI.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        int nextLevel = PlayerPrefs.GetInt("Level");
        if (nextLevel < 5)
        {
            SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void Start()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.GemPickedup += OnGemPickedup;
    }

    private void OnGemPickedup(int gems)
    {
        gemsText.text = gems.ToString();
    }
}
