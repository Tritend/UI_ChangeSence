using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BaseToggle : MonoBehaviour {

    protected Toggle toggle;
    protected virtual void Awake ()
    {
        toggle = GetComponent<Toggle>();
    }

    protected virtual void Start ()
    {
        if (null!=toggle)
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }
	}

    protected virtual void OnValueChanged(bool isOn)
    {

    }

    // Update is called once per frame
    protected virtual void Update () {
	
	}
}
