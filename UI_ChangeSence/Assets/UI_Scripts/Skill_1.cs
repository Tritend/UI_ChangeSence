using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Skill_1 : MonoBehaviour
{

    private bool isCd = false;
    private Image fA;
    public float CDtime;
    private float time;
    public KeyCode key;


    void Start()
    {
        fA = GameObject.Find("Skill_1_mask").GetComponent<Image>();
    }
    void Update()
    {
        if (isCd==false && Input.GetKeyDown(key))
        {
            isCd = true;
            print("1");
        }
        CD();
    }

    private void CD()
    {
        if (isCd==true)
        {
            time += Time.deltaTime;
            fA.fillAmount = (CDtime - time) / CDtime;
            if (fA.fillAmount<=0)
            {
                isCd = false;
                time = 0;
            }
        }
    }
}
