using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject endGameUI;

    private void OnTriggerEnter(Collider other)
    {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);

        var player = other.GetComponent<PlayerMovement>();
        int currentGems = player.GetComponent<Player>().Gems;
        int gems = PlayerPrefs.GetInt("Gems");

        player.rb.velocity = Vector3.zero;
        player.enabled = false;

        PlayerPrefs.SetInt("Gems", gems + currentGems);
    }
}
