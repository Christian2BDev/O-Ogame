using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1;
    }
    public void stoppen() {
        SceneManager.LoadScene(0);
    }
}
