using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonAt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjB;
    public Transform muzzle;//※3
    GameObject target;
    // public float speed;//※3
    public GameObject nearObj;         //最も近いオブジェクト
    public float searchTime = 0;    //経過時間
    float cooltime = 0;

    //public GameObject CanonB;

    public float speed;//弾の移動スピード

    public bool attackCheck;
    public bool PlayerCheck, NpcCheck;

    // Start is called before the first frame update
    void Start()
    {

        //nearObj = serchTag(gameObject, "Player");

        //CanonNPCAtSC = CanonB.GetComponent<CanonatNpc>();

    }


    void Update()
    {
        cooltime += Time.deltaTime;

        //if (searchTime >= 1.0f)
        //{
        //    //最も近かったオブジェクトを取得
        //    nearObj = serchTag(gameObject, "Player");
        //    //経過時間を初期化
        //    searchTime = 0;
        //}
        // float step = Time.deltaTime * speed;
        //transform.position = Vector3.MoveTowards(transform.position, nearObj.transform.position, step);
        //対象の位置の方向を向く
        //transform.LookAt(nearObj.transform);
        if (nearObj)
        {
            Vector3 targetPos = nearObj.transform.position;

            // ターゲットのY座標を自分と同じにすることで2次元に制限する。
            targetPos.y = this.transform.position.y;
            this.transform.LookAt(targetPos);
        }
        //自分自身の位置から相対的に移動する
        //transform.Translate(Vector3.forward * 0.01f);

    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }
        }


        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;

    }
    //攻撃範囲に対象がいるか
    public void OnTriggerStay(Collider collider)
    {
        if (!attackCheck)
        {
            if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Player_NPC")
            {
                attackCheck = true;
            }
        }
        else
        {
            if (nearObj)
            {
                if (cooltime >= 2)
                {
                    StartCoroutine("Turret");
                    cooltime = 0;
                }
            }
            else
            {
                if (NpcCheck)
                {
                    searchTime += Time.deltaTime;
                    if (collider.gameObject.tag == "Player_NPC")
                    {
                        //最も近かったオブジェクトを取得
                        nearObj = serchTag(gameObject, "Player_NPC");
                        searchTime = 0;
                    }
                    if (searchTime > 3)
                    {
                        NpcCheck = false;
                        searchTime = 0;
                    }

                }
                else if (collider.gameObject.tag == "Player_NPC")
                {
                    nearObj = serchTag(gameObject, "Player_NPC");
                    NpcCheck = true;
                }
                else if (collider.gameObject.tag == "Player")
                {
                    nearObj = serchTag(gameObject, "Player");
                    PlayerCheck = true;
                }
            }
            //transform.LookAt(nearObj.transform);



        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!NpcCheck)
            if (collider.gameObject.tag == "Player")
            {
                PlayerCheck = true;
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, "Player");
            }
        if (!PlayerCheck)
            if (collider.gameObject.tag == "Player_NPC")
            {
                NpcCheck = true;
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, "Player_NPC");
            }
    }

    void OnTriggerExit(Collider collider)
    {
        if (PlayerCheck)
            if (collider.gameObject.tag == "Player")
            {
                attackCheck = false;
                PlayerCheck = false;
                nearObj = null;
            }
        if (collider.gameObject.tag == "Player_NPC")
        {
            attackCheck = false;
            NpcCheck = false;
        }
    }



    public IEnumerator Turret()//※3
    {
        //BurretModeTriggerP = 1;
        yield return new WaitForSeconds(0.5f);//※3 //Vector3 force;//※3

        GameObject ObjBs = GameObject.Instantiate(ObjB) as GameObject;//※3
        ObjBs.transform.position = muzzle.position;//※3
                                                   //force = this.gameObject.transform.forward * speed;//※3
                                                   //Destroy(bullets.gameObject, 2);//※3
        ObjBs.GetComponent<CanonBullet>().nearObj = nearObj;

    }
}

