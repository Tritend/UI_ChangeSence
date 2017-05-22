using System;
using System.Collections.Generic;

public sealed class MuduleManager {

    private readonly static Dictionary<Type, BaseModule> dicModules=new Dictionary<Type, BaseModule>();


    static MuduleManager()
    {
        //添加我们的数据脚本
        Add<Role>();
        Add<RoleModule>();
    }

    /// <summary>
    /// 添加数据接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static void Add<T>() where T : BaseModule, new()
    {
        dicModules.Add(typeof(T),new T()); 
    }


    /// <summary>
    /// 获取module数据接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Get<T>() where T : BaseModule, new()
    {
        BaseModule module;
        if (dicModules.TryGetValue(typeof(T),out module))
        {
            return module as T;
        }
        return null;
    }


}
