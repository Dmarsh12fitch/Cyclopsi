using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPortal : MonoBehaviour
{
    public int portalLevel;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().imobilized = true;
            collision.gameObject.GetComponent<PlayerController>().playerRigibody.velocity = new Vector3(0, 0, 0);
            collision.gameObject.GetComponent<PlayerController>().playerRigibody.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(toNextScene());
            collision.gameObject.GetComponent<PlayerController>().transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0.1f);
            //DO SOME animation (for now is just ^^)
        }
    }

    IEnumerator toNextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(portalLevel + 1);
    }


}
