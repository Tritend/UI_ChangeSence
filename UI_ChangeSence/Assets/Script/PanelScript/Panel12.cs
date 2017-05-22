using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Panel12 : BasePanel
{

    // Use this for initialization
    private Button X;
    void Start () {

        X = transform.GetComponent<Button>("Title&btn/X/X_btn");
        X.onClick.AddListener(OnClickX);
	}

    private void OnClickX()
    {
        UIManager.Instance.ClosePanel(GetType());
    }

    // Update is called once per frame
    void Update () {
	
	}
}
