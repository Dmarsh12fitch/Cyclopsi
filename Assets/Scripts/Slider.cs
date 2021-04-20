using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public new bool enabled = false;
    public float leftBounds;
    public float rightBounds;
    private float xPosRelative;
    private float xCenter;
    public bool movingRight = true;

    public GameObject sliderAnimDisplay;
    public GameObject sliderStaticDisplay;

    //private PlayerController playerControllerScript;
    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        xCenter = transform.position.x;
        //player = GameObject.Find("Player");
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>().transform
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            xPosRelative = transform.position.x - xCenter;
            if (xPosRelative < leftBounds)
            {
                movingRight = true;   
            } else if (xPosRelative > rightBounds)
            {
                movingRight = false;
            }

            if (movingRight)
            {
                moveRight();
            } else
            {
                moveLeft();
            }



            //make sure it moves the player that is on top of it too

        }
    }



    void moveRight()
    {
        transform.Translate(0.001f, 0, 0);
        //player.transform.Translate(0.002f, 0, 0);
        
    }

    void moveLeft()
    {
        transform.Translate(-0.001f, 0, 0);
        //player.transform.Translate(-0.002f, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (movingRight)
            {
                collision.transform.Translate(0.001f, 0, 0);
            } else
            {
                collision.transform.Translate(-0.001f, 0, 0);
            }
        }
    }


}
