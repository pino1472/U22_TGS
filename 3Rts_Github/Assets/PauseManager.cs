using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    //[SerializeField] GameObject[] pasue;
    //[SerializeField] int x;
    //[SerializeField] Animator aru;
    //[SerializeField]float time,asy;
  
    void Start()
    {
        //x = 0;
        //for (int y = 0; pasue.Length > y; y++)
        //{
        //    aru = pasue[y].GetComponent<Animator>();
        //    aru.SetBool("aut", false);
        //}
        //aru = pasue[x].GetComponent<Animator>();
        //aru.SetBool("aut", true);
    }

    // Update is called once per frame
    void Update()
    {

        //float har = Input.GetAxis("L Stick H");
        //time += Time.deltaTime;
        //if (time > asy)
        //{
        //    if (har < 0)
        //    {
        //        if (x == pasue.Length - 1)
        //        {
        //            for (int y = 0; pasue.Length > y; y++)
        //            {
        //                aru = pasue[y].GetComponent<Animator>();
        //                aru.SetBool("aut", false);
        //            }
        //            aru = pasue[x].GetComponent<Animator>();
        //            aru.SetBool("aut", true);
        //        }
        //        else
        //        {
        //            x++;
        //            for (int y = 0; pasue.Length > y; y++)
        //            {
        //                aru = pasue[y].GetComponent<Animator>();
        //                aru.SetBool("aut", false);
        //            }
        //            aru = pasue[x].GetComponent<Animator>();
        //            aru.SetBool("aut", true);
        //        }
        //        time = 0;
        //    }
        //    if (har > 0)
        //    {
        //        if (x == 0)
        //        {
        //            x = pasue.Length - 1;
        //            for (int y = 0; pasue.Length > y; y++)
        //            {
        //                aru = pasue[y].GetComponent<Animator>();
        //                aru.SetBool("aut", false);
        //            }
        //            aru = pasue[x].GetComponent<Animator>();
        //            aru.SetBool("aut", true);
        //        }
        //        else
        //        {
        //            x--;
        //            for (int y = 0; pasue.Length > y; y++)
        //            {
        //                aru = pasue[y].GetComponent<Animator>();
        //                aru.SetBool("aut", false);
        //            }
        //            aru = pasue[x].GetComponent<Animator>();
        //            aru.SetBool("aut", true);
        //        }
        //        time = 0;
        //    }
        //}

        //if(Input.GetKeyDown("joystick button 0"))
        //{

        //}


        if (Input.GetButton("Start")&&Time.timeScale ==1)
        {
            Time.timeScale = 0; 
            
        }

        if (Input.GetButton("Start") && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

    }
}

