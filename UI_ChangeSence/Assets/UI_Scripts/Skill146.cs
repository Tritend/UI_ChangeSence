using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Skill146 : MonoBehaviour {
    private bool isCd1 = false;
    private bool isCd4 = false;
    private bool isCd6 = false;
    public float CDtime;
    private Image D1;
    private Image D4;
    private Image D6;
    private float time1 = 0;
    private float time4 = 0;
    private float time6 = 0;


    private int A = 0;

    void Start () {
        Button one = transform.GetComponent<Button>("1/Button");
        Button four = transform.GetComponent<Button>("4/Button");
        Button six = transform.GetComponent<Button>("6/Button");

        EventListener.Get(one).SetEventListener(E_TouchType.OnClick, OnClick1);
        EventListener.Get(four).SetEventListener(E_TouchType.OnClick, OnClick4);
        EventListener.Get(six).SetEventListener(E_TouchType.OnClick, OnClick6);

        D1 = transform.GetComponent<Image>("1/Skill_1_mask");
        D4 = transform.GetComponent<Image>("4/Skill_4_mask");
        D6 = transform.GetComponent<Image>("6/Skill_6_mask");
    }
    private void OnClick1(GameObject _listener, object _args, object[] _params)
    {
        isCd1 = true;
    }


    private void OnClick4(GameObject _listener, object _args, object[] _params)
    {
        isCd4 = true;
    }

    private void OnClick6(GameObject _listener, object _args, object[] _params)
    {
        isCd6 = true;
    }


    void Update () {
        CD();
    }

    private void CD()
    {
        if (isCd1 == true)
        {
            time1 += Time.deltaTime;
            D1.fillAmount = (CDtime - time1) / CDtime;
            if (D1.fillAmount <= 0)
            {
                isCd1 = false;
                time1 = 0;
            }
        }
        if (isCd4 == true)
        {
            time4 += Time.deltaTime;
            D4.fillAmount = (CDtime - time4) / CDtime;
            if (D4.fillAmount <= 0)
            {
                isCd4 = false;
                time4 = 0;
            }
        }
        if (isCd6 == true)
        {
            time6 += Time.deltaTime;
            D6.fillAmount = (CDtime - time6) / CDtime;
            if (D6.fillAmount <= 0)
            {
                isCd6 = false;
                time6 = 0;
            }
        }
    }
}
