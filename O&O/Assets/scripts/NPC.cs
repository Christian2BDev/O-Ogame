using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    bool canPressE = false;
    Transform t;

    public  GameObject eSign;
    public GameObject menu;
    GameObject colChest;
   
   
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "chest")
        {
            
            t = other.gameObject.transform;
            e(true);
            colChest = other.gameObject;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "chest")
        {
            e(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canPressE)
        {
            Debug.Log("you talked to an npc at" + t.position);
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;

        }
    }
    public void Check() {

        //als antwoord goed is
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
         GameObject child1 = colChest.transform.GetChild(1).gameObject;
        colChest.transform.GetChild(2).gameObject.SetActive(false);
        child1.transform.Rotate(0, 0, 140);
        colChest.tag = "Untagged";
        e(false);
        colChest.transform.GetChild(3).gameObject.SetActive(false);

    }

    public void e(bool e) {
        canPressE = e;
        eSign.SetActive(canPressE);
    }
}
