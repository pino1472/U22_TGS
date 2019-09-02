﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    [SerializeField]GameObject[] gameplay;
    [SerializeField ]int i;
    [SerializeField]Animator ani;
    [SerializeField] float time,cool;
    [SerializeField]AudioClip choiceSound;
    [SerializeField] AudioClip decisionSound;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        i = 0;
        for (int k = 0; gameplay.Length > k; k++)
        {
            ani = gameplay[k].GetComponent<Animator>();
            ani.SetBool("set", false);
        }
        ani = gameplay[i].GetComponent<Animator>();
        ani.SetBool("set", true);
    }

    void Quit()
    {
      #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
       #elif UNITY_STANDALONE
       UnityEngine.Application.Quit();
       #endif
    }

    // Update is called once per frame
    void Update()
    {
        float var = Input.GetAxisRaw("D Pad V"/*"L Stick V"*/);
        //float har = Input.GetAxis("L Stick H");
        time += Time.deltaTime; 
        if(time > cool)
        {
            
            if (/*(har!=0)||*/(var < 0))
            {
                audioSource.PlayOneShot(choiceSound);
                if (i == gameplay.Length - 1)
                {
                    i = 0;
                    for (int k = 0; gameplay.Length > k; k++)
                    {
                        ani = gameplay[k].GetComponent<Animator>();
                        ani.SetBool("set", false);
                    }
                    ani = gameplay[i].GetComponent<Animator>();
                    ani.SetBool("set", true);
                }
                else
                {
                    i++;
                    for (int k = 0; gameplay.Length > k; k++)
                    {
                        ani = gameplay[k].GetComponent<Animator>();
                        ani.SetBool("set", false);
                    }
                    ani = gameplay[i].GetComponent<Animator>();
                    ani.SetBool("set", true);
                }

                time = 0;
            }
            if (/*(har!=0)||*/(var > 0))
            {
                audioSource.PlayOneShot(choiceSound);
                if (i == 0)
                {
                    i = gameplay.Length - 1;
                    for (int k = 0; gameplay.Length > k; k++)
                    {
                        ani = gameplay[k].GetComponent<Animator>();
                        ani.SetBool("set", false);
                    }
                    ani = gameplay[i].GetComponent<Animator>();
                    ani.SetBool("set", true);
                }
                else
                {
                    i--;
                    for (int k = 0; gameplay.Length > k; k++)
                    {
                        ani = gameplay[k].GetComponent<Animator>();
                        ani.SetBool("set", false);
                    }
                    ani = gameplay[i].GetComponent<Animator>();
                    ani.SetBool("set", true);
                }

                time = 0;
            }
        }
        
        if (Input.GetKeyDown("joystick button 0"))
        {
            audioSource.PlayOneShot(decisionSound);
            if (gameplay[i].name == "start")
            {
                FadeManager.Instance.LoadScene("Game",0.5f);
            }
            else if (gameplay[i].name == "practice")
            {
                FadeManager.Instance.LoadScene("Practice",0.5f);
            }
            else if (gameplay[i].name == "end")
            {
                Quit();
                Debug.Log("終了");
            }
        }

       
    }
}
