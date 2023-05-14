using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    bool canPressE = false;
    Transform t;

    public  GameObject eSign;
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "npc" || other.gameObject.tag == "chest")
        {
            canPressE = true;
            t = other.gameObject.transform;
            eSign.SetActive(canPressE);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "npc" || other.gameObject.tag == "chest")
        {
            canPressE = false;
            eSign.SetActive(canPressE);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPressE)
        {
            Debug.Log("you talked to an npc at" + t.position);

        }
    }
}
