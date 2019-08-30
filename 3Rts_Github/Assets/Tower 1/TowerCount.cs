using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerCount : MonoBehaviour
{

    /*残りのタワー数*/
    public TextMeshProUGUI countLabel;
    GameObject[] center, right, left; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        /*タワータグを検知する機能*/
        center = GameObject.FindGameObjectsWithTag ("Tower_center");
        right = GameObject.FindGameObjectsWithTag("Tower_rigth");
        left = GameObject.FindGameObjectsWithTag("Tower_left");

        countLabel.text = (center.Length + right.Length + left.Length-3).ToString();
    }
}
