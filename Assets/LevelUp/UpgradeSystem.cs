using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Taker.Player
{
    public class UpgradeSystem
    {
        public int level = 1;
        public int currentEXP = 0;

        public UpgradeSystem()
        {

        }
        public void SaveData(int level,int currentEXP)
        {
            PlayerPrefs.SetInt("level",level);
            PlayerPrefs.SetInt("currentEXP",currentEXP);
        }
        public void LoadData()
        {
            level = PlayerPrefs.GetInt("level");
            currentEXP = PlayerPrefs.GetInt("currentEXP");
        }

    }
}

