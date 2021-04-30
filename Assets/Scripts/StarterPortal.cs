using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterPortal : MonoBehaviour
{
    public GameObject starterPortalAnimDisplay;
    private PlayerController playercontrollerScript;

    // Start is called before the first frame update
    void Start()
    {
        playercontrollerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playercontrollerScript.imobilized = true;
        StartCoroutine(phase1());
    }

    IEnumerator phase1()
    {
        yield return new WaitForEndOfFrame();
        playercontrollerScript.playerRigibody.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(phase2());
    }

    IEnumerator phase2()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(1, 1, 1);            //see if there is some sort of smooth scaling for this + other
        StartCoroutine(phase3());
    }

    IEnumerator phase3()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        playercontrollerScript.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        playercontrollerScript.eyeStaticDisplay.SetActive(true);
        StartCoroutine(phase4());
    }

    IEnumerator phase4()
    {
        yield return new WaitForSeconds(0.25f);
        playercontrollerScript.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        StartCoroutine(phase5());
    }

    IEnumerator phase5()
    {
        yield return new WaitForSeconds(0.25f);
        playercontrollerScript.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        StartCoroutine(phase6());
    }

    IEnumerator phase6()
    {
        yield return new WaitForSeconds(0.25f);
        playercontrollerScript.transform.localScale = new Vector3(1, 1, 1);
        playercontrollerScript.imobilized = false;
        playercontrollerScript.playerRigibody.constraints = RigidbodyConstraints2D.None;
        playercontrollerScript.playerRigibody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playercontrollerScript.playerRigibody.AddForce(new Vector3(0, 1, 0), ForceMode2D.Impulse);
        StartCoroutine(phase7());
    }

    IEnumerator phase7()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(phase8());
    }

    IEnumerator phase8()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        StartCoroutine(phase9());
    }

    IEnumerator phase9()
    {
        yield return new WaitForSeconds(0.5f);
        starterPortalAnimDisplay.SetActive(false);
    }
}
