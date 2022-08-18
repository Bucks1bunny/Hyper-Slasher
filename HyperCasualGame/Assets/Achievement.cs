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
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI reward;
    [SerializeField]
    private Image achievedIcon;

    public void OnButtonPress()
    {
        if (data.isAchieved == 1)
        {
            int gems = PlayerPrefs.GetInt("Gems");
            PlayerPrefs.SetInt("Gems", gems + 50);
            
        }
    }

    private void Start()
    {
        title.text = data.title;
        reward.text = data.gemsReward.ToString();
        if (data.isAchieved == 1)
        {
            GetComponent<Image>().color = new Color(1, 1, 0);
        }
    }
}
