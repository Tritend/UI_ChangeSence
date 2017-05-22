using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PanelLevel : BasePanel
{

    // Use this for initialization
    private Button level;
    private Button back;
    void Start()
    {

        back = transform.GetComponent<Button>("back/back");
        level = transform.GetComponent<Button>("enter/enter");



        EventListener.Get(level).SetEventListener(E_TouchType.OnClick, OnLevel);
        EventListener.Get(back).SetEventListener(E_TouchType.OnClick, Close);
    }



    private void Close(GameObject _listener, object _args, object[] _params)
    {
        print("Close");
        UIManager.Instance.ClosePanel(GetType());
    }

    private void OnLevel(GameObject _listener, object _args, object[] _params)
    {
        MuduleManager.Get<Role>().Level++;
        MuduleManager.Get<Role>().Point += 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
