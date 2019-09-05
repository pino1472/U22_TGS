using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class SwordCollider : MonoBehaviour
{
    [SerializeField] GameObject Sword;

    // Start is called before the first frame update
    void Start()
    {
        Sword.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!gameObject.transform.root.GetComponent<Animator>().
        //    GetCurrentAnimatorStateInfo(0).IsName("Charge") &&
        //    (gameObject.transform.root.GetComponent<Animator>().
        //    GetCurrentAnimatorStateInfo(0).IsTag("Attack")))
        //{
        //    GetComponent<BoxCollider>().enabled = true;
        //}
        //else
        //{
        //    GetComponent<BoxCollider>().enabled = false;
        //}
    }

    void SwordColiderTrue()
    {
        Sword.GetComponent<BoxCollider>().enabled = true;
    }
    void SwordColiderFalse()
    {
        Sword.GetComponent<BoxCollider>().enabled = false;
    }
}
