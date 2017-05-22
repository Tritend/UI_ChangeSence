using System;
using System.Collections.Generic;

public class EventController
{

    private Dictionary<string, Delegate> m_theRouter = new Dictionary<string, Delegate>();


    public Dictionary<string, Delegate> TheRouter
    {
        get { return m_theRouter; }
    }

    /// <summary>
    /// 永久注册事件列表
    /// </summary>
    private List<string> m_permanentEvents = new List<string>();


    public void MakeAsPermanent(string eventType)
    {
        m_permanentEvents.Add(eventType);
    }

    /// <summary>
    /// 判断是否已经包含事件
    /// </summary>
    /// <param name="eventType"></param>
    /// <returns></returns>
    public bool ContainsEvent(string eventType)
    {
        return m_theRouter.ContainsKey(eventType);
    }

    /// <summary>
    /// 清除非永久事件
    /// </summary>
    public void Cleanup()
    {

        List<string> eventToRemove = new List<string>();

        foreach (KeyValuePair<string, Delegate> pair in m_theRouter)
        {

            bool wasFound = false;

            foreach (var Event in m_permanentEvents)
            {
                if (pair.Key == Event)
                {
                    wasFound = true;
                    break;
                }
            }

            if (!wasFound)
            {
                eventToRemove.Add(pair.Key);
            }
        }


        foreach (var Event in eventToRemove)
        {
            m_theRouter.Remove(Event);
        }
    }


    /// <summary>
    /// 处理增加监听前的事项检测
    /// </summary>
    private void OnListenerAdding(string eventType, Delegate listenerBegingAdded)
    {
        if (!m_theRouter.ContainsKey(eventType))
        {
            m_theRouter.Add(eventType, null);
        }

        Delegate d = m_theRouter[eventType];
        if (d != null && d.GetType() != listenerBegingAdded.GetType())
        {
            throw new Exception(string.Format(
                    "Try to add not correct event {0}. Current type is {1}, adding type is {2}.",
                    eventType, d.GetType().Name, listenerBegingAdded.GetType().Name));
        }
    }


    /// <summary>
    /// 处理移除监听前的事项检测
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="listenerBegingAdded"></param>
    /// <returns></returns>
    private bool OnListemerRemoving(string eventType, Delegate listenerBegingAdded)
    {
        if (!m_theRouter.ContainsKey(eventType))
        {
            return false;
        }

        Delegate d = m_theRouter[eventType];
        if (d != null && d.GetType() != listenerBegingAdded.GetType())
        {
            throw new Exception(string.Format(
                   "Try to add not correct event {0}. Current type is {1}, adding type is {2}.",
                   eventType, d.GetType().Name, listenerBegingAdded.GetType().Name));
        }
        else
        {

            return true;
        }
    }


    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="eventType"></param>
    private void OnListenerRemoved(string eventType)
    {
        if (m_theRouter.ContainsKey(eventType) && m_theRouter[eventType] == null)
        {
            m_theRouter.Remove(eventType);
        }
    }


    #region 增加监听功能
    /// <summary>
    /// 增加监听，不带参数
    /// </summary>
    /// <param name="evnetTpye"></param>
    /// <param name="handler"></param>
    public void AddListener(string evnetTpye, Action handler)
    {
        OnListenerAdding(evnetTpye, handler);
        m_theRouter[evnetTpye] = (Action)m_theRouter[evnetTpye] + handler;
    }

    /// <summary>
    /// 增加监听，带1个参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="evnetTpye"></param>
    /// <param name="handler"></param>
    public void AddListener<T>(string evnetTpye, Action<T> handler)
    {
        OnListenerAdding(evnetTpye, handler);
        m_theRouter[evnetTpye] = (Action<T>)m_theRouter[evnetTpye] + handler;
    }


    /// <summary>
    /// 增加监听，带2个参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="evnetTpye"></param>
    /// <param name="handler"></param>
    public void AddListener<T, U>(string evnetTpye, Action<T, U> handler)
    {
        OnListenerAdding(evnetTpye, handler);
        m_theRouter[evnetTpye] = (Action<T, U>)m_theRouter[evnetTpye] + handler;
    }


    /// <summary>
    /// 增加监听，带3个参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="evnetTpye"></param>
    /// <param name="handler"></param>
    public void AddListener<T, U, V>(string evnetTpye, Action<T, U, V> handler)
    {
        OnListenerAdding(evnetTpye, handler);
        m_theRouter[evnetTpye] = (Action<T, U, V>)m_theRouter[evnetTpye] + handler;
    }


    /// <summary>
    /// 增加监听，带4个参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="evnetTpye"></param>
    /// <param name="handler"></param>
    public void AddListener<T, U, V, W>(string evnetTpye, Action<T, U, V, W> handler)
    {
        OnListenerAdding(evnetTpye, handler);
        m_theRouter[evnetTpye] = (Action<T, U, V, W>)m_theRouter[evnetTpye] + handler;
    }

    #endregion


    #region 移除监听功能

    /// <summary>
    /// 移除监听，不带参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener(string eventType, Action handler)
    {
        if (OnListemerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }



    /// <summary>
    /// 移除监听，带1个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T>(string eventType, Action<T> handler)
    {
        if (OnListemerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }


    /// <summary>
    /// 移除监听，带2个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T, U>(string eventType, Action<T, U> handler)
    {
        if (OnListemerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T, U>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }




    /// <summary>
    /// 移除监听，带3个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T, U, V>(string eventType, Action<T, U, V> handler)
    {
        if (OnListemerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T, U, V>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }



    /// <summary>
    /// 移除监听，带4个参数
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="handler"></param>
    public void RemoveListener<T, U, V, W>(string eventType, Action<T, U, V, W> handler)
    {
        if (OnListemerRemoving(eventType, handler))
        {
            m_theRouter[eventType] = (Action<T, U, V, W>)m_theRouter[eventType] - handler;
            OnListenerRemoved(eventType);
        }
    }

    #endregion



    #region 触发事件功能

    /// <summary>
    /// 触发事件,不带参数
    /// </summary>
    /// <param name="eventType"></param>
    public void TriggerEvent(string eventType)
    {
        Delegate d;

        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();

        for (int i = 0; i < callbacks.Length; i++)
        {
            Action callback = callbacks[i] as Action;

            if (callback ==null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback();
            }
            catch (Exception)
            {
                
            }

        }
    }




    /// <summary>
    /// 触发事件,带1个参数
    /// </summary>
    /// <param name="eventType"></param>
    public void TriggerEvent<T>(string eventType,T arg1)
    {
        Delegate d;

        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();

        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T> callback = callbacks[i] as Action<T>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback(arg1);
            }
            catch (Exception)
            {

            }

        }
    }




    /// <summary>
    /// 触发事件,带2个参数
    /// </summary>
    /// <param name="eventType"></param>
    public void TriggerEvent<T,U>(string eventType, T arg1,U arg2)
    {
        Delegate d;

        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();

        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T,U> callback = callbacks[i] as Action<T,U>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback(arg1,arg2);
            }
            catch (Exception)
            {

            }

        }
    }



    /// <summary>
    /// 触发事件,带3个参数
    /// </summary>
    /// <param name="eventType"></param>
    public void TriggerEvent<T, U,V>(string eventType, T arg1, U arg2,V arg3)
    {
        Delegate d;

        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();

        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T, U,V> callback = callbacks[i] as Action<T, U,V>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback(arg1, arg2,arg3);
            }
            catch (Exception)
            {

            }

        }
    }






    /// <summary>
    /// 触发事件,带4个参数
    /// </summary>
    /// <param name="eventType"></param>
    public void TriggerEvent<T, U, V,W>(string eventType, T arg1, U arg2, V arg3,W arg4)
    {
        Delegate d;

        if (!m_theRouter.TryGetValue(eventType, out d))
        {
            return;
        }

        var callbacks = d.GetInvocationList();

        for (int i = 0; i < callbacks.Length; i++)
        {
            Action<T, U, V,W> callback = callbacks[i] as Action<T, U, V,W>;

            if (callback == null)
            {
                throw new Exception(string.Format("TriggerEvent {0} error: types of parameters are not match.", eventType));
            }

            try
            {
                callback(arg1, arg2, arg3,arg4);
            }
            catch (Exception)
            {

            }

        }
    }




    #endregion



}
