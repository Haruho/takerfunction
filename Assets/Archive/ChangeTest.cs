using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTest : MonoBehaviour {
    public static string state;
    private void OnMouseDrag()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);
    }
}
