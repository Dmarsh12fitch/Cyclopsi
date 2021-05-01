using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void startTheGame()
    {
        playerControllerScript.fireLaser();
        StartCoroutine(phaseFinal());
    }


    IEnumerator phaseFinal()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(1);
    }
}
