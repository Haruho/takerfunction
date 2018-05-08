using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float move;
    private Rigidbody2D rg;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            rg.velocity = new Vector2(-move,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rg.velocity = new Vector2(move, 0);
        }
    }
}
