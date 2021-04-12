using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody playerRigibody;

    public Transform eyeAnimDisplay;
    public float speed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0)
        {
            eyeAnimDisplay.rotation = new Quaternion(0, 0, 0, 0);
        } else if(horizontalInput < 0)
        {
            eyeAnimDisplay.rotation = new Quaternion(0, 180, 0, 0);
        }

        playerRigibody.velocity = new Vector3((horizontalInput * speed), playerRigibody.velocity.y, 0);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(playerRigibody.velocity.y) < 0.0001f)
        {
            playerRigibody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }



    }
}
