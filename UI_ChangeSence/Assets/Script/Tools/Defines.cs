using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;


/// <summary>
/// UI定义工具类
/// </summary>
public class UIDefines
{
    //ui资源主目录
    public const string UI_PREFAB = "Prefabs/UI/";

    private  static Dictionary<Type,string> dicPaths=new Dictionary<Type, string>();

    public static string GetPath<T>() where T : MonoBehaviour
    {
        return GetPath(typeof (T));
    }

    //获取UI资源路径
    public static string GetPath(Type uiType)
    {
        string path;

        if (dicPaths.TryGetValue(uiType,out path))
        {
            return path;
        }
        path = UI_PREFAB + uiType.Name;
        dicPaths.Add(uiType,path);
        return path;
    }

    static UIDefines()
    {
        //如果我们的UIpanel，没有在默认路径下，或者预设名字和脚本名字不一样，我们需要在这里面自定义
     //   dicPaths.Add(typeof(BasePanel), UI_PREFAB + "ABC/BasePanel");
       // dicPaths.Add(typeof(PanelB), UI_PREFAB + "PanelB1");


    }


}
