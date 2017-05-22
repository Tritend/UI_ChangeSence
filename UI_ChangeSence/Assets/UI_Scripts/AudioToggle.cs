using UnityEngine;
using System.Collections;

public class AudioToggle : BaseToggle {

    private Transform on;
    private Transform off;

    protected override void Awake()
    {
        base.Awake();
        on = transform.Find("Background/ON");
        off = transform.Find("Background/OFF");
    }

    protected override void OnValueChanged(bool isOn)
    {
        RefreshToggle();
    }

    private void RefreshToggle()
    {
        if (null!=toggle)
        {
            if (toggle.isOn)
            {
                on.gameObject.SetActive(true);
                off.gameObject.SetActive(false);
            }
            else
            {
                on.gameObject.SetActive(false);
                off.gameObject.SetActive(true);
            }
        }
    }
}
