using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderButton : MonoBehaviour
{
    private bool hasBeenPressed = false;
    public GameObject buttonUpDisplay;
    public GameObject buttonAnimDisplay;
    public GameObject buttonPressedDisplay;

    public GameObject mySlider;

    public bool isFaceUpToBeSteppedOn;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //trigger enter places the player displays above

        if (collision.gameObject.CompareTag("Player") && !hasBeenPressed)
        {
            if (isFaceUpToBeSteppedOn)
            {
                if(collision.gameObject.transform.position.y >= transform.position.y + 0.06f)
                {
                    buttonPress();
                }
            } else
            {
                buttonPress();
            }
        }
    }

    public void buttonPress()
    {
        if (!hasBeenPressed)
        {
            hasBeenPressed = true;
            buttonUpDisplay.SetActive(false);
            buttonAnimDisplay.SetActive(true);
            StartCoroutine(endAnimTimer());
        }
    }


    IEnumerator endAnimTimer()
    {
        yield return new WaitForSeconds(.4f);
        buttonAnimDisplay.SetActive(false);
        buttonPressedDisplay.SetActive(true);
        mySlider.GetComponent<Slider>().sliderStaticDisplay.SetActive(false);
        mySlider.GetComponent<Slider>().sliderAnimDisplay.SetActive(true);
        mySlider.GetComponent<Slider>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().radius = 0.06f;
    }

}
