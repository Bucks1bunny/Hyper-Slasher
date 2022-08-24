using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager manager;

    private Player player;

    private void Awake()
    {
        if (manager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            manager = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        player = GameObject.Find("PlayerCharacter").GetComponent<Player>();
        player.AttributeReached += GetAchievement;
    }

    private void GetAchievement(string achievement)
    {
        PlayerPrefs.SetInt(achievement, 1);
    }
}
