using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsManager : MonoBehaviour
{
    private int GetAchievement(AchievementScriptableObject achievement)
    {
        if (!PlayerPrefs.HasKey(achievement.title))
        {
            PlayerPrefs.SetInt(achievement.title, 0);
            return 0;
        }
        else
        {
            return PlayerPrefs.GetInt(achievement.title);
        }
    }
}
