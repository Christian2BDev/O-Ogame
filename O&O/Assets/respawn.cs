using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Vector3 v;
    public GameObject text;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "sea") {

            this.gameObject.transform.position = v;
            text.SetActive(true);
      
            StartCoroutine(sleep(5));

        }

        IEnumerator sleep(int secs)
        {
            yield return new WaitForSeconds(secs);
            text.SetActive(false);
        }
    }
}
