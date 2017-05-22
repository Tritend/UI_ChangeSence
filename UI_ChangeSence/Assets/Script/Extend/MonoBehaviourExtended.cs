using UnityEngine;
using System.Collections;

public static class MonoBehaviourExtended
{

    public static T GetOrAdd<T>(this GameObject go, string path = "") where T : Component
    {
        Transform t;

        if (string.IsNullOrEmpty(path))
        {
            t = go.transform;
        }
        else
        {
            t = go.transform.Find(path);
        }

        if (t == null)
        {

            Debug.LogError("GetOrAdd not find GameObject at path:" + path);
            return null;
        }

        T res = t.GetComponent<T>();
        if (res == null)
        {
            res = t.gameObject.AddComponent<T>();
        }

        return res;
    }

    public static T GetOrAdd<T>(this Transform go, string path = "") where T : Component
    {
        return GetOrAdd<T>(go.gameObject, path);
    }

    public static T GetOrAdd<T>(this MonoBehaviour go, string path = "") where T : Component
    {
        return GetOrAdd<T>(go.gameObject, path);
    }

    public static T GetComponent<T>(this Transform go, string path = "") where T : Component
    {
        Transform t;

        if (string.IsNullOrEmpty(path))
        {
            t = go.transform;
        }
        else
        {
            t = go.transform.Find(path);
        }

        if (t == null)
        {
            return null;
        }

        return t.GetComponent<T>();
    }
}
