using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Skill_6 : MonoBehaviour
{

    private bool isCd = false;
    private Image fA;
    public float CDtime;
    private float time;


    void Start()
    {
        fA = GameObject.Find("Skill_6_mask").GetComponent<Image>();
    }
    void Update()
    {
        if (isCd == false && Input.GetKeyDown(KeyCode.Alpha6))
        {
            isCd = true;
            print("6");
        }
        CD();
    }

    private void CD()
    {
        if (isCd == true)
        {
            time += Time.deltaTime;
            fA.fillAmount = (CDtime - time) / CDtime;
            if (fA.fillAmount <= 0)
            {
                isCd = false;
                time = 0;
            }
        }
    }
}
