using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inv;
    public bool on = false;
    public GameObject Had ;
    public GameObject Necklase;
    public GameObject Ring;
    public GameObject Cape;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Had", 1);
        PlayerPrefs.SetInt("Necklase", 1);
        PlayerPrefs.SetInt("Ring", 1);
        PlayerPrefs.SetInt("Cape", 1);
        if (PlayerPrefs.GetInt("Had") == 1) { EnabledIcons("Had", true); }
        if (PlayerPrefs.GetInt("Necklase") == 1) { EnabledIcons("Necklase", true); }
        if (PlayerPrefs.GetInt("Ring") == 1) { EnabledIcons("Ring", true); }
        if (PlayerPrefs.GetInt("Cape") == 1) { EnabledIcons("Cape", true); }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            on = !on;
            inv.SetActive(on);
            if (on) { Cursor.lockState = CursorLockMode.None; Time.timeScale = 0; }
            if (!on) { Cursor.lockState = CursorLockMode.Locked; Time.timeScale = 1; }

        }
    }

    

    public void inventoryEnable(string sort) {
        if (PlayerPrefs.GetInt(sort) == 1)
        {
            if (PlayerPrefs.GetInt(sort + "Enabled") == 1) {
                PlayerPrefs.SetInt(sort + "Enabled", 0);
                //disabling
                EnabledIcons(sort, false);
            }
            else
            {
                PlayerPrefs.SetInt(sort + "Enabled", 1);
                Debug.Log(sort + " is enabled");
                //enabling
                EnabledIcons(sort, true);
            }
            
        }
        else {
            
        }
    }
    public void EnabledIcons(string s, bool o) {
        if (s.Equals("Had")) { Had.SetActive(o); }
        if (s.Equals("Necklase")) { Necklase.SetActive(o); }
        if (s.Equals("Ring")) { Ring.SetActive(o); }
        if (s.Equals("Cape")) { Cape.SetActive(o); }
    }
}
