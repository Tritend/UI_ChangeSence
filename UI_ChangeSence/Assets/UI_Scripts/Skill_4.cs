using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Skill_4 : MonoBehaviour
{

    private bool isCd = false;
    private Image fA;
    public float CDtime;
    private float time;
    public KeyCode key;


    void Start()
    {
        fA = GameObject.Find("Skill_4_mask").GetComponent<Image>();
    }
    void Update()
    {
        if (isCd == false && Input.GetKeyDown(key))
        {
            isCd = true;
            print("4");
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
