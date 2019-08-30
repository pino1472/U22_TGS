using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeStartFrag : MonoBehaviour
{
    [SerializeField] GameObject Gen1;
    [SerializeField] GameObject Gen2;
    [SerializeField] GameObject Gen3;
    public bool startFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("D Pad V") == -1)
        {
            startFlag = true;
            Gen1.SetActive(true);
            Gen2.SetActive(true);
            Gen3.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
