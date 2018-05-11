using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 已经获得的数据
/// </summary>
public class PlayerAchieveData{
    /// <summary>
    /// 编号
    /// </summary>
    public int id;
    /// <summary>
    /// 完成时间
    /// </summary>
    public string time;
    /// <summary>
    /// 状态
    /// </summary>
    public bool state;

    public PlayerAchieveData(int id,string time,bool state)
    {
        this.id = id;
        this.time = time;
        this.state = state;
    }
    public PlayerAchieveData()
    {
        return;
    }
}
