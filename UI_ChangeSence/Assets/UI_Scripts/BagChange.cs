using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BagChange : MonoBehaviour
{
    private Toggle toggle;
    private Image backimage;
    private Text label;
    public Color color;
    void Start()
    {
        toggle = /*transform.Find("ITEM").*/GetComponent<Toggle>();
        backimage = transform.Find("Background").GetComponent<Image>();
        label = transform.Find("Label").GetComponent<Text>();
        toggle.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(bool IsChange)
    {
        backimage.enabled = !IsChange;
        if (null != label)
        {
            if (IsChange)
            {
                label.color = color;
            }
            else
            {
                label.color = Color.black;
            }
        }
    }

    void Update()
    {
    }

}
