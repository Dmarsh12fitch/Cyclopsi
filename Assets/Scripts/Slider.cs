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

    public float speed;

    public GameObject sliderAnimDisplay;
    public GameObject sliderStaticDisplay;

    // Start is called before the first frame update
    void Start()
    {
        xCenter = transform.position.x;
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
            }
            else if (xPosRelative > rightBounds)
            {
                movingRight = false;
            }

            if (movingRight)
            {
                moveRight();
            }
            else
            {
                moveLeft();
            }
        }
    }

    void moveRight()
    {
        transform.Translate(speed, 0, 0);
        
    }

    void moveLeft()
    {
        transform.Translate(-speed, 0, 0);
    }

}
