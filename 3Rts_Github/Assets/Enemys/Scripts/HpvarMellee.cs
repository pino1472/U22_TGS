using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpvarMellee : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] bool pcr;                       //HPバーの可視化
    [SerializeField] bool isMelee;
    bool isAcrher;
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

        isMelee = enemy.GetComponent<MeleeEnemyHp>().hpUi;

        //isAcrher = enemy.GetComponent<ArcherHp>().hpUi;
        Vector3 targetPos = Camera.main.transform.position;
        // ターゲットのY座標を自分と同じにすることで2次元に制限する。
        targetPos.y = this.transform.position.y;
        transform.LookAt(targetPos);

        if (pcr == true || isMelee == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
