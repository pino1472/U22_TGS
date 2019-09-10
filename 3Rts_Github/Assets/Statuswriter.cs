using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Statuswriter : MonoBehaviour
{
    float armyValue;
    int powerValue;
    float hpValue;
    public TextMeshProUGUI armyPointText;
    public TextMeshProUGUI powerPointText;
    public TextMeshProUGUI hpPointText;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        powerValue = Player.GetComponent<PlayerStatus>().AttackPowerMax + 5;
        hpValue = Player.GetComponent<PlayerStatus>().PHpMax;
        armyValue = Player.GetComponent<TurretSet>().maxMilitary;
    }

    // Update is called once per frame
    void Update()
    {
        powerValue = Player.GetComponent<PlayerStatus>().AttackPowerMax + 5;
        hpValue = Player.GetComponent<PlayerStatus>().PHpMax;
        armyValue = Player.GetComponent<TurretSet>().maxMilitary;

        armyPointText.text  = armyValue.ToString();
        powerPointText.text = powerValue.ToString();
        hpPointText.text    = hpValue.ToString();
    }
}
