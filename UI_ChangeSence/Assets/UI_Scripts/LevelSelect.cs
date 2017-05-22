using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LevelSelect : MonoBehaviour {

    private Toggle[] toggles;
    private SelectLevel_ScrollView levelScroll;
    private Transform toggleGroup;
    private void Awake()
    {
        toggleGroup = transform.Find("ToggleGroup");
        toggles = new Toggle[toggleGroup.childCount];
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i] = toggleGroup.GetChild(i).GetComponent<Toggle>();
        }
        toggles[0].onValueChanged.AddListener(P1OnValueChanged);
        toggles[1].onValueChanged.AddListener(P2OnValueChanged);
        toggles[2].onValueChanged.AddListener(P3OnValueChanged);
        toggles[3].onValueChanged.AddListener(P4OnValueChanged);
        toggles[4].onValueChanged.AddListener(P5OnValueChanged);

        levelScroll = transform.Find("Scroll View").GetComponent<SelectLevel_ScrollView>();
        levelScroll.RefreshToggle = OnRefreshToggle;

    }

    private void OnRefreshToggle(int index)
    {
        print(index);
        toggles[index].isOn = true;
    }

    private void P5OnValueChanged(bool isOn)
    {
        levelScroll.ShowPage5(isOn);
    }

    private void P4OnValueChanged(bool isOn)
    {
        levelScroll.ShowPage4(isOn);
    }

    private void P3OnValueChanged(bool isOn)
    {
        levelScroll.ShowPage3(isOn);
    }

    private void P2OnValueChanged(bool isOn)
    {
        levelScroll.ShowPage2(isOn);
    }

    private void P1OnValueChanged(bool isOn)
    {
        levelScroll.ShowPage1(isOn);
    }

    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
