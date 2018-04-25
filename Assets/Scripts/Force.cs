using UnityEngine;
using System.Collections;

/// <summary>
/// デバッグ用に矢印キーで重力をかけるクラス
/// </summary>
public class Force : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.GetComponent<Rigidbody>().AddForce(0,0,1f);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.GetComponent<Rigidbody>().AddForce(0,0,-1f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.GetComponent<Rigidbody>().AddForce(1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.GetComponent<Rigidbody>().AddForce(-1f, 0, 0);
        }
    }
}
