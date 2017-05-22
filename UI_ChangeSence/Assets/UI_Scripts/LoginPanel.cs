using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LoginPanel : BasePanel
{

    private Text Name;
    private Toggle toggle;
    private Button btn;

    private void Awake()
    {
        Name = transform.Find("Name_InputField/Text").GetComponent<Text>();
        //Name = transform.GetComponent<Text>("Name_InputField");
        toggle = transform.Find("Toggle").GetComponent<Toggle>();
        //toggle = transform.GetComponent<Toggle>("Toggle");
        btn = transform.Find("blue_btn").GetComponent<Button>();
        //btn = transform.GetComponent<Button>("blue_btn");
        if (PlayerPrefs.HasKey("Name"))
        {
            transform.Find("Name_InputField").GetComponent<InputField>().text= PlayerPrefs.GetString("Name");
        }
    }

	void Start () {

        btn.onClick.AddListener(OnClick);

    }



    private void OnClick()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetString("Name", Name.text);
            MuduleManager.Get<Role>().Name = PlayerPrefs.GetString("Name");
        }
        else
        {
            PlayerPrefs.DeleteKey("Name");
        }
    }

    void Update () {
        if (PlayerPrefs.HasKey("Name"))
        {
        }

    }
}
