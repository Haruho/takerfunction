using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour {
    public Transform background;
    public Transform scope;

    private bool isScopeMode;
	// Use this for initialization
	void Start () {
        background.gameObject.SetActive(false);
        scope.gameObject.SetActive(false);
        isScopeMode = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ScopeMode();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Start();
        }
        if (isScopeMode)
        {
            if (Input.GetKey(KeyCode.A))
            {
                scope.Translate(new Vector3(-Time.deltaTime * 3,0,0));
            }else if (Input.GetKey(KeyCode.D))
            {
                scope.Translate(new Vector3(Time.deltaTime * 3, 0, 0));
            }
        }
	}
    public void ScopeMode()
    {
        background.gameObject.SetActive(true);
        scope.gameObject.SetActive(true);
        isScopeMode = true;
    }
}
