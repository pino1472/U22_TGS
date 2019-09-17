using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpvar : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField]bool pcr,isArcher;                       //HPバーの可視化
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        pcr = player.GetComponent<PlayerController>().HPvar;
        isArcher = enemy.GetComponent<ArcherHp>().hpUi;
        Vector3 targetPos = Camera.main.transform.position;
        // ターゲットのY座標を自分と同じにすることで2次元に制限する。
        targetPos.y = this.transform.position.y;
        transform.LookAt(targetPos);

        if (pcr == true||isArcher==true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
