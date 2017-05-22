using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Bag_R_L : MonoBehaviour
{
    private Button right;
    private Button left;
    private Toggle[] toggles;
    private Text text;
    private int index = 0;
    private int togglenum;

    private void Awake()
    {
        if (null != transform.Find("ToggleGroup"))
        {
            int togglenum = transform.Find("ToggleGroup").childCount;
            toggles = new Toggle[togglenum];

            for (int i = 0; i < togglenum; i++)
            {
                toggles[i] = transform.Find("ToggleGroup").GetChild(i).GetComponent<Toggle>();
            }
        }
    }
    void Start()
    {
        text = transform.Find("Text/Text").GetComponent<Text>();
        right = transform.Find("R_btn").GetComponent<Button>();
        left = transform.Find("L_btn").GetComponent<Button>();
        right.onClick.AddListener(OnClickR);
        left.onClick.AddListener(OnClickL);
        //print(transform.Find("ToggleGroup").GetChild(2).GetComponent<Toggle>().name);
    }

    private void OnClickL()
    {
        index--;
        if (index < 0)
        {
            index = 0;
        }

        toggles[index].isOn = true;
    }
    private void OnClickR()
    {
        index++;
        if (index > 2)
        {
            index = 2;
        }
        toggles[index].isOn = true;
    }
    public void OnClickBagPage()
    {
        index = 0;
        text.text = "1/3";
    }
    public void OnClickBagPage1()
    {
        index = 1;
        text.text = "2/3";
    }
    public void OnClickBagPage2()
    {
        index = 2;
        text.text = "3/3";
    }


    void Update()
    {
    }
}
