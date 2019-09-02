using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start")&&Time.timeScale ==1)
        {
            Time.timeScale = 0;

        }

        if (Input.GetButton("joystick A") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        if (Input.GetButton("Back") && Time.timeScale == 0)
        {
            FadeManager.Instance.LoadScene("Startmeny",0.5f);
            Time.timeScale = 1;
        }



    }
    }

