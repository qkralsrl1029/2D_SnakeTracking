using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Text score;
    public static bool isPlaying = false;


    [SerializeField] GameObject titleBG;
    [SerializeField] GameObject snake;
    [SerializeField] GameObject head;
    [SerializeField] Transform originPos;

    [SerializeField] GameObject resultWindow;
    [SerializeField] titleanim titleanim;

    [SerializeField] Database theData;
    int gameScore = 0;

    
    void Start()
    {
        SoundManager.instance.PlayBGM("title");
        theData.LoadScore();
        instance = this;
        originPos.position = snake.transform.position;
        snake.SetActive(false);
        setScore(0);
    }

   

    public void setScore(int _score=1)
    {
        gameScore += _score;
        score.text = gameScore.ToString();
    }

    public void GameEnd()
    {
        SoundManager.instance.PlaySFX("Die");
        SoundManager.instance.StopBGM();
        isPlaying = false;
        snake.SetActive(false);

        FindObjectOfType<appleGenerator>().removeApple();


        if (gameScore > theData.getScore())
        {
            SoundManager.instance.PlaySFX("NewRecord");
            theData.setScore(gameScore);
        }

        resultWindow.SetActive(true);
        resultWindow.GetComponent<ResultWindow>().setScore(gameScore);
        resultWindow.GetComponent<ResultWindow>().setTopScore(theData.getScore());
    }

    

    public void ReadyGame()
    {
        titleBG.SetActive(false);
        snake.SetActive(true);
        SoundManager.instance.PlayBGM("ingame");
        FindObjectOfType<appleGenerator>()._Generator();
    }

   
    public void gotoMenu()
    {
        
        FindObjectOfType<tailGenerator>().removeTails();
        titleanim.SetOrigin();
        
        resultWindow.SetActive(false);
        titleBG.SetActive(true);
        SoundManager.instance.PlayBGM("title");
        gameScore = 0;
        setScore(0);
    }

    public void setSnakePos()
    {
        Transform _snake = snake.GetComponentInChildren<Move>().transform;
        _snake.position = originPos.position;
        BodyScript[] bodies= snake.GetComponentsInChildren<BodyScript>();
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].transform.position = originPos.position;
        }

        Vector3 originRot = new Vector3(0, 180, 0);
        Vector3 rotGap = originRot - head.transform.rotation.eulerAngles;
        head.transform.Rotate(rotGap);
    }

    public void setSnakeIMG(Sprite img)
    {
        head.GetComponent<SpriteRenderer>().sprite = img;
    }


}
