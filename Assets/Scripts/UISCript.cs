using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISCript : MonoBehaviour
{
    public Image Panel;     //페이드 아웃용 검은 화면
    float currentTime = 0;  //현재 시간
    float fadeoutTime = 2;  //페이드아웃이 진행될 시간

    [SerializeField] ParticleSystem effect;

    [SerializeField] GameObject optionBG;
    [SerializeField] Sprite[] snakeImages;


    [SerializeField] Button pauseBtn;
    [SerializeField] Sprite[] pauseImg;
    public void FadeInOut()
    {
        StartCoroutine(fadeOut());
        SoundManager.instance.StopBGM();
    }

    IEnumerator fadeOut()
    {
        effect.gameObject.SetActive(false);
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        while (alpha.a < 1)
        {
            currentTime += Time.deltaTime / fadeoutTime;
            alpha.a = Mathf.Lerp(0, 1, currentTime);
            FindObjectOfType<titleanim>().setAlpha(currentTime);
            Panel.color = alpha;
            yield return null;
        }
        StartCoroutine(FadeIn());
        GameManager.instance.ReadyGame();
        GameManager.instance.setSnakePos();
    }

    IEnumerator FadeIn()
    {
        Color alpha = Panel.color;
        currentTime = 0;
        while (alpha.a > 0)
        {
            currentTime += Time.deltaTime / fadeoutTime;
            alpha.a = Mathf.Lerp(1, 0, currentTime);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        GameManager.isPlaying = true;
        
    }

    public void onOption()
    {
        optionBG.SetActive(true);
        Time.timeScale = 0;
    }

    public void offOption()
    {
        optionBG.SetActive(false);
        Time.timeScale = 1;
    }

    public void setImage(int index)
    {
        GameManager.instance.setSnakeIMG(snakeImages[index]);
    }

    public void PauseOnOff()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseBtn.image.sprite = pauseImg[1];
        }
        else
        {
            Time.timeScale = 0;
            pauseBtn.image.sprite = pauseImg[0];
        }
    }
}
