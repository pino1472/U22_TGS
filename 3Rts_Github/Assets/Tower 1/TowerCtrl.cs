﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : MonoBehaviour
{
    [SerializeField] GameObject UI;
    public int Hp;
    public ParticleSystem particle_arrow;
    public ParticleSystem particle_sword;
    public GameObject player, nearObj;
    // Start is called before the first frame update
    void Start()
    {
        particle_arrow.Stop();
        particle_sword.Stop();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            UI.GetComponent<UIctl>().skillPoint += 1;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "P_Sword")
        {
            Hp -= player.GetComponent<PlayerStatus>().AttackPower + 50;
            //Debug.Log(player.GetComponent<PlayerStatus>().AttackPower + "塔");
            particle_sword.Play();
        }

        if(other.gameObject.tag == "NPC_Sword")
        {
            Hp -= 20;
            particle_arrow.Play();
        }
    }
}
