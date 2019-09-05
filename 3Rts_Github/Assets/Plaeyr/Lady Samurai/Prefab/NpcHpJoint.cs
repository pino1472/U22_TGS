using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcHpJoint : MonoBehaviour
{
    Image ladyHpVar;
    NpcStatus ladyHp;
    float ladyMaxHp;
    // Start is called before the first frame update
    void Start()
    {
        ladyHpVar = GetComponent<Image>();
        ladyHp = transform.root.GetComponent<NpcStatus>();
        ladyMaxHp = ladyHp.Hp;

    }

    // Update is called once per frame
    void Update()
    {
        ladyHpVar.fillAmount = ladyHp.Hp / ladyMaxHp;
    }
}
