using UnityEngine;


[CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObject/Achievement")]
public class AchievementScriptableObject : ScriptableObject
{
    public string title;
    public int isAchieved;
    public int gemsReward;
}
