using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleGenerator : MonoBehaviour
{
    [SerializeField] GameObject apple;
    List<GameObject> apples = new List<GameObject>();
    float genRange = 0.9f;

    public void _Generator()
    {
        //생성 위치를 카메라화면상에 맞게 설정
        float screenH = Camera.main.orthographicSize;
        float screenW = screenH * Camera.main.aspect; //종횡비 곱해서 세로값 맞추기

        float appearPosX = Random.Range(-screenW* genRange, screenW* genRange);
        float appearPosY = Random.Range(-screenH* genRange, screenH* genRange);

        var _apple= Instantiate(apple, new Vector3(appearPosX, appearPosY, 0), Quaternion.identity);
        apples.Add(_apple);
    }

    public void removeApple()
    {
        for (int i = 0; i < apples.Count; i++)
        {
            Destroy(apples[i].gameObject);
        }
    }
}
