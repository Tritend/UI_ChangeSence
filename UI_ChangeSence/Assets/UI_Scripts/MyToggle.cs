using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyToggle : MonoBehaviour,IPointerClickHandler {

    public GameObject gameobject_on;
    public GameObject gameobject_off;
    Toggle _toggle;

	// Use this for initialization

    
    void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

	void Start () {
        gameobject_on.SetActive(_toggle.isOn);
        gameobject_off.SetActive(!_toggle.isOn);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

public void OnPointerClick(PointerEventData eventData)
{

    gameobject_on.SetActive ( _toggle.isOn);
    gameobject_off.SetActive(!_toggle.isOn);



}




}
