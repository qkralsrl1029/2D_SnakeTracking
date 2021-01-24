using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
   
    tailGenerator generator;
    appleGenerator appleGenerator;

    private void Start()
    {
        generator = FindObjectOfType<tailGenerator>();
        appleGenerator = FindObjectOfType<appleGenerator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            generateTail();
            SoundManager.instance.PlaySFX("ScoreUp");
            GameManager.instance.setScore();
            appleGenerator._Generator();
            Destroy(gameObject);
        }
    }

    public void generateTail()
    {
        generator.createNewTail();
    }
}
