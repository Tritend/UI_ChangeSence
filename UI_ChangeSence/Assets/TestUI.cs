using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TestUI : MonoBehaviour
{

    Image CBA;

    void Start()
    {
        CBA = transform.GetComponent<Image>("CBA");
        Button btn = transform.GetComponent<Button>("CBA/Button");
        EventListener.Get(btn).SetEventListener(E_TouchType.OnClick, OnClick, Color.red, Color.blue); 


    }

    private void OnClick(GameObject _listener, object _args, object[] _params)
    {
        int count = _params.Length;
        int index = UnityEngine.Random.Range(0, count);
        CBA.color = (Color)_params[index];
    }



    // Update is called once per frame
    void Update()
    {

    }
}
