using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{

    #region UIModel

    //UI数据
    class UIModel
    {
        //UI界面对应的脚本
        public Type UIType;
        //UI界面对应的资源路径
        public string Path;
        //打开界面需要的参数
        public object[] Parmas;

        public UIModel(Type uiType, string path, params object[] args)
        {
            UIType = uiType;
            Path = path;
            Parmas = args;
        }
    }

    #region UIContainer

    private Transform uiContainer = null;

    /// <summary>
    /// 所有UIpanel存放的
    /// </summary>
    public Transform UiContainer
    {
        get
        {
            if (uiContainer == null)
            {
                GameObject rootUI = GameObject.Find("RootUI");

                if (rootUI == null)
                {
                    UnityEngine.Object prefab = Resources.Load("Prefabs/UI/RootUI");
                    rootUI = GameObject.Instantiate(prefab) as GameObject;
                    rootUI.name = prefab.name;
                }
                uiContainer = rootUI.transform.Find("UICamera/ScreenAdaptor/Canvas/Container");
            }
            return uiContainer;
        }
    }

    #endregion

    //打开UI界面和隐藏的界面
    private Dictionary<Type, BasePanel> dicOpenPanels = new Dictionary<Type, BasePanel>();

    private Stack<UIModel> stackModels = new Stack<UIModel>();

    public override void Init()
    {
        //启动检测延迟摧毁
        CoroutineController.Instance.StartCoroutine(CheckDestoryPanel());
    }

    /// <summary>
    /// 检测需要延迟关闭的界面
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckDestoryPanel()
    {
        float checkTimes = 1.0f;

        //   WaitForSeconds wait  =new WaitForSeconds(checkTimes);


        while (true)
        {
            yield return new WaitForSeconds(checkTimes);

            List<Type> removeList = new List<Type>();

            foreach (var item in dicOpenPanels)
            {

                if (item.Value == null)
                {
                    removeList.Add(item.Key);
                    continue;
                }
                float timer = item.Value.ReduceDestoryTimer(checkTimes);
                if (timer <= 0)
                {
                    removeList.Add(item.Key);
                }
            }


       //     Debug.Log( dicOpenPanels.Count+"    "+ + removeList.Count);

            foreach (var item in removeList)
            {
                // DestoryPanel
                 DestoryPanel(item);
            }

        }

    }

    #endregion

    //摧毁panel
    public void DestoryPanel(Type uiType)
    {
        BasePanel panel;
        if (dicOpenPanels.TryGetValue(uiType,out panel)  && panel!=null)
        {
            GameObject.Destroy(panel.gameObject);
        }

        dicOpenPanels.Remove(uiType);
    }




    #region Open Panel API


    /// <summary>
    /// 打开指定的界面,可以有参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args"></param>
    public void OpenPanel<T>(params object[] args) where T : MonoBehaviour
    {
        Type[] uiTypes = new Type[] { typeof(T) };
        OpenPanel(false, uiTypes, args);
    }

    /// <summary>
    /// 打开多个UI界面
    /// </summary>
    /// <param name="uiTypes"></param>
    public void OpenPanel(Type[] uiTypes)
    {
        OpenPanel(false, uiTypes);
    }

    /// <summary>
    /// 打开指定的界面，关闭其他可以关的界面
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args"></param>
    public void OpenPanelColseOther<T>(params object[] args) where T : MonoBehaviour
    {
        Type[] uiTypes = new Type[] { typeof(T) };
        OpenPanel(true, uiTypes, args);
    }

    /// <summary>
    /// 打开多个界面，关闭其他可以关的界面
    /// </summary>
    /// <param name="uiTypes"></param>
    public void OpenPanelColseOther(Type[] uiTypes)
    {
        OpenPanel(true, uiTypes);
    }

    /// <summary>
    /// 打开UI界面
    /// </summary>
    /// <param name="isCloseOther"></param>
    /// <param name="uiTypes"></param>
    /// <param name="args"></param>
    public void OpenPanel(bool isCloseOther, Type[] uiTypes, params object[] args)
    {
        if (isCloseOther)
        {

            // CloseOtherPanel
           CloseOtherPanel();
        }

        int max = uiTypes.Length;

        for (int i = 0; i < max; i++)
        {
            Type _uiType = uiTypes[i];

            BasePanel panel;
            //已经在字典里面的，直接打开界面。如果不再我们就需要load预制物，然后实例
            if (dicOpenPanels.TryGetValue(_uiType, out panel) && panel != null)
            {
                panel.SetVisable(true);
            }
            else
            {
                string path = UIDefines.GetPath(_uiType);
                stackModels.Push(new UIModel(_uiType, path, args));
            }
        }

        //没有在字典里面要打开的UI，需要load预制物，然后实例
        if (stackModels.Count > 0)
        {
            CoroutineController.Instance.StartCoroutine(AsyncLoadData());
        }

    }


    /// <summary>
    /// 异步加载界面，可以把当前帧显示的对象放在里面
    /// 
    /// 不要立即显示的可以放在pane里面的OnAsyncLoad()异步加载方法里面去
    /// </summary>
    /// <returns></returns>

    private IEnumerator<int> AsyncLoadData()
    {
        UIModel model = null;
        UnityEngine.Object prefab = null;
        GameObject uiObj = null;

        if (stackModels != null && stackModels.Count > 0)
        {
            do
            {
                model = stackModels.Pop();
                prefab = Resources.Load(model.Path);
                if (null == prefab)
                {
                    yield break;
                }

                uiObj = GameObject.Instantiate(prefab) as GameObject;
                if (null == uiObj)
                {
                    yield break;
                }

                RectTransform rt = uiObj.GetOrAdd<RectTransform>();
                rt.SetParent(UiContainer, false);
                rt.name = prefab.name;

                BasePanel panel = uiObj.GetComponent<BasePanel>();
                if (panel == null)
                {
                    panel = uiObj.AddComponent(model.UIType) as BasePanel;
                }

                if (panel != null)
                {
                    //调用界面打开参数传递方法，异步加载
                    panel.SetUIWhenOpening(model.Parmas);
                }

            } while (stackModels.Count > 0);

            yield return 0;

        }

    }

    #endregion


    #region  ShowPanel

    public void ShowPanel<T>(BasePanel panel)
    {
        ShowPanel(typeof(T), panel);
    }

    /// <summary>
    /// 显示一个panel，播放动画，注册到管理器
    /// </summary>
    /// <param name="uiType"></param>
    /// <param name="panel"></param>
    public void ShowPanel(Type uiType, BasePanel panel)
    {
        panel.SetVisable(true);
        if (!dicOpenPanels.ContainsKey(uiType))
        {
            dicOpenPanels.Add(uiType, panel);
        }
    }

    /// <summary>
    /// 隐藏界面
    /// </summary>
    /// <param name="uiType"></param>
    public void HidePanel(Type uiType)
    {
        ClosePanel(uiType, false);
    }


    /// <summary>
    /// 关闭所有界面
    /// </summary>
    public void CloseOtherPanel()
    {
        List<Type> keys=new List<Type>(dicOpenPanels.Keys);

        for (int i = 0; i < keys.Count; i++)
        {
            ClosePanel(keys[i],false);
        }
    }


    public void ClosePanel<T>() where T:BasePanel
    {
        ClosePanel(typeof (T), false);
    }


    /// <summary>
    /// 关闭指定界面
    /// </summary>
    /// <param name="uiTypes"></param>
    public void ClosePanel(Type[] uiTypes)
    {
        int max = uiTypes.Length;
        for (int i = 0; i < max; i++)
        {
            ClosePanel(uiTypes[i], true);
        }
    }


    /// <summary>
    /// 关闭界面，移除已经摧毁的界面，如果需要批处理，就不关闭
    /// </summary>
    /// <param name="uiType"></param>
    /// <param name="isBatch"></param>
    public void ClosePanel(Type uiType, bool isBatch = false)
    {

        BasePanel panel;

        if (dicOpenPanels.TryGetValue(uiType, out panel) && panel != null)
        {
            if (isBatch && panel.IgnoreBatchClose)
            {
                return;
            }
            if (panel.IsShow)
            {
                panel.SetVisable(false);
            }
        }
        else
        {
            dicOpenPanels.Remove(uiType);
        }
    }


    #endregion


}
