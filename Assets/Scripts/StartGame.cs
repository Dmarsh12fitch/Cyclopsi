using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public bool gameHasNotStarted = true;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void startTheGame()
    {
        playerControllerScript.lookRight();
        playerControllerScript.fireLaser();
        StartCoroutine(phaseFinal());
    }


    IEnumerator phaseFinal()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
