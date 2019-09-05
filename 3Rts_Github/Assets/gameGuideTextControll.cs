using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameGuideTextControll : MonoBehaviour
{
    [SerializeField]
    GameObject[] PracticeText;

    bool frag;
    public float timeOutShortText;
    public float timeOutLongText;
    private float timeElapsed;
    private float deltaTimeEscape;
    [SerializeField] float timeSpan;

    int iEscape;
    int i;
    bool textSetFlag;

    //public GameObject guideText;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(DpadH());
       

    }

    IEnumerator DpadH()                 //コルーチンで入力を受け付けない時間を作る。
    {
        PracticeText[i].SetActive(true);
        if (!frag)
        {
            if (Input.GetAxisRaw("D Pad H") == 1)
            {

                if (PracticeText.Length - 1 > i)
                {
                    frag = true;
                    iEscape = i;
                    i += 1;
                    PracticeText[i].SetActive(true);
                    PracticeText[iEscape].SetActive(false);

                }

                yield return new WaitForSeconds(0.4f);
                frag = false;
            }

            if (Input.GetAxisRaw("D Pad H") == -1)
            {
                if (i > 0)
                {
                    frag = true;
                    iEscape = i;
                    i -= 1;
                    PracticeText[i].SetActive(true);
                    PracticeText[iEscape].SetActive(false);
                }

                yield return new WaitForSeconds(0.4f);
                frag = false;
            }

            if (Input.GetAxisRaw("D Pad H") == -1)
            {
                if (i > 0)
                {
                    frag = true;
                    iEscape = i;
                    i -= 1;
                    PracticeText[i].SetActive(true);
                    PracticeText[iEscape].SetActive(false);
                }

                yield return new WaitForSeconds(0.4f);
                frag = false;
            }



        }

        

        /*if (Input.GetButton("Back") && Time.timeScale != 0)
        {
            this.gameObject.SetActive(false);
            textSetFlag = false;
            //Destroy(this.gameObject);

        }
        */

        /*if(Input.GetButton("joystick B")&&textSetFlag == false)
        {
            this.gameObject.SetActive(true);
            //textSetFlag = true;
        }*/
    }
}
