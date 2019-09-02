using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCoreCtrl : MonoBehaviour
{
    public int EnemyCoreHp;

    public AudioSource coreSound;
    public AudioClip coreSoundAtack;
    public ParticleSystem damegge_particle;
    // Start is called before the first frame update
    void Start()
    {
        coreSound = gameObject.GetComponent<AudioSource>();
        //damegge_particle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyCoreHp <= 0)
        {
            Destroy(this.gameObject);
            FadeManager.Instance.LoadScene("Clear",0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "P_Sword")
        {
            EnemyCoreHp -= 50;
            coreSound.PlayOneShot(coreSoundAtack);
            damegge_particle.Play();
        }

        if (other.gameObject.tag == "NPC_Sword")
        {
            EnemyCoreHp -= 20;
            coreSound.PlayOneShot(coreSoundAtack);
            damegge_particle.Play();
        }
    }

}
