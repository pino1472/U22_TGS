using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    bool trigger, backtrigger;
    // Start is called before the first frame update
    void Start()
    {
        backtrigger = false;
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!backtrigger)
        {
            if (Input.GetButtonDown("Start"))
            {
                trigger = !trigger;
            }
            if (trigger)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        if (Input.GetButton("Back") && Time.timeScale == 0)
        {
            backtrigger = true;
            FadeManager.Instance.LoadScene("Startmeny", 0.5f);
            Time.timeScale = 1;
        }



    }
}

