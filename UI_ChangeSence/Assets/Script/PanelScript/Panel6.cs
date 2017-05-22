using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Panel6 : BasePanel {

    private Button X_btn;
    private Button blue_btn;
    private Button red_btn;
    // Use this for initialization

    void Start () {
        IgnoreBatchClose = true;
        X_btn = transform.GetComponent<Button>("Btn/X_btn");
        blue_btn = transform.GetComponent<Button>("Btn/blue_btn");
        red_btn = transform.GetComponent<Button>("Btn/red_btn");

        X_btn.onClick.AddListener(OnClickBtn);
        blue_btn.onClick.AddListener(OnClickBlue);
        red_btn.onClick.AddListener(OnClickRed);

    }

    private void OnClickRed()
    {
        UIManager.Instance.OpenPanel<Panel13>();
    }

    private void OnClickBlue()
    {
        UIManager.Instance.OpenPanel<Panel14>();
    }

    private void OnClickBtn()
    {
        //UIManager.Instance.ClosePanel(GetType());
        UIManager.Instance.ClosePanel(GetType());
    }

    // Update is called once per frame
    void Update () {
	
	}
}
