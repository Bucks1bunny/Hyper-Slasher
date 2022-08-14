using UnityEngine;
using TMPro;

public class EndPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject gameUI;
    [SerializeField]
    private GameObject endGameUI;
    [SerializeField]
    private GameObject nextLevelButton;
    [SerializeField]
    private GameObject retryButton;
    [SerializeField]
    private TextMeshProUGUI collectedGems;
    [SerializeField]
    private TextMeshProUGUI endGameText;

    private int nextLevel;
    private Player player;

    private void Start()
    {
        nextLevel = PlayerPrefs.GetInt("Level");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement.rb.velocity = Vector3.zero;
            playerMovement.enabled = false;

            player = other.GetComponent<Player>();
            var boss = GameObject.Find("Boss");

            float playerStrengh = player.transform.localScale.x + player.transform.localScale.y;
            float bossStrengh = boss.transform.localScale.x + boss.transform.localScale.y;

            if (playerStrengh - bossStrengh >= 0)
            {
                player.GetComponent<Animator>().SetTrigger("Attack");
                Invoke("PlayerWin", 1.7f);
            }
            else
            {
                boss.GetComponent<Animator>().SetTrigger("Attack");
                Invoke("PlayerLose", 1.7f);
            }
        }
    }

    private void PlayerWin()
    {
        PlayerEnd();
        endGameText.text = "LEVEL CLEARED";
        retryButton.SetActive(false);
        nextLevelButton.SetActive(true);

        PlayerPrefs.SetInt("Level", nextLevel + 1);
    }

    private void PlayerLose()
    {
        PlayerEnd();
        retryButton.SetActive(true);
        nextLevelButton.SetActive(false);
        endGameText.text = "YOU LOSE";
    }

    private void PlayerEnd()
    {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);

        int currentGems = player.Gems;
        int gems = PlayerPrefs.GetInt("Gems");

        collectedGems.text = currentGems.ToString();
        PlayerPrefs.SetInt("Gems", gems + currentGems);
    }
}
