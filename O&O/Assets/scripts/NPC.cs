using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    bool canPressE = false;
    Transform t;

    public  GameObject eSign;
    public GameObject menu;
    GameObject colChest;
    public TMP_Text som;
    public int getal1;
    public int getal2;
    public int modifier;
   
    public TMP_InputField answer;


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
            if (modifier == 1) { som.text = (getal1 +" + "+getal2).ToString(); }
            if (modifier == 2) { som.text = (getal1 +" - "+ getal2).ToString(); }
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            
        }
    }
    public void Check() {
        if (modifier == 1) { if (answer.text.Equals((getal1 + getal2))) { dis(); } }
        else if (modifier == 2) { if (answer.text.Equals((getal1 - getal2))) { dis(); } }
        else { Debug.Log("wrong"); }

    }
    public void dis() {
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
