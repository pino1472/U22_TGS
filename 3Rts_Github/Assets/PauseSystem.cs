using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseSystem : MonoBehaviour
{

    public GameObject pauseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            pauseText.SetActive(!pauseText.activeSelf);
        }
        //if (Input.GetButton("joystick B"))
        //{
        //    pauseText.SetActive(false);
        //}
    }
}
