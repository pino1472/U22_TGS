using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStatus : MonoBehaviour
{
    public int Hp;

    public ParticleSystem damage_Particle;
    // Start is called before the first frame update
    void Start()
    {
        damage_Particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Hp -= 30;
            damage_Particle.Play();
        }      
        if (other.gameObject.tag == "Enemy_Arrow")
        {
            Hp -= 20;
            damage_Particle.Play();
        }
        if (other.gameObject.tag  == "PtBullet")
        {
            Hp -= 50;
            damage_Particle.Play();
        }
        if (other.gameObject.tag == "EnemyCoreTowerBullet")
        {
            Hp -= 600;
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
