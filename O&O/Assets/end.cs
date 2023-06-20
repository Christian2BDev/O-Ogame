using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class end : MonoBehaviour
{
    bool canPressE = false;


    public GameObject eSign;
 
    public TMP_Text text;
    GameObject colChest;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "endchest")
        {


            e(true);
            colChest = other.gameObject;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "endchest")
        {
            e(false);
        }
    }

    public void e(bool e)
    {
        canPressE = e;
        eSign.SetActive(canPressE);
    }

    public void Update()
    {
        if (canPressE && Input.GetKeyDown(KeyCode.F))
        {
            if (PlayerPrefs.GetInt("keys") == 10)
            {
                GameObject child1 = colChest.transform.GetChild(1).gameObject;
                child1.transform.Rotate(0, 0, 140);
                text.text = "you have finished the game, this world has now granted you the power to fly!";
                PlayerPrefs.SetInt("fly", 1);
                StartCoroutine(sleep(30));
                //fly
            }
        else
        {
            text.text = "you haven't collected all the keys!";
            StartCoroutine(sleep(5));

        }
        }
    }

    IEnumerator sleep(int secs)
    {
        yield return new WaitForSeconds(secs);
        text.text = "";
    }
}
