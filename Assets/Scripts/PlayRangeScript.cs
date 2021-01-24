using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRangeScript : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.GameEnd();
        }
    }
}
