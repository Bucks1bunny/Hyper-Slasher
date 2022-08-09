using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    public GameObject pauseUI;

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }
}
