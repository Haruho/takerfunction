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
            ad.state = (bool)node[i]["state"];
            ad.time = (string)node[i]["time"];

            alist.Add(ad);
        }
        return alist;
    }

    /// <summary>
    /// 打开成就列表
    /// </summary>
    public void OpenAchievePanle()
    {
        int index = 0;
        //循环所有成就列表和玩家获得的成就列表
        for (int i = 0; i < allAchieveData.Count;i++)
        {
            if (!isInit)
            {
                if (allAchieveData[i].state)
                {
                    //创建完成的成就列表UI
                    GameObject go = Instantiate(achieveBox);
                    go.transform.SetParent(content.transform, false);
                    go.transform.GetChild(3).GetComponent<Text>().text = allAchieveData[i].name;
                    go.transform.GetChild(1).GetComponentInChildren<Text>().text = allAchieveData[i].describe;
                    go.transform.GetChild(2).GetComponent<Text>().text = allAchieveData[i].id.ToString();
                    //修改成就Icon
                 //   go.transform.GetChild(0).GetComponent<Image>().sprite = XXX;
                    //排序
                    go.transform.SetSiblingIndex(index);
                    index++;

                }
                else
                {
                    //创建未完成的成就列表UI
                    GameObject go = Instantiate(achieveBox);
                    go.transform.SetParent(content.transform, false);
                    //未完成显示灰色
                    go.GetComponent<Image>().color = Color.gray;
                    go.transform.GetChild(3).GetComponent<Text>().text = allAchieveData[i].name;
                    go.transform.GetChild(1).GetComponentInChildren<Text>().text = allAchieveData[i].describe;
                    go.transform.GetChild(2).GetComponent<Text>().text = allAchieveData[i].id.ToString();
                }
            }
        }
        isInit = true;
    }

    /// <summary>
    /// 完成成就测试
    /// </summary>
    public void AchieveTest()
    {
        //传入新的成就列表
        AchievementData ad = new AchievementData(6,DateTime.Now.ToShortDateString(),true);

        SavePlayerAchieveData(allAchieveData, ad);

    }

    /// <summary>
    /// 储存完成的成就
    /// </summary>
    /// <param name="plist">全部成就列表</param>
    /// <param name="newData">完成的成就</param>
    private void SavePlayerAchieveData(List<AchievementData> plist , AchievementData newData)
    {
        //litjson不知道能不能只修改一个节点，现在的存储是只要完成了成就，所有的节点就需要都重新储存一次
        //litJson创建Json字符串的方式
        StringBuilder sb = new StringBuilder();
        JsonWriter write = new JsonWriter(sb);
        write.WriteObjectStart();
        write.WritePropertyName("achieves");
        write.WriteArrayStart();
        //循环创建
        for (int i = 0;i<plist.Count;i++)
        {
            //
            if (plist[i].id == newData.id)
            {
                write.WriteObjectStart();

                write.WritePropertyName("name");
                write.Write(plist[i].name);

                write.WritePropertyName("id");
                write.Write(plist[i].id);

                write.WritePropertyName("icon");
                write.Write(plist[i].icon);

                write.WritePropertyName("describe");
                write.Write(plist[i].describe);

                write.WritePropertyName("state");
                write.Write(newData.state);

                write.WritePropertyName("time");
                write.Write(newData.time);

                write.WriteObjectEnd();
            }
            else
            {
                write.WriteObjectStart();

                write.WritePropertyName("name");
                write.Write(plist[i].name);

                write.WritePropertyName("id");
                write.Write(plist[i].id);

                write.WritePropertyName("icon");
                write.Write(plist[i].icon);

                write.WritePropertyName("describe");
                write.Write(plist[i].describe);

                write.WritePropertyName("state");
                write.Write(plist[i].state);

                write.WritePropertyName("time");
                write.Write(plist[i].time);

                write.WriteObjectEnd();
            }
        }
        write.WriteArrayEnd();
        write.WriteObjectEnd();

        print(sb.ToString());
        //指定地址并且把Json字符串存在文件中
        //如果需要上传，就只处理字符串？
        //还是在本地进行文件创建在上传？
        string path = Application.dataPath + "/Achievements/Archievements.json";
        if (!File.Exists(path))
        {
            FileStream fileStream = new FileStream(Application.dataPath + "/Achievements/Archievements.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(sb.ToString());
            streamWriter.Close();
            fileStream.Close();
            fileStream.Dispose();
        }
        else
        {
            File.Delete(path);

            FileStream fileStream = new FileStream(Application.dataPath + "/Achievements/Archievements.json", FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.WriteLine(sb.ToString());
            streamWriter.Close();
            fileStream.Close();
            fileStream.Dispose();
        }
        //程序运行中更新成就列表
        allAchieveData = GetAllAchieveData();
    }
}
