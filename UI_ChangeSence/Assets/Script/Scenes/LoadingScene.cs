using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingScene : BaseScene
{

    public Type SceneType;
    private string SceneName;

    private AsyncOperation Operation;



    protected override void SetParams(params object[] args)
    {
        if (args == null || args.Length < 3)
        {
            return;
        }

        SceneName = args[0] as string;
        SceneType = args[1] as Type;
    }

    protected override IEnumerator OnAsyncLoad()
    {
        yield return base.OnAsyncLoad();

        EventDispatcher.TriggerEvent<int>(Events.LoadingEvent.OnLoadingProcess, 10);

        yield return new WaitForSeconds(1f);


        Operation = SceneManager.LoadSceneAsync(SceneName);
        Operation.allowSceneActivation = false;



        EventDispatcher.TriggerEvent<int>(Events.LoadingEvent.OnLoadingProcess, 30);

        yield return new WaitForSeconds(2f);
        EventDispatcher.TriggerEvent<int>(Events.LoadingEvent.OnLoadingProcess, 80);

        yield return new WaitForSeconds(1f);
        EventDispatcher.TriggerEvent<int>(Events.LoadingEvent.OnLoadingProcess, 100);

        yield return new WaitForEndOfFrame();

        EventDispatcher.TriggerEvent<bool>(Events.LoadingEvent.OnLoadingFinished, true);




    }




    public void OnFinished()
    {
     //   Debug.Log((Operation != null) + "    " + Operation.isDone);
     //   if (Operation != null && Operation.isDone)

        if (Operation != null)
        {
            Operation.allowSceneActivation = true;
            CoroutineController.Instance.StartCoroutine(ScenesManager.Instance.LoadLogicScene());
        }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
    }



    private void Update()
    {
        if (Operation != null && Operation.progress < 0.9f)
        {
            EventDispatcher.TriggerEvent<int>(Events.LoadingEvent.OnLoadingProcess, 10 + (int)(40 * Operation.progress / 0.9));
        }
    }



}
