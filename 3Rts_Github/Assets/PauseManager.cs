﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (Input.GetButton("Back") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }



    }
    }

