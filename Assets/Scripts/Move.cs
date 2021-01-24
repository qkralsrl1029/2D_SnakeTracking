using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public enum PlayerDir
    {
        up = 0,
        right = 1,
        down,
        left,
    }
    PlayerDir currentDir = PlayerDir.up;

    Vector3 mouseClick = new Vector3();
    Vector3 mouseUp = new Vector3();
    Vector3 mouseGap = new Vector3();


    private void OnEnable()
    {
        currentDir = PlayerDir.up;
    }
    // Update is called once per frame
    void Update()
    {       
        if(GameManager.isPlaying)
        {
            move();
            rotate();
        }              
    }


    void move()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    void rotate()
    {
        if (Input.GetMouseButtonDown(0))
            mouseClick = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
            mouseGap = Input.mousePosition - mouseClick;


        float gapX = mouseGap.x;
        float gapY = mouseGap.y;

        switch (currentDir)
        {
            case PlayerDir.up:
                if (gapX > 200)
                {
                    transform.Rotate(new Vector3(0, 0, 90));
                    currentDir = PlayerDir.right;
                    mouseGap = Vector3.zero;
                }
                else if (gapX < -200)
                {
                    transform.Rotate(new Vector3(0, 0, -90));
                    currentDir = PlayerDir.left;
                    mouseGap = Vector3.zero;
                }
                break;
            case PlayerDir.right:
                if (gapY > 200)
                {
                    transform.Rotate(new Vector3(0, 0, -90));
                    currentDir = PlayerDir.up;
                    mouseGap = Vector3.zero;
                }
                else if (gapY < -200)
                {
                    transform.Rotate(new Vector3(0, 0, 90));
                    currentDir = PlayerDir.down;
                    mouseGap = Vector3.zero;
                }
                break;
            case PlayerDir.down:
                if (gapX > 200)
                {
                    transform.Rotate(new Vector3(0, 0, -90));
                    currentDir = PlayerDir.right;
                    mouseGap = Vector3.zero;
                }
                else if (gapX < -200)
                {
                    transform.Rotate(new Vector3(0, 0, 90));
                    currentDir = PlayerDir.left;
                    mouseGap = Vector3.zero;
                }
                break;
            case PlayerDir.left:
                if (gapY > 200)
                {
                    transform.Rotate(new Vector3(0, 0, 90));
                    currentDir = PlayerDir.up;
                    mouseGap = Vector3.zero;
                }
                else if (gapY < -200)
                {
                    transform.Rotate(new Vector3(0, 0, -90));
                    currentDir = PlayerDir.down;
                    mouseGap = Vector3.zero;
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Body")
        {
            GameManager.instance.GameEnd();
        }
    }

}
