using UnityEngine;
using System.Collections;

public abstract class DDOLSingleton<T> : MonoBehaviour where T : DDOLSingleton<T>
{
    protected static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {

                GameObject go = GameObject.Find("DDOL");

                if (go == null)
                {
                    go = new GameObject("DDOL");
                    DontDestroyOnLoad(go);
                }

                _instance = go.GetOrAdd<T>();
            }
            return _instance;
        }
    }


    private void OnApplicationQuit()
    {
        _instance = null;
    }


}
