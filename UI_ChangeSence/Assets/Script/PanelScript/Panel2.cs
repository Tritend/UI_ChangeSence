using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel2 : BasePanel
{

    private Button btn;
    private bool isopen = false;
    // Use this for initialization
    void Start()
    {
        btn = transform.GetComponent<Button>("Button");
        btn.onClick.AddListener(OnClickBtn);
    }

    private void OnClickBtn()
    {

        ScenesManager.Instance.ChangeScene<CopyScene>(true);
        //if (isopen ==false)
        //{
        //  UIManager.Instance.ClosePanel<Panel1>();
        //  isopen = true;
        //}
        //else if (isopen == true)
        //{
        //    //print("QWE"+isopen);
        //    UIManager.Instance.OpenPanel<Panel1>();
        //    isopen = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
