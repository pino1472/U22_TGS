using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class NaviPlayerNPC : MonoBehaviour
{
    NavMeshAgent agent;
    Animator p_Animator;
    GameObject p_core;
    
    private GameObject core;// 敵タワー
    [SerializeField] private Transform[] botTower;// bot敵タワー
    [SerializeField] private Transform[] midTower;// mid敵タワー
    [SerializeField] private Transform[] topTower;// top敵タワー
    private GameObject[] nearTower;
    private GameObject[] _nearTower = new GameObject[3];
    private GameObject nearEnemy;// 近くのEnemy
    [SerializeField] private Transform target;// 目的地    

    private float agentDistance;// プレイヤーのNPC、敵間の距離
    private float coreDistance;// tower、PlayerNPC間の距離
    private float distance; //top側のタワーとの距離
    [SerializeField] float stopDistance = 5f;// 停止距離
    [SerializeField]float enemySearhDistance = 10f; //エネミーを感知する距離
    //出現時のラインの判定
    [SerializeField] bool isBotLine = false;
    private bool isTopLine = false;
    //bool isMidLine = false;

    [SerializeField]bool isEnemyAttack;// Enemyに王撃するフラグ

    private float searchTime = 0;//serchTagの探す時間

    void Start()
    {
        p_Animator = gameObject.GetComponent<Animator>(); //animatorコンポーネントを取得
        agent = gameObject.GetComponent<NavMeshAgent>();//NaviMeshAgentのコンポーネントを取得

        core = GameObject.FindWithTag("EnemyCore");// 敵タワーを取得
        p_core = GameObject.FindGameObjectWithTag("Tower");


        if (GameObject.FindGameObjectWithTag("Tower_left"))
        {
            // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
            Transform[] lane_tower = GameObject.FindGameObjectsWithTag("Tower_left").Select(e => e.transform).ToArray();
            // OrderByで距離(昇順)でソート         
            botTower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
        }
        if (GameObject.FindGameObjectWithTag("Tower_rigth"))
        {
            // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
            Transform[] lane_tower = GameObject.FindGameObjectsWithTag("Tower_rigth").Select(e => e.transform).ToArray();
            // OrderByで距離(昇順)でソート         
            topTower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
        }
        if (GameObject.FindGameObjectWithTag("Tower_center"))
        {
            // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
            Transform[] lane_tower = GameObject.FindGameObjectsWithTag("Tower_center").Select(e => e.transform).ToArray();
            // OrderByで距離(昇順)でソート         
            midTower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
        }

        //タワーがあれば
        SearchLine();

        if (core)
        {
            if (isBotLine)
            {
                if (botTower[0].name == "LeftPoint")
                {
                    //一時敵に変数を移す変数
                    Transform ecape = botTower[0];
                    if (botTower.Length == 1)
                    {
                        botTower[0] = core.transform;
                    }
                    else
                    {
                        botTower[0] = botTower[1];
                        botTower[1] = ecape;
                    }
                }
                target = botTower[0].transform;
            }
            else if (isTopLine)
            {
                if (topTower[0].name == "RighPoint")
                {
                    //一時敵に変数を移す変数
                    Transform ecape = topTower[0];
                    if (topTower.Length == 1)
                    {
                        topTower[0] = core.transform;
                    }
                    else
                    {
                        topTower[0] = topTower[1];
                        topTower[1] = ecape;
                    }
                }
                target = topTower[0].transform;
            }
            else if (!isTopLine && !isBotLine)
            {
                if (midTower[0].name == "CenterPoint")
                {
                    //一時敵に変数を移す変数
                    Transform ecape = midTower[0];
                    if (midTower.Length == 1)
                    {
                        midTower[0] = core.transform;
                    }
                    else
                    {
                        midTower[0] = midTower[1];
                        midTower[1] = ecape;
                    }
                }
                target = midTower[0].transform;
            }
            else
            {
                target = core.transform;
            }
            p_Animator.SetBool("IsRun", true);
        }
    }

    void Update()
    {
        //エネミーコアとの距離
        coreDistance = Vector3.Distance(this.agent.transform.position, core.transform.position);
        
        //最も近かった、"Enemy"タグのオブジェクトを取得
        nearEnemy = serchTag(gameObject, "Enemy");
        //nearEnemyがいたら
        if(nearEnemy)agentDistance = Vector3.Distance(this.agent.transform.position, nearEnemy.transform.position);

        //停止距離より離れていたら
        if (!(agentDistance <= stopDistance
              && coreDistance <= stopDistance))
        {
            // 走るアニメーションの再生
            p_Animator.SetBool("IsRun", true);
        }
        
        //エネミーの感知
        if (enemySearhDistance >= agentDistance && nearEnemy )
        {           
            target = nearEnemy.transform;
        }       
        else 
        {
            if (isBotLine)
            {
                ChaseTower("Tower_left", "LeftPoint", botTower);
            }
            if (isTopLine)
            {
                ChaseTower("Tower_rigth", "RighPoint", topTower);

            }
            if (!isBotLine && !isTopLine)
            {
                ChaseTower("Tower_center", "CenterPoint", midTower);
            }
            if ((topTower.Length == 1) && (botTower.Length == 1))
            {
                target = core.transform;
            }            
        }        

        //ターゲットが入っていたら
        if (target)
        {
            // エージェント
            agent.SetDestination(target.position);
            distance = Vector3.Distance(target.position, agent.transform.position);
        }
        Attack();
    }

    // タグ付きのオブジェクトを探す    
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
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
        return targetObj;
    }     
      
    /// <summary>
    /// 目的地の変更
    /// </summary>
    /// <param name="tagName"></param>
    /// <param name="pointName"></param>
    /// <param name="lane_Tower"></param>
   
    void ChaseTower(string tagName, string pointName, Transform[] lane_Tower)
    {
        if (GameObject.FindGameObjectWithTag(tagName))
        {
            // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
            Transform[] lane_tower = GameObject.FindGameObjectsWithTag(tagName).Select(e => e.transform).ToArray();
            // OrderByで距離(昇順)でソート         
            lane_Tower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
        }
        else
        {
            lane_Tower[0] = core.transform;
        }
        //serchTag(gameObject, "Tower_left");
        if (lane_Tower[0].name == pointName)
        {
            //一時敵に変数を移す変数
            Transform ecape = lane_Tower[0];
            if (lane_Tower.Length == 1)
            {
                lane_Tower[0] = core.transform;
            }
            else
            {
                lane_Tower[0] = lane_Tower[1];
                lane_Tower[1] = ecape;
            }
        }       

        if (lane_Tower[0])
        {
            target = lane_Tower[0].transform;
        }
    }


    /// <summary>
    /// 攻撃
    /// </summary>
    void Attack()
    {
        if (distance <= stopDistance)

        {
            // 走るアニメーションの停止
            p_Animator.SetBool("IsRun", false);
            // Naviを切る
            agent.GetComponent<NavMeshAgent>().isStopped = true;
            //Enemyの方向を向く
            if (target)
            {
                var aim = this.target.transform.position - this.transform.position;
                var look = Quaternion.LookRotation(aim);
                this.transform.localRotation = look;
            }
            //攻撃アニメーションの再生
            p_Animator.SetTrigger("IsAttack");
        }
        else
        {
            // Naviを動かす
            agent.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    /// <summary>
    /// 出現時のレーンの選択
    /// </summary>
    void SearchLine()
    {
       
        if (botTower.Length >= 2)
        {
            _nearTower[0] = serchTag(gameObject, "BotLine" );
        }
        else
        {
            _nearTower[0] = serchTag(gameObject, "BotLine"); 
        }
        if (topTower.Length >= 2)
        {
            _nearTower[1] = serchTag(gameObject, "TopLine" );
        }
        else
        {
            _nearTower[1] = serchTag(gameObject, "TopLine"); 
        }
        if (midTower.Length >= 2)
        {
            _nearTower[2] = serchTag(gameObject, "MidLine");
        }
        else
        {
            _nearTower[2] = serchTag(gameObject, "MidLine");

            //            _nearTower[2] = core;
        }
        nearTower = _nearTower.OrderBy(e => Vector3.Distance(e.transform.position, gameObject.transform.position)).ToArray();
        if (nearTower[0] != core)
        {
            if (nearTower[0] == _nearTower[0])
            {
                //ボットレーンにいる
                isBotLine = true;
            }
            if (nearTower[0] == _nearTower[1])
            {
                //ボットレーンにいる
                isTopLine = true;
            }
        }
    }
}
