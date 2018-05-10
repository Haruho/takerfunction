using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour {
    public float move;
    public GameObject slider;

    private Rigidbody2D rg;
    private bool isHasAbility = false;
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
        if (Input.GetKey(KeyCode.W))
        {
            TakeAbility();
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            //cancle
            slider.transform.localScale = new Vector3(0.001f, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ReleaseAbility();
        }
    }
    private void TakeAbility()
    {
        slider.transform.parent.gameObject.SetActive(true);
        //进度条的速度由能力脚本来指定  关联属性
        if (slider.transform.localScale.x <= 1)
        {
            slider.transform.localScale += new Vector3(0.1f, 0, 0);
        }
        else
        {
            slider.transform.parent.gameObject.SetActive(false);
            isHasAbility = true;
        }
    }
    private void ReleaseAbility()
    {
        if (isHasAbility)
        {
            print("Release!");
        }
    }
}
