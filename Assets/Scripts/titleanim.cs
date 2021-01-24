using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleanim : MonoBehaviour
{
    [SerializeField] float moveSpeed;
 
   
    // Update is called once per frame
    void Update()
    {
        float screenH = Camera.main.orthographicSize;
        float screenW = screenH * Camera.main.aspect;

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (transform.position.x > screenW * 1.2)
            transform.Translate(Vector3.left * (2 * screenW));
    }

    public void setAlpha(float a)
    {
        Color alpha = GetComponent<SpriteRenderer>().color;
         alpha.a= Mathf.Lerp(1, 0, a);
        GetComponent<SpriteRenderer>().color = alpha;
    }

    public void SetOrigin()
    {
        Color alpha = GetComponent<SpriteRenderer>().color;
        alpha.a = 1;
        GetComponent<SpriteRenderer>().color = alpha;
    }
}
