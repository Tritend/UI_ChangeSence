using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class T123 : MonoBehaviour {

	void Start () {

        for (int i = 0; i < transform.childCount; i++)
        {
            Text text = transform.GetChild(i).Find("Unlock/Text").GetComponent<Text>();
            text.text = (i + 1).ToString();
        }


	}
	
	void Update () {
	
	}
}
