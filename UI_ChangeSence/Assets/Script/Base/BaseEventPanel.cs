using UnityEngine;
using System.Collections;
using System;

public abstract class BaseEventPanel : MonoBehaviour,IEventListener {
    /// <summary>
    /// 刷新数据
    /// </summary>
    protected virtual void OnRefresh()
    {

    }

    /// <summary>
    /// UI现实时调用
    /// </summary>
    protected virtual void OnEnable()
    {
        AddListener();
        OnRefresh();
    }

    /// <summary>
    /// UI隐藏时调用
    /// </summary>
    protected virtual void OnDisable()
    {
        RemoveListener();
        StopAllCoroutines();
    }

    public virtual void AddListener()
    {

    }

    public virtual void RemoveListener()
    {

    }

}
