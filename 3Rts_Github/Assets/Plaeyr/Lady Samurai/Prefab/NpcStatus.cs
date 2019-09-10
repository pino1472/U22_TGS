using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStatus : MonoBehaviour
{
    public int Hp;
    //レディHPの表示
    public bool ladyHpUI;
    float ladyUITime;

    public ParticleSystem damage_Particle;
    // Start is called before the first frame update
    void Start()
    {
        ladyHpUI = false;

        damage_Particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (ladyHpUI)
        {
            ladyUITime += Time.deltaTime;
        }
        else
        {
            ladyUITime = 0;
        }

        if (ladyUITime >= 1f)
        {
            ladyHpUI = false;
        }
        if (Hp <= 0)
        {
            // 消える時にパーティクルを残す
            GameObject meshes = transform.Find("106110_jmws_npc/106100_jmws_npc_mo/106100_jmws_npc_mo_0").gameObject;
            SkinnedMeshRenderer skinnedMeshRenderer = meshes.GetComponent<SkinnedMeshRenderer>();
            skinnedMeshRenderer.material.color = new Color(0, 0, 0, 0.0f);
            StartCoroutine("Death");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {        
        if(other.gameObject.tag  == "Enemy_Sword")
        {
            ladyUITime = 0;
            ladyHpUI = true;
            Hp -= 100;
            damage_Particle.Play();
        }      
        if (other.gameObject.tag == "Enemy_Arrow")
        {
            ladyUITime = 0;
            ladyHpUI = true;
            Hp -= 500;
            damage_Particle.Play();
        }
        if (other.gameObject.tag  == "PtBullet")
        {
            ladyUITime = 0;
            ladyHpUI = true;
            Hp -= 10;
            damage_Particle.Play();
        }
        if (other.gameObject.tag == "EnemyCoreTowerBullet")
        {
            ladyUITime = 0;
            ladyHpUI = true;
            Hp -= 25;
            damage_Particle.Play();
        }

    }
    private IEnumerator Death()
    {
        damage_Particle.Play();
        yield return null;
        damage_Particle.Stop();
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
