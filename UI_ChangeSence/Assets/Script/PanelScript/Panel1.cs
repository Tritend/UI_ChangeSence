using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Panel1 : BasePanel {


    //private Button btn;
    // Use this for initialization
    private Text name;
    private Text LV;
    private int Level=1;
    void Awake()
    {
        name = transform.GetComponent<Text>("name");
        LV = transform.GetComponent<Text>("LV");
    }
    void Start()
    {
        //btn = transform.GetComponent<Button>("Button");
        //btn.onClick.AddListener(OnClickBtn);
    }

    private void OnClickBtn()
    {
        UIManager.Instance.OpenPanel<Panel2>();
    }


    // Update is called once per frame
    void Update()
    {

    }
    public override void AddListener()
    {
        EventDispatcher.AddListener("level", RefreshLevel);
        EventDispatcher.AddListener("name", RefreshName);
    }


    public override void RemoveListener()
    {
        EventDispatcher.RemoveListener("level", RefreshLevel);
        EventDispatcher.RemoveListener("name", RefreshName);
    }
    private void RefreshLevel()
    {
        LV.text = MuduleManager.Get<RoleModule>().Level.ToString();
    }
    private void RefreshName()
    {
        name.text = MuduleManager.Get<RoleModule>().Name;
    }
    protected override void OnRefresh()
    {
        name.text = MuduleManager.Get<RoleModule>().Name;
        LV.text = MuduleManager.Get<RoleModule>().Level.ToString();
    }
}
