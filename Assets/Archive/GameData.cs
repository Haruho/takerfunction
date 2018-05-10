using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour {
    public GameObject enemyPrefab;
    public static Archive archive;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //保存
    public void SaveGameData()
    {
        archive = CreateGameData();
        SceneManager.LoadScene("LoadData");
    }

    /// <summary>
    /// 创建要进行储存的数据类
    /// </summary>
    /// <returns></returns>
    public Archive CreateGameData()
    {
        Archive a = new Archive();
        a.level = 10;
        a.site = "Start";
        a.enemies = new List<Enemy>();
        //获取敌人
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemy.Length; i++)
        {
            Enemy enemyClass = new Enemy();
            enemyClass.enemies = enemy[i];
            enemyClass.color = enemy[i].GetComponent<SpriteRenderer>().color;
            enemyClass.number = i;
            enemyClass.position = enemy[i].transform.position;
            enemyClass.state = "alive";
            a.enemies.Add(enemyClass);
        }
        return a;
    }
    public void LoadGameData(Archive a)
    {
        for (int i = 0; i < a.enemies.Count; i++)
        {
            print(a.enemies[i].number);
            GameObject go = Instantiate(enemyPrefab);
            go.name = a.enemies[i].number.ToString();
            go.transform.position = a.enemies[i].position;
            go.transform.GetComponent<SpriteRenderer>().color = a.enemies[i].color;
        }
    }
}
