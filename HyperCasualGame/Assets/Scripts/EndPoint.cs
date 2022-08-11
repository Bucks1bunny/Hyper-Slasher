using UnityEngine;
using TMPro;

public class EndPoint : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject endGameUI;
    public TextMeshProUGUI collectedGems;
    private int unlockLevel;

    private void Start()
    {
        unlockLevel = PlayerPrefs.GetInt("Level") + 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);

        var player = other.GetComponent<PlayerMovement>();
        int currentGems = player.GetComponent<Player>().Gems;
        int gems = PlayerPrefs.GetInt("Gems");

        player.rb.velocity = Vector3.zero;
        player.enabled = false;

        collectedGems.text = currentGems.ToString();
        PlayerPrefs.SetInt("Level", unlockLevel);
        PlayerPrefs.SetInt("Gems", gems + currentGems);
    }
}
