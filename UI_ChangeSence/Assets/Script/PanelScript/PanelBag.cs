using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PanelBag : BasePanel
{

    // Use this for initialization
    private Text Mingzi;
    private Text Lv;
    private Text Strength;
    private Text Dex;
    private Text focus;
    private Text PointSum;


    private Button btn1;
    private Button btn2;
    private Button btn3;
    private Button X;

    //private int Point = 20;
    private int StrengthPoint = 238;
    private int DexPoint = 145;
    private int focusPoint = 53;
   // private int Level = 47;

    private Image black;


    public void Awake()
    {

        Mingzi = transform.GetComponent<Text>("left/touxiang/Image/Mingzi");
        Lv = transform.GetComponent<Text>("left/touxiang/Lv");

        PointSum = transform.GetComponent<Text>("left/PointSum");
        Strength = transform.GetComponent<Text>("left/Strength/Image/num");
        Dex = transform.GetComponent<Text>("left/Dex/Image/num");
        focus = transform.GetComponent<Text>("left/focus/Image/num");

        btn1 = transform.GetComponent<Button>("left/Strength/Button");
        btn2 = transform.GetComponent<Button>("left/Dex/Button");
        btn3 = transform.GetComponent<Button>("left/focus/Button");
        X = transform.GetComponent<Button>("Btn/X_btn");

        black = transform.GetComponent<Image>("left/black");


        btn1.onClick.AddListener(_Strength);
        btn2.onClick.AddListener(_Dex);
        btn3.onClick.AddListener(_focus);


        EventListener.Get(X).SetEventListener(E_TouchType.OnClick, CloseThis);
        //EventListener.Get(btn1).SetEventListener(E_TouchType.OnClick, _Strength);
        //EventListener.Get(btn2).SetEventListener(E_TouchType.OnClick, _Dex);
        //EventListener.Get(btn3).SetEventListener(E_TouchType.OnClick, _focus);

        Mingzi.text = PlayerPrefs.GetString("Name");
    }
    void Start()
    {
       // Lv.text = Level.ToString();



        //Point = MuduleManager.Get<Role>().Point;
        //Lv.text = MuduleManager.Get<Role>().Level.ToString();


    }

    private void _focus()
    {
        if (MuduleManager.Get<Role>().Point > 0)
        {
            MuduleManager.Get<Role>().Point--;
            focusPoint++;
            focus.text = focusPoint.ToString();
        }

    }

    private void _Dex()
    {
        if (MuduleManager.Get<Role>().Point > 0)
        {
            MuduleManager.Get<Role>().Point--;
            DexPoint++;
            Dex.text = DexPoint.ToString();
        }

    }

    private void _Strength()
    {
        if (MuduleManager.Get<Role>().Point > 0)
        {
            MuduleManager.Get<Role>().Point--;
            StrengthPoint++;
            Strength.text = StrengthPoint.ToString();
        }

    }

    //private void _focus(GameObject _listener, object _args, object[] _params)
    //{
    //    Point--;
    //    StrengthPoint++;
    //    Strength.text = StrengthPoint.ToString();
    //}

    //private void _Dex(GameObject _listener, object _args, object[] _params)
    //{
    //    Point--;
    //    DexPoint++;
    //    Dex.text = DexPoint.ToString();
    //}

    //private void _Strength(GameObject _listener, object _args, object[] _params)
    //{
    //    Point--;
    //    focusPoint++;
    //    focus.text = focusPoint.ToString();
    //}

    private void CloseThis(GameObject _listener, object _args, object[] _params)
    {
        UIManager.Instance.ClosePanel(GetType());
    }

    // Update is called once per frame
    void Update()
    {
       // if (Point > 0)
       // {
       //     black.gameObject.SetActive(false);
       // }

       // if (Point <= 0)
       // {
       //     Point = 0;
       //     black.gameObject.SetActive(true);
       // }
       //// Lv.text = Level.ToString();
       // PointSum.text = "剩余：" + Point;
    }

    #region 刷新等级

    public override void AddListener()
    {
        EventDispatcher.AddListener("point", Refreshpoint);
        EventDispatcher.AddListener("level", RefreshpointLevel);
    }

    private void RefreshpointLevel()
    {
        Lv.text = MuduleManager.Get<Role>().Level.ToString();
    }

    public override void RemoveListener()
    {
        EventDispatcher.RemoveListener("point", Refreshpoint);
        EventDispatcher.RemoveListener("level", RefreshpointLevel);
    }

    /// <summary>
    /// 调用数据库Role 实时更新。
    /// </summary>
    private void Refreshpoint()
    {
        PointSum.text = MuduleManager.Get<Role>().Point.ToString();
         if (MuduleManager.Get<Role>().Point > 0)
        {
            black.gameObject.SetActive(false);
        }

        if (MuduleManager.Get<Role>().Point <= 0)
        {
            //Point = 0;
            black.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected override void OnRefresh()
    {
        Lv.text = MuduleManager.Get<Role>().Level.ToString();
        PointSum.text = MuduleManager.Get<Role>().Point.ToString();
        if (MuduleManager.Get<Role>().Point > 0)
        {
            black.gameObject.SetActive(false);
        }

        if (MuduleManager.Get<Role>().Point <= 0)
        {
            //Point = 0;
            black.gameObject.SetActive(true);
        }
    }
    #endregion


}
