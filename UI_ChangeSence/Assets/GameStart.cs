using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //UIManager.Instance.OpenPanel<Panel6>();
        //UIManager.Instance.OpenPanel<Panel1>();
        //UIManager.Instance.OpenPanel<Panel2>();
        UIManager.Instance.OpenPanel<PanelLogin>();
    }

    // Update is called once per frame
    void Update () {























        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    UIManager.Instance.OpenPanel<Panel6>();
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    MuduleManager.Get<RoleModule>().Level++;
        //    print("Level:  " + MuduleManager.Get<RoleModule>().Level);
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    MuduleManager.Get<RoleModule>().Name = "浅风";
        //}

    }
}
