﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIctl : MonoBehaviour
{
    /*[SerializeField] int e;
    [SerializeField] Sprite[] Item;
    [SerializeField] GameObject[] Item_UI;
    GameObject Back;*/
    [SerializeField] GameObject Player;
    [SerializeField]TextMeshProUGUI skillPointText;
    public int skillPoint;
    // Start is called before the first frame update
    void Start()
    {
        /*Back = GameObject.Find("Item_Background");
        Back.SetActive(false);
        for (int i = 0; i < Item_UI.Length; i++)
        {
<<<<<<< HEAD
            Item_UI[i].GetComponent<Image>().sprite = Item[i];//添え字を振っていく
        }
=======
            Item_UI[i].GetComponent<Image>().sprite = Item[i];
        }*/
>>>>>>> origin/hiiragi10
        skillPoint = 0;
    }
    // Update is called once per frame
    void Update()
    {
        skillPointText.text = skillPoint.ToString();
        /*if (Input.GetAxisRaw("L R Trigger") < 0 || Input.GetKey("z"))
        {
            Back.SetActive(true);
            if (Input.GetButtonDown("joystick Y"))
            {
                e--;
                if (e < 0) e += Item.Length;//0まできたら最初に戻る
                imagechange();
            }
            if (Input.GetButtonDown("joystick X"))
            {
                e++;
                if (e >= Item.Length) e -= Item.Length;//要素数を超えないようにする→最初に戻る？
                imagechange();
            }*/
           if (skillPoint > 0)
           {
            Player.GetComponent<PlayerStatus>().PHp += 500;
            Player.GetComponent<TurretSet>().maxMilitary += 1;
            Player.GetComponent<PlayerStatus>().AttackPower += 50;
            skillPoint -= 1;
            /*if (Input.GetButtonDown("R1"))
            {
                if (Item_UI[0].GetComponent<Image>().sprite.name == "体")
                {
                    Player.GetComponent<PlayerStatus>().PHp += 500;
                }
                if (Item_UI[0].GetComponent<Image>().sprite.name == "兵")
                {
                    Player.GetComponent<TurretSet>().maxMilitary += 1;
                }
                if (Item_UI[0].GetComponent<Image>().sprite.name == "力")
                {
                    Player.GetComponent<PlayerStatus>().AttackPower += 50;
                }
                skillPoint -= 1;
            }*/
        }
    }

    /*private void imagechange()
    {
        for (int k = 0; k < Item_UI.Length; k++)
        {
            int g;
            g = e + k;
            if (g >= Item.Length) g -= Item.Length;
            if (g >= 0)
            {
                Item_UI[k].GetComponent<Image>().sprite = Item[g];
            }
            else
            {
                g = Item.Length - 1;
                Item_UI[k].GetComponent<Image>().sprite = Item[g];
            }
        }
    }*/
 }