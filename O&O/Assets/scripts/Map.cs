using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapGUI;
    public GameObject minimapGUI;
    public GameObject minimapBG;
    bool enabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){
            enabled = !enabled;
            mapGUI.SetActive(enabled);
            minimapGUI.SetActive(!enabled);
            minimapBG.SetActive(!enabled);
        }
            
    }
}
