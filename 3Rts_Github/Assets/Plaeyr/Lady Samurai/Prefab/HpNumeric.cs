﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpNumeric : MonoBehaviour
{
    [SerializeField] GameObject player;    
    [SerializeField] TextMeshProUGUI hpTmp;
    [SerializeField] TextMeshProUGUI mpTmp;


    // Start is called before the first frame update
    void Start()
    {        
        hpTmp = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        mpTmp = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        hpTmp.text = player.GetComponent<PlayerStatus>().PHp.ToString();
        mpTmp.text = player.GetComponent<TurretSet>().militaryforce.ToString();        
    }
}
