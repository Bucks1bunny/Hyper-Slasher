using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    public GameObject pauseUI;
    public TextMeshProUGUI gemsText;
    public Player player
    {
        get;
        private set;
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    private void Start()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.GemPickedup += OnGemPickedup;
    }

    private void OnGemPickedup(int gems)
    {
        gemsText.text = gems.ToString();
    }
}
