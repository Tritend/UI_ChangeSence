using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Singleton<T> where T : class, new()
{
    protected static T _instance = null;

    public static T Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new T();
            }
            return _instance;
        }
    }

    protected Singleton()
    {
        if (_instance !=null)
        {
            throw new Exception("This " + typeof(T).ToString() + " Singleton Instance is not null");
        }

        Init();
    }

    public virtual void Init()
    {
        //启动延时摧毁功能
    }



}
