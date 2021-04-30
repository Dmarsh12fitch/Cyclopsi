using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : MonoBehaviour
{
    public int portalLevel;
    private bool hasBeenCalled = false;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasBeenCalled)
        {
            player = collision.gameObject;
            player.GetComponent<PlayerController>().imobilized = true;
            player.GetComponent<PlayerController>().playerRigibody.velocity = new Vector3(0, 0, 0);
            player.GetComponent<PlayerController>().playerRigibody.constraints = RigidbodyConstraints2D.FreezeAll;
            player.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.5f);
            StartCoroutine(phase1());
        }
    }

    IEnumerator phase1()
    {
        yield return new WaitForSeconds(0.25f);
        player.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        StartCoroutine(phase2());
    }

    IEnumerator phase2()
    {
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(phase3());
    }

    IEnumerator phase3()
    {
        yield return new WaitForSeconds(0.25f);
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        StartCoroutine(phase4());
    }

    IEnumerator phase4()
    {
        yield return new WaitForSeconds(0.25f);
        StartCoroutine(phase5());
    }

    IEnumerator phase5()
    {
        yield return new WaitForSeconds(0.25f);
        player.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        StartCoroutine(toNextScene());
    }

    IEnumerator toNextScene()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(portalLevel + 1);
    }


}
