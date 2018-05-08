using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Taker.Player;
using UnityEngine.UI;
public class PlayerState : MonoBehaviour {
    public Text levelText;
    public Text expText;
    public Slider expProgress;

    private int level;
    private int currentEXP;
    private int totalEXP;
	// Use this for initialization
	void Start () {
        LoadPlayerStates();

    }
	
	// Update is called once per frame
	void Update () {

    }
    
    //进入读取
    private void LoadPlayerStates()
    {
        UpgradeSystem us = new UpgradeSystem();
        //us.LoadData();
        level = us.level;
        currentEXP = us.currentEXP;
        totalEXP = getTotalEXP(level);

        levelText.text = level.ToString();
        expText.text = currentEXP.ToString() + "/" + totalEXP.ToString();
        expProgress.maxValue = totalEXP;
        expProgress.minValue = 1;
        expProgress.value = currentEXP / totalEXP;
    }
    private int getTotalEXP(int level)
    {
        return (int)Mathf.Pow(level * (level + 1), 2);
    }
    
    private void AddExp(int exp)
    {
        //防止溢出
        if (exp > (totalEXP - currentEXP) + getTotalEXP(level + 1))
        {
            print("Too Large");
            return;
        }
        else
        {
            currentEXP += exp;
            if (currentEXP >= totalEXP)
            {
                print("Up");
                level += 1;
                currentEXP = currentEXP - totalEXP;
                totalEXP = getTotalEXP(level);
            }
            //更新UI
            levelText.text = level.ToString();
            expText.text = currentEXP.ToString() + "/" + totalEXP.ToString();
            expProgress.maxValue = totalEXP;
            expProgress.minValue = 1;
            expProgress.value = currentEXP / totalEXP;
        }
    }
    public void SaveData()
    {
        UpgradeSystem us = new UpgradeSystem();
        us.SaveData(level,currentEXP);
    }
    public void add1()
    {
        AddExp(1);
    }
    public void add2()
    {
        AddExp(10);
    }
    public void add3()
    {
        AddExp(100);
    }
    public void add4()
    {
        AddExp(1000);
    }
}
