using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
using System;

/// <summary>
/// 读取数据
/// </summary>
public class AchieveJsonHandle : MonoBehaviour {
    public GameObject content;
    public GameObject achieveBox;
    public static List<AchievementData> allAchieveData;

    /// <summary>
    /// 一次打开程序的进程中完成的成就，有待保存的列表
    /// </summary>
    private List<PlayerAchieveData> achievedData;
    //是否已经创建了列表
    private bool isInit;
	// Use this for initialization
	void Start () {
        //在进入场景的时候就载入  防止打开ui的时候卡顿
        allAchieveData = GetAllAchieveData();

        isInit = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 完成一个成就的时候调用
    /// </summary>
    /// <returns>一个Json的节点，在脚本里playerachievedata的一个实例</returns>
    public PlayerAchieveData GetPlayerAchieveData(int id,string time,bool state)
    {
        PlayerAchieveData pad = new PlayerAchieveData(id,time,state);
        return pad;
    }
    /// <summary>
    /// 所有的成就数据
    /// </summary>
    /// <returns>列表</returns>
    public List<AchievementData> GetAllAchieveData()
    {
        //读取地址
        string data = File.ReadAllText(Application.dataPath + "/Achievements/Archievements.json", Encoding.UTF8);
        //litJson读取Json
        JsonData root = JsonMapper.ToObject(data);
        //数组节点名
        JsonData node = root["achieves"];

        List<AchievementData> alist = new List<AchievementData>();

        for (int i = 0; i < node.Count; i++)
        {
            AchievementData ad = new AchievementData();
            ad.name = (string)node[i]["name"];
            ad.id = (int)node[i]["id"];
            ad.icon = (string)node[i]["icon"];
            ad.describe = (string)node[i]["describe"];
            alist.Add(ad);
        }
        return alist;
    }

    /// <summary>
    /// 打开成就列表
    /// </summary>
    public void OpenAchievePanle()
    {

        for (int i = 0;i<allAchieveData.Count;i++)
        {
            if (!isInit)
            {
                //创建成就列表UI
                GameObject go = Instantiate(achieveBox);
                go.transform.SetParent(content.transform, false);
                go.transform.GetChild(3).GetComponent<Text>().text = allAchieveData[i].name;
                go.transform.GetChild(1).GetComponentInChildren<Text>().text = allAchieveData[i].describe;
                go.transform.GetChild(2).GetComponent<Text>().text = allAchieveData[i].id.ToString();
            }
        }
        isInit = true;
    }

    /// <summary>
    /// 完成成就测试
    /// </summary>
    public void AchieveTest()
    {
        //完成成就的时候会创建一个成就类实例
        //这里先用一些数据来测试
        //AchievementData ad = new AchievementData();
        achievedData = new List<PlayerAchieveData>();
        achievedData.Add(GetPlayerAchieveData(10,DateTime.Now.ToShortDateString().ToString(),true));

        SavePlayerAchieveData(achievedData);
    }
    private void SavePlayerAchieveData(List<PlayerAchieveData> plist)
    {
        //litJson创建Json字符串的方式
        StringBuilder sb = new StringBuilder();
        JsonWriter write = new JsonWriter(sb);
        write.WriteObjectStart();
        write.WritePropertyName("player");
        write.WriteArrayStart();
        //循环创建
        for (int i = 0;i<plist.Count;i++)
        {
            write.WriteObjectStart();
            write.WritePropertyName("id");
            write.Write(plist[i].id);
            write.WritePropertyName("time");
            write.Write(plist[i].time);
            write.WritePropertyName("state");
            write.Write(true);
            write.WriteObjectEnd();
        }
        write.WriteArrayEnd();
        write.WriteObjectEnd();

        print(sb.ToString());
        //指定地址并且把Json字符串存在文件中
        //如果需要上传，就只处理字符串？
        //还是在本地进行文件创建在上传？
        string path = Application.dataPath + "/Achievements/PlayerAchieveData.json";
        if (!File.Exists(path))
        {
            FileStream fileStream = new FileStream(Application.dataPath + "/Achievements/PlayerAchieveData.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(sb.ToString());
            streamWriter.Close();
            fileStream.Close();
            fileStream.Dispose();
        }
        else
        {
            File.Delete(path);

            FileStream fileStream = new FileStream(Application.dataPath + "/Achievements/PlayerAchieveData.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(sb.ToString());
            streamWriter.Close();
            fileStream.Close();
            fileStream.Dispose();
        }
    }
}
