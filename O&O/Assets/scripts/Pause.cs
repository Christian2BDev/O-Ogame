using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool paused = false;
    public GameObject pausescreen;
    bool esignwason = false;
    public GameObject eSign;
    
     
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            
            if (!paused)
            {
                if (eSign.activeSelf) {
                    esignwason = true;
                    setOn();
                } else { esignwason = false; }
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                paused= true;
                pausescreen.SetActive(paused);
            }
            else {
                if (esignwason) { setOn(); }
               
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                paused = false;
                pausescreen.SetActive(paused);
            }
        }
    }
    void setOn() {
            
           eSign.SetActive(paused);
        
    }
}
