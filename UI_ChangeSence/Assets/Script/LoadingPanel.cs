
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : BasePanel
{


    private Slider Loading;
    private Text Desc;

    private bool IsFinished = false;
    private float TargetProcess = 0f;
    private float CurrentProcess = 0f;


    private void Awake()
    {
        Loading = transform.GetComponent<Slider>("ProgressSlider");
        Desc = transform.GetComponent<Text>("ProgressText");        
    }

    public override void AddListener()
    {
        EventDispatcher.AddListener<int>(Events.LoadingEvent.OnLoadingProcess,OnLoading);
        EventDispatcher.AddListener<bool>(Events.LoadingEvent.OnLoadingFinished, OnFinished);

    }

    public override void RemoveListener()
    {
        EventDispatcher.RemoveListener<int>(Events.LoadingEvent.OnLoadingProcess, OnLoading);
        EventDispatcher.RemoveListener<bool>(Events.LoadingEvent.OnLoadingFinished, OnFinished);
    }



    /// <summary>
    /// 正在加载场景进度
    /// </summary>
    /// <param name="process"></param>
    private void OnLoading(int process)
    {
        TargetProcess = process;
    }


    /// <summary>
    /// 数据加载完成后回调
    /// </summary>
    /// <param name="isFinished"></param>
    private void OnFinished(bool isFinished)
    {
        IsFinished = isFinished;

    }

    /// <summary>
    /// 加载完后打开新场景
    /// </summary>
    private void OnFinished()
    {
        if (IsFinished)
        {
            IsFinished = false;
           
            // 获取加载场景的逻辑 也让逻辑场景结束

            Debug.Log("加载完后打开新场景");

            LoadingScene ls = ScenesManager.Instance.GetCurrentScene<LoadingScene>();
            
            ls.OnFinished();
        }
    }


    private void Update()
    {

        CurrentProcess = Mathf.Lerp(CurrentProcess, TargetProcess, Time.deltaTime);

        //解决动画的蠕动
        if (TargetProcess -CurrentProcess<0.5f)
        {
            CurrentProcess = TargetProcess;
        }


        RefreshLoading();


        if (CurrentProcess==100 && IsFinished)
        {
            OnFinished();
        }


    }
    /// <summary>
    /// 刷新UI界面
    /// </summary>
    private void RefreshLoading()
    {
        Desc.text = "正在为你加载：" + (int)CurrentProcess + "% ...";
        Loading.value = CurrentProcess / 100f;
    }



}
