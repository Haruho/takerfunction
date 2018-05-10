using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleSaveLoad : MonoBehaviour {
    public Toggle rUserName;
    public InputField userName;
	// Use this for initialization
	void Start () {
        //get一个没有的值  会返回0
    //    print(PlayerPrefs.GetInt("sdddd"));
        // 1true
        if (PlayerPrefs.GetInt("rUserName") == 1)
        {
            rUserName.isOn = true;
        }
        else
        {
            rUserName.isOn = false;
        }
        rUserName.onValueChanged.AddListener(SetRememberUserName);

        if (PlayerPrefs.GetString("userName") != "")
        {
            print(PlayerPrefs.GetString("userName"));
            userName.text = PlayerPrefs.GetString("userName");
        }
        else
        {
            userName.textComponent.text = "";
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetRememberUserName(bool isremember)
    {
        if (isremember)
        {
            PlayerPrefs.SetInt("rUserName", 1);
        }
        else
        {
            PlayerPrefs.SetInt("rUserName",0);
        }
    }
    public void LogIn()
    {
        print(userName.textComponent.text);
        if (rUserName.isOn)
        {
            PlayerPrefs.SetString("userName", userName.textComponent.text);
        }
        else
        {
            PlayerPrefs.SetString("userName", "");
        }
    }
}
