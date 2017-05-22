using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelLogin : BasePanel
{

    // Use this for initialization
    private Button btn;
    void Awake()
    {
        btn = transform.GetComponent<Button>("Input/blue_btn");
    }
    void Start () {

        EventListener.Get(btn).SetEventListener(E_TouchType.OnClick, Paneltou);
    }

    // Update is called once per frame
    void Update () {
	
	}
    private void Paneltou(GameObject _listener, object _args, object[] _params)
    {
        UIManager.Instance.OpenPanel<Paneltou>();
        UIManager.Instance.ClosePanel(GetType());
    }


}
