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
    public TMP_Text fout;
    public TMP_Text foundallkeys;
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
            
            genNumb();
            if (modifier == 1) { som.text = (getal1 +" + "+getal2).ToString(); }
            if (modifier == 2) { som.text = (getal1 +" - "+ getal2).ToString(); }
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            
        }
    }
    public void Check() {
        string ans = (getal1+ getal2).ToString();
        string ansN = (getal1 - getal2).ToString();
        if (modifier == 1) { if (answer.text.Equals(ans)) { dis(); } else { fout.text = "Dat is fout! probeer het opnieuw!"; } }
        else if (modifier == 2) { if (answer.text.Equals(ansN)) { dis(); } else { fout.text = "Dat is fout! probeer het opnieuw!"; } }
        

    }
    public void dis() {
        answer.text = "";
        fout.text = "";
        menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        GameObject child1 = colChest.transform.GetChild(1).gameObject;
        colChest.transform.GetChild(2).gameObject.SetActive(false);
        child1.transform.Rotate(0, 0, 140);
        colChest.tag = "Untagged";
        e(false);
        colChest.transform.GetChild(3).gameObject.SetActive(false);
        if (colChest.transform.GetChild(4).gameObject.name == "yes") { PlayerPrefs.SetInt("keys", PlayerPrefs.GetInt("keys") + 1); /*give key*/ }
        if (PlayerPrefs.GetInt("keys") == 10) { foundallkeys.text = "je hebt alle sleutels gevonden! ga naar de boom van leven"; StartCoroutine(sleep(5)); }
    }

    public void e(bool e) {
        canPressE = e;
        eSign.SetActive(canPressE);
    }

    void genNumb() {
        getal1 = Random.Range(0, 20);
        getal2 = Random.Range(0, 20);
        modifier = Random.Range(1, 3);
        while (getal1-getal2 <= 0) {
            getal1 = Random.Range(0, 20);
            getal2 = Random.Range(0, 20);
        }
    }

   

        

IEnumerator sleep(int secs)
{
    yield return new WaitForSeconds(secs);
        foundallkeys.text = "";
}
}
