using System;
using UnityEngine;
using System.Collections;

public class BasePanel : BaseEventPanel
{
    //是否立即被摧毁
    [NonSerialized]
    public bool IsDestory = false;

    //忽视批量关闭操作，CloseOtherPanel时不会被关闭
    public bool IgnoreBatchClose = false;

    //界面是否显示
    public bool IsShow
    {
        get { return gameObject.activeSelf; }
    }

    #region 延迟销毁

    protected float DestoryDelay = 10f;
    private float DestoryTimer;

    //UIManager调用,定时计时
    public float ReduceDestoryTimer(float deltaTime)
    {
        DestoryTimer -= deltaTime;
        if (IgnoreBatchClose || IsShow)
        {
            return 1f;
        }
        return DestoryTimer;
    }

    #endregion


    #region 打开界面设置参数和异步加载界面对象

    /// <summary>
    /// 如果有参数，需要重新该方法处理接收的参数
    /// </summary>
    /// <param name="args"></param>
    public virtual void SetParams(params object[] args)
    {

    }



    public virtual IEnumerator OnAsyncLoad()
    {
        yield return new WaitForEndOfFrame();
    }


    //如果界面有携程的加载，就需要重新该方法
    //最好还是等到下一帧再做
    //例子
    //public override IEnumerator OnAsyncLoad()
    //{
    //    yield return base.OnAsyncLoad();
    //    yield return new WaitForSeconds(1f);
    //    yield return new WaitForSeconds(1f);
    //    yield return new WaitForSeconds(1f);
    //    yield return new WaitForSeconds(1f);
    //    yield return new WaitForSeconds(1f);
    //}

    /// <summary>
    /// UIManager调用，其他地方不要调用该方法
    /// </summary>
    /// <param name="args"></param>
    public void SetUIWhenOpening(params object[] args)
    {
        SetParams(args);
        StartCoroutine(OnAsyncLoad());
    }




    #endregion

    protected override void OnEnable()
    {
        base.OnEnable();
        // 向管理器进行注册

        UIManager.Instance.ShowPanel(GetType(), this);
    }


    protected override void OnDisable()
    {
        base.OnDisable();

        //  向管理注销
        UIManager.Instance.HidePanel(GetType());
    }
    //设置界面到最顶层
    private void SetTop()
    {
        transform.SetAsLastSibling();
    }


    public void SetVisable(bool isShow)
    {
        OnPlaySound(isShow);

        DestoryTimer = DestoryDelay;

        if (isShow)
        {
            gameObject.SetActive(isShow);
            SetTop();
        }

        OnStartAnimation(isShow);
    }
    /// <summary>
    /// 打开关闭UI界面播放动画
    /// 重新该方法，需要把基类干掉
    /// </summary>
    /// <param name="isShow"></param>
    protected virtual void OnStartAnimation(bool isShow)
    {
        OnEndAnimation(isShow);
    }

    /// <summary>
    /// 打开关闭UI界面播放声音
    /// </summary>
    /// <param name="isShow"></param>
    protected virtual void OnPlaySound(bool isShow)
    {

    }


    /// <summary>
    /// 打开和关闭界面动画结束的回调
    /// </summary>
    /// <param name="isShow"></param>
    protected virtual void OnEndAnimation(bool isShow)
    {
        if (isShow == false)
        {
            DestoryTimer = DestoryDelay;
            gameObject.SetActive(isShow);

            if (IsDestory)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }



}
