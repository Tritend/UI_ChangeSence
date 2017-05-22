using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Panel14 : BasePanel
{

    private Button X_btn;
    private Button red_btn;
    private Button blue_btn;
    void Start()
    {
        X_btn = transform.GetComponent<Button>("Btn/X_btn");
        red_btn = transform.GetComponent<Button>("Btn/red_btn");
        blue_btn = transform.GetComponent<Button>("Input/blue_btn");

        X_btn.onClick.AddListener(OnClickBtn);
        red_btn.onClick.AddListener(OnClickRed);
        blue_btn.onClick.AddListener(OnClickBule);
    }

    private void OnClickBule()
    {

    }

    private void OnClickRed()
    {
        UIManager.Instance.OpenPanel<Panel13>();
    }

    private void OnClickBtn()
    {
        UIManager.Instance.ClosePanel(GetType());
    }

    void Update()
    {

    }
}

//public class Singleton
//{
//    protected static Singleton _instance;
//    public static Singleton Instance
//    {
//        get
//        {
//            if (null == _instance)
//            {
//                _instance = new Singleton();
//            }
//            return _instance;
//        }
//    }
//}
