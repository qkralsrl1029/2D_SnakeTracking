using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    [SerializeField] GameObject prevBody;
    [SerializeField] float moveSpeed;
    [SerializeField] float resetTime = 0.5f;
    Vector3 destination = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("setDes", 0, resetTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPlaying)
            transform.position= Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
    }

    void setDes()
    {
        destination = prevBody.transform.position;
    }

    public void setPrev(GameObject prev)
    {
        prevBody = prev;
    }
}
