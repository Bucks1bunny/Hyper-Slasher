using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Achievement : MonoBehaviour
{
    [field: SerializeField]
    public AchievementScriptableObject data
    {
        get;
        private set;
    }

    [SerializeField]
    private TextMeshProUGUI reward;
    [SerializeField]
    private TextMeshProUGUI gemsText;

    public void OnButtonPress()
    {
        if(PlayerPrefs.GetInt("Level") == 5 && !data.isTaken)
        {
            TakeReward();
        }
        else if (PlayerPrefs.GetInt(data.title) == 1 && !data.isTaken)
        {
            TakeReward();
        }
    }

    private void Start()
    {
        reward.text = data.gemsReward.ToString();

        if (data.isTaken)
        {
            GetComponent<Image>().color = new Color(1, 1, 0);
        }
    }

    private void TakeReward()
    {
        int gems = PlayerPrefs.GetInt("Gems") + data.gemsReward;
        PlayerPrefs.SetInt("Gems", gems);
        gemsText.text = gems.ToString();

        GetComponent<Image>().color = new Color(1, 1, 0);
        GetComponent<Button>().interactable = false;

        data.isTaken = true;
    }
}
