using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultWindow : MonoBehaviour
{
    [SerializeField] Text currentScore;
    [SerializeField] Text topScore;


    public void gotoMenu()
    {
        GameManager.instance.gotoMenu();
    }

    public void setScore(int score)
    {
        currentScore.text = score.ToString();
    }

    public void setTopScore(int score)
    {
        topScore.text = score.ToString();
    }
 }
