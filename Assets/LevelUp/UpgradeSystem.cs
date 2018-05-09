using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Taker.Player
{
    public class UpgradeSystem
    {
        public int level = 1;
        public int currentEXP = 0;
        public int skill_1_level = 1;
        public int skill_2_level = 1;
        public int skill_3_level = 1;
        public int skill_4_level = 1;
        public int skillPoints = 1;
        public UpgradeSystem()
        {

        }
        /// <summary>
        /// 储存信息
        /// </summary>
        /// <param name="level">等级</param>
        /// <param name="currentEXP">当前经验</param>
        /// <param name="s1">技能等级</param>
        /// <param name="s2">技能等级</param>
        /// <param name="s3">技能等级</param>
        /// <param name="s4">技能等级</param>
        /// <param name="remainpoint">剩余技能点数</param>
        public void SaveData(int level,int currentEXP,int s1,int s2,int s3,int s4,int remainpoint)
        {
            PlayerPrefs.SetInt("level",level);
            PlayerPrefs.SetInt("currentEXP",currentEXP);

            PlayerPrefs.SetInt("s1", s1);
            PlayerPrefs.SetInt("s2", s2);
            PlayerPrefs.SetInt("s3", s3);
            PlayerPrefs.SetInt("s4", s4);

            PlayerPrefs.SetInt("sp", remainpoint);
        }
        public void LoadData()
        {
            level = PlayerPrefs.GetInt("level");
            currentEXP = PlayerPrefs.GetInt("currentEXP");

            skill_1_level = PlayerPrefs.GetInt("s1");
            skill_2_level = PlayerPrefs.GetInt("s2");
            skill_3_level = PlayerPrefs.GetInt("s3");
            skill_4_level = PlayerPrefs.GetInt("s4");

            skillPoints = PlayerPrefs.GetInt("sp");
        }

    }
}

