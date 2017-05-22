using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScene : BaseScene
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override IEnumerator OnAsyncLoad()
    {
        yield return base.OnAsyncLoad();


        for (int j = 0; j < 30; j++)
        {
            new GameObject("个数：" + j.ToString());
            yield return new WaitForSeconds(1f);
        }


    }
}
