using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public float PHp;
    public int AttackPower;

    public float PHpMax;
    public int AttackPowerMax;

    public ParticleSystem DamegeArrow;
    public ParticleSystem DamegeSword;
    public ParticleSystem DamegeTower;


    // Start is called before the first frame update
    void Start()
    {
        DamegeArrow.Stop();//最初は停止
        DamegeSword.Stop();
        DamegeTower.Stop();
        PHpMax = PHp;
        AttackPowerMax = AttackPower;
    }

    private void Update()
    {
        if (PHp <= 0)
        {
            PHp = 0;
            PHp -= 20;
            GetComponent<Animator>().Play("Die");
        }
    }
    // Update is called once per frame
    //public void OnCollisionEnter(Collision collision)
    //{ 
    //    if (collision.gameObject.tag == "EnemyArrow")
    //    {
    //        PHp -= 50;
    //        //ダメージ後にパーティクル発生
    //        DamegeArrow.Play();
    //    }


    //}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy_Sword")
        {
            PHp -= 20;
            //ダメージ後にパーティクル発生
            DamegeSword.Play();
        }

        if (other.gameObject.tag == "Enemy_Arrow")
        {
            PHp -= 50;
            DamegeArrow.Play();
        }

        if (other.gameObject.tag == "PtBullet")
        {
            PHp -= 1000;
            //ダメージ後にパーティクル発生
            DamegeTower.Play();
        }
        if (other.gameObject.tag == "EnemyCoreTowerBullet")
        {
            PHp -= 1000;
            //ダメージ後にパーティクル発生
            DamegeTower.Play();
        }
    }

    void Die()
    {
        FadeManager.Instance.LoadScene("Over", 0.5f);

        if (SceneManager.GetActiveScene().name == ("Practice"))
        {
            FadeManager.Instance.LoadScene("OvertoPractice", 0.5f);
        }
    }
}