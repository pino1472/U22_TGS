using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyHp : MonoBehaviour
{
    public int Hp;
    public float up = 0.1f;
    float uiTime;
    public bool hpUi;
    public　GameObject player;
    public ParticleSystem particle_arrow;
    public ParticleSystem particle_sword;

    public AudioSource audioCrip_damage;

    // Start is called before the first frame update
    void Start()
    {
        hpUi = false;
        player = GameObject.FindWithTag("Player");
        particle_arrow.Stop();
        particle_sword.Stop();
    }

    // Update is called once per frame
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
            if(player.GetComponent<TurretSet>().maxMilitary > player.GetComponent<TurretSet>().militaryforce + up)
            player.GetComponent<TurretSet>().militaryforce += up;

            // 消える時にパーティクルを残す
            GameObject meshes = transform.Find("107311_mws_npc/107300_mws_npc_mo/107300_mws_npc_mo_0").gameObject;
            SkinnedMeshRenderer skinnedMeshRenderer = meshes.GetComponent<SkinnedMeshRenderer>();
            skinnedMeshRenderer.material.color = new Color(0, 0, 0, 0.0f);
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
        }
        
        if (other.gameObject.tag == "P_Arrow")
        {
            Hp -= 25;
            hpUi = true;
            particle_arrow.Play();
        }              
    }

    private IEnumerator Death()
    {
        particle_sword.Play();
        yield return new WaitForSeconds(0.05f);
        particle_sword.Stop();
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
