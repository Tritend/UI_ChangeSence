using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Panel13 : BasePanel
{

    // Use this for initialization
    private Button Resume;
    private Button Exit;
    private Button Setting;
    void Start () {
        Resume = transform.GetComponent<Button>("Btn/Resume/Image");
        Exit = transform.GetComponent<Button>("Btn/Exit/Image");
        Setting = transform.GetComponent<Button>("Btn/Setting/Image");

        Resume.onClick.AddListener(OnClickResume);
        Exit.onClick.AddListener(OnClickExit);
        Setting.onClick.AddListener(OnClickSetting);
    }

    private void OnClickResume()
    {
        UIManager.Instance.ClosePanel(GetType());
    }

    private void OnClickSetting()
    {
        UIManager.Instance.OpenPanel<Panel12>();
    }

    private void OnClickExit()
    {
        //UIManager.Instance.ClosePanel<Panel14>();
        //UIManager.Instance.ClosePanel<Panel13>();
        //UIManager.Instance.ClosePanel<Panel12>();
        //UIManager.Instance.ClosePanel<Panel6>();
       UIManager.Instance.CloseOtherPanel();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
