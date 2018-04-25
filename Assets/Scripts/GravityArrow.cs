using UnityEngine;
using System.Collections;

public class GravityArrow : MonoBehaviour {

	Vector3 tmp;
	public float tmp_val = 0.5f * Mathf.Rad2Deg;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tmp.x = Physics.gravity.x * tmp_val;
		tmp.y = Physics.gravity.y * tmp_val;
		tmp.z = Physics.gravity.z * tmp_val;
		transform.eulerAngles = tmp;
	}
}
