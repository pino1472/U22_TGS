using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            FadeManager.Instance.LoadScene("Practice", 0.5f);
        }
        if (Input.GetButtonDown("Back"))
        {
            FadeManager.Instance.LoadScene("Startmeny", 0.5f);
        }
    }
}
