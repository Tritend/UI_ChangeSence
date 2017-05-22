using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum E_TouchType : byte
{
    OnClick,
    OnDoubleClick,
    OnDown,
    OnUp,
    OnEnter,
    OnExit,
    OnSelect,
    OnUpdateSelect,
    OnDeSelect,
    OnDrag,
    OnDragEnd,
    OnDrop,
    OnScroll,
    OnMove,
}


public delegate void OnTouchHandle(GameObject _listener, object _args, params object[] _params);


public class TouchHandle
{
    public E_TouchType TouchType;
    private event OnTouchHandle eventHandle = null;
    private object[] handParams;


    public TouchHandle()
    {
    }

    public TouchHandle(OnTouchHandle _handle, params object[] _params)
    {
        eventHandle += _handle;
        handParams = _params;
    }

    /// <summary>
    /// 设置数据，注意会清除之前设置的信息
    /// </summary>
    /// <param name="_handle"></param>
    /// <param name="_params"></param>
    public void SetHandle(OnTouchHandle _handle, params object[] _params)
    {
        DestoryHandle();
        eventHandle += _handle;
        handParams = _params;
    }

    /// <summary>
    /// 触发委托的方法
    /// </summary>
    /// <param name="_listener"></param>
    /// <param name="_args"></param>
    public void CallEventHandle(GameObject _listener, object _args)
    {
        if (eventHandle != null)
        {
            eventHandle(_listener, _args, handParams);
        }
    }

    /// <summary>
    /// 清空之前的存储信息
    /// </summary>
    public void DestoryHandle()
    {
        if (null != eventHandle)
        {
            eventHandle -= eventHandle;

            eventHandle = null;
        }
    }


}



public class EventListener : MonoBehaviour,
#region interface
    IPointerClickHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerEnterHandler,
    IPointerExitHandler,

    ISelectHandler,
    IUpdateSelectedHandler,
    IDeselectHandler,

    IDragHandler,
    IEndDragHandler,
    IDropHandler,
    IScrollHandler,
    IMoveHandler
#endregion
{

    public Dictionary<E_TouchType, TouchHandle> dicHandles = new Dictionary<E_TouchType, TouchHandle>();


    public static EventListener Get(GameObject go)
    {
        return go.GetOrAdd<EventListener>();
    }

    public static EventListener Get(Transform tran)
    {
        return tran.GetOrAdd<EventListener>();
    }

    public static EventListener Get(Button btn)
    {
        return btn.GetOrAdd<EventListener>();
    }

    private void OnDestory()
    {
        RemoveAllHandle();
    }

    private void RemoveAllHandle()
    {
        foreach (var item in dicHandles)
        {
            item.Value.DestoryHandle();
        }
        dicHandles.Clear();
    }






    /// <summary>
    /// 获取事件类型的方法
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public TouchHandle GetHandle(E_TouchType type)
    {
        TouchHandle handle;
        if (dicHandles.TryGetValue(type,out handle))
        {
            return handle;
        }

        return null;
    }

    /// <summary>
    /// 设置添加一个事件功能
    /// </summary>
    /// <param name="_type"></param>
    /// <param name="_handle"></param>
    /// <param name="_params"></param>
    public void SetEventListener(E_TouchType _type, OnTouchHandle _handle, params object[] _params)
    {
        TouchHandle handle = GetHandle(_type);
        if (handle==null)
        {
            handle=new TouchHandle();
            dicHandles.Add(_type,handle);
         }

        dicHandles[_type].TouchType = _type;
        dicHandles[_type].SetHandle(_handle, _params);
    }



    #region Interface implementation

    #region IDragHandler implementation

    public void OnDrag(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDrag);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IEndDragHandler implementation

    public void OnEndDrag(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDragEnd);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IDropHandler implementation

    public void OnDrop(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDrop);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerClickHandler implementation

    public void OnPointerClick(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnClick);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerDownHandler implementation

    public void OnPointerDown(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDown);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerUpHandler implementation

    public void OnPointerUp(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnUp);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }
    #endregion

    #region IPointerEnterHandler implementation

    public void OnPointerEnter(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnEnter);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IPointerExitHandler implementation

    public void OnPointerExit(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnExit);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region ISelectHandler implementation

    public void OnSelect(BaseEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnSelect);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IUpdateSelectedHandler implementation

    public void OnUpdateSelected(BaseEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnUpdateSelect);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IDeselectHandler implementation

    public void OnDeselect(BaseEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnDeSelect);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IScrollHandler implementation

    public void OnScroll(PointerEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnScroll);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    #endregion

    #region IMoveHandler implementation

    public void OnMove(AxisEventData eventData)
    {
        TouchHandle handle = GetHandle(E_TouchType.OnMove);
        if (handle != null)
        {
            handle.CallEventHandle(this.gameObject, eventData);
        }
    }

    internal void SetEventListener(E_TouchType onClick, Button back)
    {
        throw new NotImplementedException();
    }

    #endregion

    #endregion



}
