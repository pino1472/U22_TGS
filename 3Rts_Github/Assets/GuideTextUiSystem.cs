using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuideTextUiSystem : MonoBehaviour
{
    public GameObject guideText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Back"))
        {
            guideText.SetActive(!guideText.activeSelf);
        }
    }
}
