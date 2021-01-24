using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public int topScore=0;
   

    public void setScore(int score)
    {
        topScore = score;
        PlayerPrefs.SetInt("top", topScore);
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey("top"))
        {
            topScore = PlayerPrefs.GetInt("top");
        }
    }

    public int getScore()
    {
        return topScore;
    }
}
