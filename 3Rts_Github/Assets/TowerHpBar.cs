using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHpBar : MonoBehaviour
{
    GameObject player;
    [SerializeField] bool pcr;                       //HPバーの可視化
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Camera.main.transform.position;
        // ターゲットのY座標を自分と同じにすることで2次元に制限する。
        targetPos.y = this.transform.parent.position.y;
        transform.parent.LookAt(targetPos);

        pcr = player.GetComponent<PlayerController>().HPvar;
        if (pcr == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
