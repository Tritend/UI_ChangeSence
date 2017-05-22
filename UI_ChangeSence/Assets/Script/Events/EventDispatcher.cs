using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventDispatcher  {


    private static  EventController _eventController=new EventController();

    public static Dictionary<string, Delegate> TheRouter
    {
        get { return _eventController.TheRouter; }
    }

    /// <summary>
    /// 标记为永久注册事件
    /// </summary>
    /// <param name="eventType"></param>
    static public void MarkAsPermanent(string eventType)
    {
        _eventController.MakeAsPermanent(eventType);
    }

    /// <summary>
    /// 清除非永久性注册的事件
    /// </summary>
    static public void Cleanup()
    {
        _eventController.Cleanup();
    }

    #region 增加监听器
    /// <summary>
    ///  增加监听器， 不带参数
    /// </summary>
    static public void AddListener(string eventType, Action handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 1个参数
    /// </summary>
    static public void AddListener<T>(string eventType, Action<T> handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 2个参数
    /// </summary>
    static public void AddListener<T, U>(string eventType, Action<T, U> handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 3个参数
    /// </summary>
    static public void AddListener<T, U, V>(string eventType, Action<T, U, V> handler)
    {
        _eventController.AddListener(eventType, handler);
    }

    /// <summary>
    ///  增加监听器， 4个参数
    /// </summary>
    static public void AddListener<T, U, V, W>(string eventType, Action<T, U, V, W> handler)
    {
        _eventController.AddListener(eventType, handler);
    }
    #endregion

    #region 移除监听器
    /// <summary>
    ///  移除监听器， 不带参数
    /// </summary>
    static public void RemoveListener(string eventType, Action handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 1个参数
    /// </summary>
    static public void RemoveListener<T>(string eventType, Action<T> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 2个参数
    /// </summary>
    static public void RemoveListener<T, U>(string eventType, Action<T, U> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 3个参数
    /// </summary>
    static public void RemoveListener<T, U, V>(string eventType, Action<T, U, V> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }

    /// <summary>
    ///  移除监听器， 4个参数
    /// </summary>
    static public void RemoveListener<T, U, V, W>(string eventType, Action<T, U, V, W> handler)
    {
        _eventController.RemoveListener(eventType, handler);
    }
    #endregion

    #region 触发事件
    /// <summary>
    ///  触发事件， 不带参数触发
    /// </summary>
    static public void TriggerEvent(string eventType)
    {
        _eventController.TriggerEvent(eventType);
    }

    /// <summary>
    ///  触发事件， 带1个参数触发
    /// </summary>
    static public void TriggerEvent<T>(string eventType, T arg1)
    {
        _eventController.TriggerEvent(eventType, arg1);
    }

    /// <summary>
    ///  触发事件， 带2个参数触发
    /// </summary>
    static public void TriggerEvent<T, U>(string eventType, T arg1, U arg2)
    {
        _eventController.TriggerEvent(eventType, arg1, arg2);
    }

    /// <summary>
    ///  触发事件， 带3个参数触发
    /// </summary>
    static public void TriggerEvent<T, U, V>(string eventType, T arg1, U arg2, V arg3)
    {
        _eventController.TriggerEvent(eventType, arg1, arg2, arg3);
    }

    /// <summary>
    ///  触发事件， 带4个参数触发
    /// </summary>
    static public void TriggerEvent<T, U, V, W>(string eventType, T arg1, U arg2, V arg3, W arg4)
    {
        _eventController.TriggerEvent(eventType, arg1, arg2, arg3, arg4);
    }

    #endregion


}
