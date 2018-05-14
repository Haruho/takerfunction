using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementData{
    /// <summary>
    /// 名称
    /// </summary>
    public string name;
    /// <summary>
    /// 描述
    /// </summary>
    public string describe;
    /// <summary>
    /// 编号
    /// </summary>
    public int id;
    /// <summary>
    /// Icon的名字
    /// </summary>
    public string icon;
    /// <summary>
    /// 状态
    /// </summary>
    public bool state;
    /// <summary>
    /// 时间
    /// </summary>
    public string time;
    /// <summary>
    /// 完成一个成就需要的信息
    /// </summary>
    public AchievementData(int _id,string _time,bool _state)
    {
        id = _id;
        time = _time;
        state = _state;
    }
    public AchievementData()
    {
        return;
    }
}
