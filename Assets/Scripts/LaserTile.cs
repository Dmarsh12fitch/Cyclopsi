using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTile : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private bool hascollidedOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Button") && !hascollidedOnce)
        {
            collision.gameObject.GetComponent<SliderButton>().buttonPress();
            playerControllerScript.hashitsomething = true;
            hascollidedOnce = true;
        } else if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Laser") && !hascollidedOnce)
        {
            hascollidedOnce = true;
            playerControllerScript.hashitsomething = true;
        }
    }

}
