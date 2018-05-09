using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Taker.Player;
using UnityEngine.EventSystems;
public class SkillUpgradeSystem : MonoBehaviour {
    public Text remainPoints;
    public ToggleGroup tg;
    public Text s1_skillinfo;
    public Text s2_skillinfo;
    public Text s3_skillinfo;
    public Text s4_skillinfo;
    public Text skillinfo;
    // Use this for initialization
    void Start () {
        remainPoints.text = "Remain Points: " + PlayerState.remianPoints.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void UpgradeSkill()
    {
        IEnumerable<Toggle> t = tg.ActiveToggles();
        foreach (Toggle nt in t)
        {
            if (nt.isOn && PlayerState.remianPoints > 0)
            {
                switch (nt.name)
                {
                    case "1":
                        PlayerState.s1_level++;
                        s1_skillinfo.text = PlayerState.s1_level.ToString();
                        PlayerState.remianPoints--;
                        break;
                    case "2":
                        PlayerState.s2_level++;
                        s2_skillinfo.text = PlayerState.s2_level.ToString();
                        PlayerState.remianPoints--;
                        break;
                    case "3":
                        PlayerState.s3_level++;
                        s3_skillinfo.text = PlayerState.s3_level.ToString();
                        PlayerState.remianPoints--;
                        break;
                    case "4":
                        PlayerState.s4_level++;
                        s4_skillinfo.text = PlayerState.s4_level.ToString();
                        PlayerState.remianPoints--;
                        break;
                }
                remainPoints.text = "Remain Points: " + PlayerState.remianPoints.ToString();
            }
            else
            {
                print("Not enough points");
            }
        }
    }
    //把结果传回upgradepanle 关闭面板的时候调用 
    public void SendSkillInfoToData()
    {
        //这个skillinfo不是直接再playersates中获取的
        //直接去获取会报空指针的错误  原因不明
        skillinfo.text = "S1 : " + PlayerState.s1_level.ToString() + "\n" +
                         "S2 : " + PlayerState.s2_level.ToString() + "\n" +
                         "S3 : " + PlayerState.s3_level.ToString() + "\n" +
                         "S4 : " + PlayerState.s4_level.ToString();
    }
}
