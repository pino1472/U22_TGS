using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHpVar : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject lady;
    [SerializeField] bool pcr;                       //HPバーの可視化
    [SerializeField] bool isMinion;
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        //enemy = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        pcr = player.GetComponent<PlayerController>().HPvar;

        isMinion = lady.GetComponent<NpcStatus>().ladyHpUI;

        Vector3 targetPos = Camera.main.transform.position;
        // ターゲットのY座標を自分と同じにすることで2次元に制限する。
        targetPos.y = this.transform.position.y;
        transform.LookAt(targetPos);

        if (pcr == true || isMinion == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
