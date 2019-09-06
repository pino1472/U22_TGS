using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherHp : MonoBehaviour
{
    public int Hp;
    public float up = 0.1f;
    float uiTime;
    public bool hpUi;
    public GameObject player;
    public ParticleSystem particle_arrow;
    public ParticleSystem particle_sword;

    public AudioSource audioCrip_damage;

    void Start()
    {
        //particle_arrow.Stop();
        //particle_sword.Stop();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (hpUi)
        {
            uiTime += Time.deltaTime;
        }
        else
        {
            uiTime = 0;
        }

        if (uiTime >= 3f)
        {
            hpUi = false;
        }
        if (Hp <= 0)
        {
           
            int k = 3;//配列の要素数
            GameObject[] meshes = new GameObject[k];
            for (int i = 1; 4 > i; i++)
            {
                meshes[i-1] = transform.GetChild(i).gameObject;
                SkinnedMeshRenderer skinnedMeshRenderer = meshes[i - 1].GetComponent<SkinnedMeshRenderer>();
                skinnedMeshRenderer.material.color = new Color(0, 0, 0, 0.0f);
            }
            //particle_sword.Play();
            StartCoroutine("Death");            
        }
    }    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC_Sword")
        {
            Hp -= 20;
            audioCrip_damage.Play();
            particle_sword.Play();
        }
        if (other.gameObject.tag == "P_Sword")
        {
            Hp -= player.GetComponent<PlayerStatus>().AttackPower + 50;
            hpUi = true;
            audioCrip_damage.Play();
            particle_sword.Play();
            Debug.Log(player.GetComponent<PlayerStatus>().AttackPower + "弓");
        }

        if (other.gameObject.tag == "P_Arrow")
        {
            Hp -= 40;
            hpUi = true;
            particle_arrow.Play();
        }
    }

    private IEnumerator Death()
    {
        particle_sword.Play();
        yield return null;
        particle_sword.Stop();
        yield return new WaitForSeconds(0.3f);
        if (player.GetComponent<TurretSet>().maxMilitary > player.GetComponent<TurretSet>().militaryforce + up)
            player.GetComponent<TurretSet>().militaryforce += up;
        Destroy(this.gameObject);
    }

} 
