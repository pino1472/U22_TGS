using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        if (Input.GetButton("Start"))
        {
            pauseText.SetActive(true);
           
        }
        if (Input.GetKeyDown("joystick button 0"))
        {
            pauseText.SetActive(false);
        }
        if (Input.GetButton("Back"))
        {
            SceneManager.LoadScene("Startmeny");
        }
    }
}
