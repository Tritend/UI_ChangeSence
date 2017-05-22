using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skill : MonoBehaviour {
    public float CD;
    private bool isOK =false;
    public KeyCode keyCode;

    private Slider _slider;
    float timer;

    public Slider Slider
    {
        get {
            if (_slider==null) { _slider = GetComponent<Slider>(); }
            
            return _slider; }
       // set { _slider = value; }
    }
    
	// Use this for initialization
	void Start () {

      


	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(keyCode))
        {
            isOK = false;
            
        }


        if (!isOK)
        {
            timer+=Time.deltaTime;

            this.Slider.value = (CD - timer) / CD;

            if (CD<=timer)
            {

                isOK = true;
                timer = 0;
            }

        }


	}


    public void FreeSkill()
    {
        if (isOK)
        {
            isOK = false;

        }
   
    
    }




}
