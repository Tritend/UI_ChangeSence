using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Paneltou : BasePanel
{

    private Button Button;
    private Button player;
    private Button K;
    private Text name;

    private Text level;

    void Awake()
    {
        level = transform.GetComponent<Text>("level");
        Button = transform.GetComponent<Button>("Button"); 
        name = transform.GetComponent<Text>("name");
        player = transform.GetComponent<Button>("Player_btn");
        K = transform.GetComponent<Button>("K");

    }
    void Start () {
        EventListener.Get(Button).SetEventListener(E_TouchType.OnClick, OpenLevel);
        EventListener.Get(player).SetEventListener(E_TouchType.OnClick, OpenBag);
        EventListener.Get(K).SetEventListener(E_TouchType.OnClick, OpenSkill);


        level.text = "47";
        //name.text = PlayerPrefs.GetString("Name");
    }

    #region 刷新等级


    public override void AddListener()
    {
        EventDispatcher.AddListener("level", RefreshLevel);
        EventDispatcher.AddListener("name", Refreshname);

    }


    public override void RemoveListener()
    {
        EventDispatcher.RemoveListener("level", RefreshLevel);
        EventDispatcher.RemoveListener("name", Refreshname);
    }
    private void Refreshname()
    {
        name.text = MuduleManager.Get<Role>().Name;
    }
    private void RefreshLevel()
    {
        level.text = MuduleManager.Get<Role>().Level.ToString();
    }
    protected override void OnRefresh()
    {
        name.text = MuduleManager.Get<Role>().Name;
    }

    #endregion











    private void OpenLevel(GameObject _listener, object _args, object[] _params)
    {
        UIManager.Instance.OpenPanel<PanelLevel>();
    }

    private void OpenSkill(GameObject _listener, object _args, object[] _params)
    {
        UIManager.Instance.OpenPanel<PanelSkill>();
    }

    private void OpenBag(GameObject _listener, object _args, object[] _params)
    {
        UIManager.Instance.OpenPanel<PanelBag>();
    }


    // Update is called once per frame
    void Update () {
	
	}
}
