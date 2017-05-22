using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 逻辑场景基类
/// </summary>
public class BaseScene : MonoBehaviour {


    protected virtual void SetParams(params object[] args)
    { 
    
    
    }

    protected virtual IEnumerator OnAsyncLoad()
    {
        yield return new WaitForEndOfFrame();   
    }


    public void SetWhenOpening(params object[] args)
    {
        SetParams(args);

        StartCoroutine(OnAsyncLoad());
    }

    public virtual void Release()
    { 
    
    
    }

}
