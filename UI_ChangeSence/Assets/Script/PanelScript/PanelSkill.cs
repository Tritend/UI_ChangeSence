using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PanelSkill : BasePanel {

    // Use this for initialization
    private Button Back;
    private Button Set;
    void Start () {

        Set = transform.GetComponent<Button>("Mid/Set/Button");
        Back = transform.GetComponent<Button>("Mid/Message/Button");

        //EventListener.Get(Back).SetEventListener(E_TouchType.OnClick, OpenBack);
        //EventListener.Get(Set).SetEventListener(E_TouchType.OnClick, OpenSet);
        Back.onClick.AddListener(Close);
        Set.onClick.AddListener(OpenSet);
    }

    private void Close()
    {
        UIManager.Instance.ClosePanel(GetType());
    }

    private void OpenSet()
    {
        UIManager.Instance.OpenPanel<Panel12>();
    }

    private void OpenSet(GameObject _listener, object _args, object[] _params)
    {
        UIManager.Instance.OpenPanel<Panel12>();
    }

    private void OpenBack(GameObject _listener, object _args, object[] _params)
    {
        UIManager.Instance.ClosePanel(GetType());
    }

    // Update is called once per frame
    void Update () {
	
	}
}
