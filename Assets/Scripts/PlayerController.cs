using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public Rigidbody2D playerRigibody;

    public GameObject eyeIdleAnimDisplay;
    public GameObject eyeStaticDisplay;
    public GameObject eyeLookUpAnimDisplay;
    public GameObject eyeLookUpStaticDisplay;
    public GameObject eyeFrontStaticDisplay;
    public GameObject eyeFrontAnimDisplay;

    public GameObject eyeFireAnimDisplay;
    public GameObject eyeFireUpAnimDisplay;
    public GameObject eyeFireStaticDisplay;
    public GameObject eyeFireUpStaticDisplay;

    public GameObject laser;
    public List<GameObject> laserTileArray;
    private int laserTilesMade;

    public float speed;
    public float jumpForce;
    public bool isOnGround = true;
    public string isLooking = "right";
    public bool imobilized;
    public bool hashitsomething = false;

    private float idleDelay = 1;
    private float idleDelayMax = 1;

    private float laserPreviousX;
    private float laserPreviousY;

    private bool onMushroomTop = false;
    private bool onSlider = false;



    // Start is called before the first frame update
    void Start()
    {
        playerRigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!imobilized)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            playerRigibody.velocity = new Vector3((horizontalInput * speed), playerRigibody.velocity.y, 0);

            //looking left or right
            if (horizontalInput > 0)
            {
                lookLeft();
            }
            else if (horizontalInput < 0)
            {
                lookRight();
            }

            //looking up
            if (Input.GetKeyDown(KeyCode.W))
            {
                lookUp();
            }

            //looking forward
            if (Input.GetKeyDown(KeyCode.S))
            {
                lookCamera();
                if (onMushroomTop)
                {
                    transform.position = new Vector3(transform.position.x, (transform.position.y - 0.16f), transform.position.z);
                }
            }

            //jump
            if (Input.GetButtonDown("Jump") && isOnGround)
            {
                jump();
            }

            //fire Lazer
            if (Input.GetButtonDown("Fire3"))
            {
                if (!onSlider)
                {
                    fireLaser();
                }
            }

            //idle or static
            if (Mathf.Abs(horizontalInput) <= 0.001f)
            {
                if (idleDelay < 0)
                {
                    if (isLooking.Equals("up"))
                    {
                        eyeIdleAnimDisplay.SetActive(false);
                        eyeStaticDisplay.SetActive(false);
                        eyeLookUpAnimDisplay.SetActive(true);
                        eyeLookUpStaticDisplay.SetActive(false);
                        eyeFrontStaticDisplay.SetActive(false);
                        eyeFrontAnimDisplay.SetActive(false);
                    } else if (isLooking.Equals("camera"))
                    {
                        eyeIdleAnimDisplay.SetActive(false);
                        eyeStaticDisplay.SetActive(false);
                        eyeLookUpAnimDisplay.SetActive(false);
                        eyeLookUpStaticDisplay.SetActive(false);
                        eyeFrontStaticDisplay.SetActive(false);
                        eyeFrontAnimDisplay.SetActive(true);
                    } else
                    {
                        eyeIdleAnimDisplay.SetActive(true);
                        eyeStaticDisplay.SetActive(false);
                        eyeLookUpAnimDisplay.SetActive(false);
                        eyeLookUpStaticDisplay.SetActive(false);
                        eyeFrontStaticDisplay.SetActive(false);
                        eyeFrontAnimDisplay.SetActive(false);
                    }
                    idleDelay = idleDelayMax;
                }
                idleDelay -= Time.deltaTime;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Button")) && collision.transform.position.y < transform.position.y)
        {
            if (isOnGround == false)
            {
                //this is when it first lands (perhaps an effect?)
            }
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Slider"))
        {
            isOnGround = true;
            onSlider = true;
            transform.parent = collision.gameObject.transform;
        }
        if (collision.gameObject.CompareTag("jumpPlatform"))
        {
            isOnGround = true;
            jumpForce = 4;
        }
        if (collision.gameObject.CompareTag("mushroomTop"))
        {
            isOnGround = true;
            onMushroomTop = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slider"))
        {
            onSlider = false;
            transform.parent = null;
        } else if (collision.gameObject.CompareTag("jumpPlatform"))
        {
            jumpForce = 2.5f;
        } else if (collision.gameObject.CompareTag("mushroomTop"))
        {
            onMushroomTop = false;
        }
    }


    void lookUp()
    {
        isLooking = "up";
        eyeLookUpAnimDisplay.SetActive(false);
        eyeStaticDisplay.SetActive(false);
        eyeIdleAnimDisplay.SetActive(false);
        eyeLookUpStaticDisplay.SetActive(true);
        eyeFrontAnimDisplay.SetActive(false);
        eyeFrontAnimDisplay.SetActive(false);
    }

    void lookCamera()
    {
        isLooking = "camera";
        eyeLookUpAnimDisplay.SetActive(false);
        eyeStaticDisplay.SetActive(false);
        eyeIdleAnimDisplay.SetActive(false);
        eyeLookUpStaticDisplay.SetActive(false);
        eyeFrontAnimDisplay.SetActive(false);
        eyeFrontStaticDisplay.SetActive(true);
    }


    public void lookLeft()
    {
        isLooking = "left";
        eyeIdleAnimDisplay.transform.rotation = new Quaternion(0, 0, 0, 0);
        eyeStaticDisplay.transform.rotation = new Quaternion(0, 0, 0, 0);
        eyeFireAnimDisplay.transform.rotation = new Quaternion(0, 0, 0, 0);
        eyeFireStaticDisplay.transform.rotation = new Quaternion(0, 0, 0, 0);
        eyeLookUpAnimDisplay.SetActive(false);
        eyeStaticDisplay.SetActive(true);
        eyeIdleAnimDisplay.SetActive(false);
        eyeLookUpStaticDisplay.SetActive(false);
        eyeFrontAnimDisplay.SetActive(false);
        eyeFrontStaticDisplay.SetActive(false);
        idleDelay = idleDelayMax;
    }

    public void lookRight()
    {
        isLooking = "right";
        eyeIdleAnimDisplay.transform.rotation = new Quaternion(0, 180, 0, 0);
        eyeStaticDisplay.transform.rotation = new Quaternion(0, 180, 0, 0);
        eyeFireAnimDisplay.transform.rotation = new Quaternion(0, 180, 0, 0);
        eyeFireStaticDisplay.transform.rotation = new Quaternion(0, 180, 0, 0);
        eyeLookUpAnimDisplay.SetActive(false);
        eyeStaticDisplay.SetActive(true);
        eyeIdleAnimDisplay.SetActive(false);
        eyeLookUpStaticDisplay.SetActive(false);
        eyeFrontAnimDisplay.SetActive(false);
        eyeFrontStaticDisplay.SetActive(false);
        idleDelay = idleDelayMax;
    }

    void jump()
    {
        if (isLooking.Equals("up"))
        {
            eyeIdleAnimDisplay.SetActive(false);
            eyeLookUpAnimDisplay.SetActive(false);
            eyeStaticDisplay.SetActive(false);
            eyeLookUpStaticDisplay.SetActive(true);
            eyeFrontAnimDisplay.SetActive(false);
            eyeFrontAnimDisplay.SetActive(false);
        } else if (isLooking.Equals("camera"))
        {
            eyeIdleAnimDisplay.SetActive(false);
            eyeStaticDisplay.SetActive(false);
            eyeLookUpAnimDisplay.SetActive(false);
            eyeLookUpStaticDisplay.SetActive(false);
            eyeFrontStaticDisplay.SetActive(true);
            eyeFrontAnimDisplay.SetActive(false);
        } else
        {
            eyeIdleAnimDisplay.SetActive(false);
            eyeLookUpAnimDisplay.SetActive(false);
            eyeStaticDisplay.SetActive(true);
            eyeLookUpStaticDisplay.SetActive(false);
            eyeFrontAnimDisplay.SetActive(false);
            eyeFrontAnimDisplay.SetActive(false);
        }
        isOnGround = false;
        playerRigibody.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
        idleDelay = idleDelayMax;
    }

    public void fireLaser()
    {
        imobilized = true;
        playerRigibody.constraints = RigidbodyConstraints2D.FreezeAll;
        hashitsomething = false;
        laserPreviousX = transform.position.x;
        laserPreviousY = transform.position.y;
        laserTilesMade = 0;
        if(isLooking == "up")
        {
            eyeFireUpAnimDisplay.SetActive(true);
        } else if(isLooking == "right" || isLooking == "left")
        {
            eyeFireAnimDisplay.SetActive(true);
        }
        StartCoroutine(stopFireAnim());
    }

    IEnumerator stopFireAnim()
    {
        yield return new WaitForSeconds(0.4f);         //different time
        if(isLooking == "up")
        {
            eyeFireUpAnimDisplay.SetActive(false);
            eyeFireUpStaticDisplay.SetActive(true);
        } else if (isLooking == "right" || isLooking == "left")
        {
            eyeFireAnimDisplay.SetActive(false);
            eyeFireStaticDisplay.SetActive(true);
        }
        InvokeRepeating("makeALaserTile", 0, 0.02f);
    }

    void makeALaserTile()
    {
        if (hashitsomething || laserTilesMade >= 60)
        {
            CancelInvoke("makeALaserTile");
            StartCoroutine(destroyLasers());
        }

        if (isLooking == "right" && !hashitsomething)
        {
            Vector3 spawnPos = new Vector3((laserPreviousX - 0.08f), (laserPreviousY + 0.02f), 0.3f);
            GameObject go = Instantiate(laser, spawnPos, Quaternion.identity);
            laserTileArray.Add(go);
            laserPreviousX = laserPreviousX - 0.08f;
            laserTilesMade++;
        } else if (isLooking == "left" && !hashitsomething)
        {
            Vector3 spawnPos = new Vector3((laserPreviousX + 0.08f), (laserPreviousY + 0.02f), 0.3f);
            GameObject go = Instantiate(laser, spawnPos, Quaternion.identity);
            laserTileArray.Add(go);
            laserPreviousX = laserPreviousX + 0.08f;
            laserTilesMade++;
        } else if (isLooking.Equals("up") && !hashitsomething)
        {
            Vector3 spawnPos = new Vector3(laserPreviousX, (laserPreviousY + 0.08f), 0.3f);
            Quaternion spawnRot = new Quaternion(0, 0, 90, 90);
            GameObject go = Instantiate(laser, spawnPos, spawnRot);
            laserTileArray.Add(go);
            laserPreviousY = laserPreviousY + 0.08f;
            laserTilesMade++;
        }
    }

    IEnumerator destroyLasers()
    {
        //destroy lasers and unpause
        yield return new WaitForSeconds(1f);
        eyeFireStaticDisplay.SetActive(false);
        eyeFireUpStaticDisplay.SetActive(false);
        imobilized = false;
        playerRigibody.constraints = RigidbodyConstraints2D.None;
        playerRigibody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerRigibody.AddForce(new Vector3(0, 0.1f, 0), ForceMode2D.Impulse);
        foreach(GameObject go in laserTileArray)
        {
            Destroy(go);
        }
    }



}
