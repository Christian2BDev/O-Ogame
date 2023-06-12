using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Atifacs : MonoBehaviour
{
    public TMP_Text speed;
    public TMP_Text jump;
    public TMP_Text hint;
    public TMP_Text djump;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("HadEnabled") == 1) { /*change hints boolean*/ hint.text = "ja"; Hints(true); } else { hint.text = "nee"; Hints(false); }
        if (PlayerPrefs.GetInt("NecklaseEnabled") == 1) { /*change jump modifier*/ jump.text = "2x"; Movement.modij = 2; } else { jump.text = "1x"; Movement.modij = 1; }
        if (PlayerPrefs.GetInt("RingEnabled") == 1) { /*change Speed modifier*/ speed.text = "2x"; Movement.modi = 2; } else { speed.text = "1x"; Movement.modi = 1; }
        if (PlayerPrefs.GetInt("CapeEnabled") == 1) { /*change duble jump boolean*/ djump.text = "ja"; Movement.jumpmodi = 2; } else { djump.text = "nee"; Movement.jumpmodi = 1; }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Artifact")
        {
            PlayerPrefs.SetInt(other.gameObject.name, 1);
        }
    }

    public void Hints(bool state)
    {
        GameObject[] chests = GameObject.FindGameObjectsWithTag("chest");
        foreach (GameObject chest in chests) {
            chest.transform.GetChild(3).gameObject.SetActive(state);
        }


    }
}
