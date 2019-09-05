using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyCoreHpjoint : MonoBehaviour
{
    Image enemyHpvar;
    AllyCoreCtrl AllyCoreHp;
    float Maxhp;
    // Start is called before the first frame update
    void Start()
    {
        enemyHpvar = GetComponent<Image>();
        AllyCoreHp = transform.root.GetComponent<AllyCoreCtrl>();
        Maxhp = AllyCoreHp.AllyCoreHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.parent.parent.name != "CoreHPUIUp")
        {
            Vector3 targetPos = Camera.main.transform.position;
            // ターゲットのY座標を自分と同じにすることで2次元に制限する。
            targetPos.y = this.transform.parent.parent.position.y;
            transform.parent.parent.LookAt(targetPos);
        }

        enemyHpvar.fillAmount = AllyCoreHp.AllyCoreHP / Maxhp;
    }
}
