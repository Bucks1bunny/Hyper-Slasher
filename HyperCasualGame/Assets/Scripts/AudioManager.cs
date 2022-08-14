using UnityEngine.UI;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Image musicOnIcon;
    [SerializeField]
    private Image musicOffIcon;
    private bool muted;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Muted"))
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        LoadMusic();
        UpdateIcons();
        AudioListener.pause = muted;
    }

    public void OnMusicPress()
    {
        if (muted)
        {
            muted = false;
            AudioListener.pause = false;
        }
        else
        {
            muted = true;
            AudioListener.pause = true;
        }

        SaveMusic();
        UpdateIcons();
    }

    private void LoadMusic()
    {
        muted = PlayerPrefs.GetInt("Muted") == 1;
    }

    private void SaveMusic()
    {
        PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
    }

    private void UpdateIcons()
    {
        if (muted)
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
        }
        else
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
        }
    }
}
