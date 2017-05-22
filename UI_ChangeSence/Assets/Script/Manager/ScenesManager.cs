using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    #region Model

    #region SceneInfoData

    public class SceneInfoData
    {
        public Type SceneType { get; private set; }

        public string SceneName { get; private set; }

        public object[] Params { get; set; }


        public SceneInfoData(Type _sceneType, params object[] _params)
        {
            this.SceneType = _sceneType;
            if (_params != null && _params.Length > 0)
            {
                SceneName = (string)_params[0];
            }
            Params = _params;
        }
    }

    #endregion

    private Dictionary<Type, SceneInfoData> dicInfo = new Dictionary<Type, SceneInfoData>();

    public BaseScene CurrentScene;

    public Type LastSceneType;
    public Type CurrentType;

    #endregion

    public override void Init()
    {
        //注册我们的场景

        Register<LoadingScene>();

        Register<MainScene>("main");
        Register<CopyScene>();
        
    }


    #region Scene Basic Method
    /// <summary>
    /// 注册场景，注意：不给参数场景名字就是类名，如果有参数第一个参数就是场景名字
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_params"></param>
    public void Register<T>(params object[] _params) where T : BaseScene
    {
        if (dicInfo.ContainsKey(typeof(T)) == false)
        {
            SceneInfoData data;
            if (_params != null && _params.Length > 0)
            {
                data = new SceneInfoData(typeof(T), _params);
            }
            else
            {
                data = new SceneInfoData(typeof(T), typeof(T).Name);
            }

            dicInfo.Add(typeof(T), data);
        }
    }


    /// <summary>
    /// 移除场景
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void UnRegister<T>() where T : BaseScene
    {

        if (dicInfo.ContainsKey(typeof(T)))
        {
            dicInfo.Remove(typeof(T));
        }

    }



    public bool IsRigister<T>() where T : BaseScene
    {
        return dicInfo.ContainsKey(typeof(T));
    }


    public T GetCurrentScene<T>() where T : BaseScene
    {
        return CurrentScene as T;
    }


    public T GetScene<T>() where T : BaseScene
    {
        return GetScene(typeof(T)) as T;
    }

    public BaseScene GetScene(Type sceneType)
    {
        SceneInfoData data = GetData(sceneType);

        if (data == null)
        {
            return null;
        }

        GameObject go = GameObject.FindObjectOfType(data.SceneType) as GameObject;

        if (go == null)
        {
            go = new GameObject(data.SceneName, data.SceneType);
        }

        BaseScene bs = go.GetComponent(data.SceneType) as BaseScene;
        return bs;
    }

    public SceneInfoData GetData<T>() where T : BaseScene
    {
        return GetData(typeof(T));
    }
    public SceneInfoData GetData(Type sceneType)
    {
        if (dicInfo.ContainsKey(sceneType))
        {
            return dicInfo[sceneType];
        }
        return null;
    }


    public string GetName<T>() where T : BaseScene
    {
        SceneInfoData data = GetData<T>();

        if (data != null)
        {
            return data.SceneName;
        }
        return null;
    }

    public void Clear()
    {
        dicInfo.Clear();
    }


    #endregion


    /// <summary>
    /// 默认不带loading界面，不带参数的切换到指定场景
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hasLoading"></param>
    public void ChangeScene<T>(bool hasLoading = false) where T : BaseScene
    {
        ChangeScene<T>(hasLoading, null);
    }


    /// <summary>
    /// 切换到指定场景
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="hasLoading"></param>
    /// <param name="args"></param>
    public void ChangeScene<T>(bool hasLoading, params object[] args) where T : BaseScene
    {
        UIManager.Instance.CloseOtherPanel();

        if (CurrentScene != null)
        {
            CurrentScene.Release();
            //CurrentScene = null;
        }
        LastSceneType = CurrentType;

        SceneInfoData data = GetData<T>();
        data.Params = args;
        if (hasLoading)
        {
            CoroutineController.Instance.StartCoroutine(AsyncLoadOtherScene(data));
        }
        else
        {
            CoroutineController.Instance.StartCoroutine(AsyncLoadScene(data));
        }
    }

    /// <summary>
    /// 有进度条的异步加载
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private IEnumerator<AsyncOperation> AsyncLoadOtherScene(SceneInfoData data)
    {
        string loadingName = GetName<LoadingScene>();

        AsyncOperation oper = SceneManager.LoadSceneAsync(loadingName);

        yield return oper;


        //load场景加载完成
        if (oper.isDone)
        {
            UIManager.Instance.OpenPanel<LoadingPanel>();
            CurrentScene = GetScene<LoadingScene>();

            LoadLogicScene(data);
        }
    }


    /// <summary>
    ///没有进度条的异步加载
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private IEnumerator<AsyncOperation> AsyncLoadScene(SceneInfoData data)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(data.SceneName);
        
        yield return oper;

        if (oper.isDone)
        {
            CurrentScene = GetScene(data.SceneType);
            LoadLogicScene(data);
        }
    }


    public IEnumerator LoadLogicScene()
    {
        yield return null;

   //     Debug.Log(GetCurrentScene<LoadingScene>().SceneType);
        BaseScene logicBaseScene = GetScene(GetCurrentScene<LoadingScene>().SceneType);
        logicBaseScene.SetWhenOpening(null);
    }


    /// <summary>
    /// 加载逻辑场景
    /// </summary>
    /// <param name="data"></param>
    private void LoadLogicScene(SceneInfoData data)
    {
        if (data!=null)
        {
            CurrentScene.SetWhenOpening(data.SceneName,data.SceneType,data.Params);
        }

    }



}
