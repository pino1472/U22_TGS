using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyCoreCtrl : MonoBehaviour
{
    
    public int AllyCoreHP;
    public ParticleSystem damage_particle;
    // Start is called before the first frame update
    void Start()
    {
        //damage_particle = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(AllyCoreHP == 0)
        {
            FadeManager.Instance.LoadScene("Over",0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            AllyCoreHP -= 10;
            damage_particle.Play();
        }
    }
}
