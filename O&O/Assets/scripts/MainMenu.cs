using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void menu(string button)
    {
        if (button.Equals("play"))
        {
            SceneManager.LoadScene("game");
        }
        if (button.Equals("settings"))
        {
            Application.Quit();
            Debug.Log("settings");
        }
        if (button.Equals("quit")) {
            Application.Quit();
            Debug.Log("Quiting");
        }

        
    }

   
}
