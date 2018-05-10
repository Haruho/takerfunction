﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour {
    public GameObject ac;
    // Use this for initialization
    void Start () {
        //Instantiate(a, new Vector3(0, 0, 0),Quaternion.identity);
        Archive a = GameData.archive;
        print(a.enemies.Count);
        for (int i = 0; i < a.enemies.Count; i++)
        {
            GameObject go = Instantiate(ac);
            go.name = a.enemies[i].number.ToString();
            go.transform.position = a.enemies[i].position;
            go.transform.GetComponent<SpriteRenderer>().color = a.enemies[i].color;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public Archive LoadGameData(Archive a,GameObject enemyPrefab)
    {
        return a;
    }
}