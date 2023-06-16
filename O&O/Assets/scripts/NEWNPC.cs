using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class NEWNPC : MonoBehaviour
{

    GameObject colChest;
    bool canPressE = false;
    Transform t;
    public GameObject eSign;
    public GameObject menu;
    public TMP_Text location;
    public GameObject text;

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canPressE)
        {
            if (int.Parse(colChest.transform.GetChild(1).gameObject.name) == PlayerPrefs.GetInt("stage"))
            {
                telling(colChest.transform.GetChild(0).gameObject.name);
            }
            else {
                text.SetActive(true);
                StartCoroutine(cant(5));
            }
           

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "npc" )
        {

            t = other.gameObject.transform;
            e(true);
            colChest = other.gameObject;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "npc" )
        {
            e(false);
        }
    }

    public void e(bool e)
    {
        canPressE = e;
        eSign.SetActive(canPressE);
    }

    public void telling(string wo) {
        location.text = wo;
        Debug.Log("you talked to an npc at" + t.position);
        menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void close() {
        PlayerPrefs.SetInt("stage", PlayerPrefs.GetInt("stage") + 1);
        menu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

    }

    IEnumerator cant(int secs)
    {
        yield return new WaitForSeconds(secs);
        text.SetActive(false);
    }


}
    

    


