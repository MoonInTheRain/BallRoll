using UnityEngine;
using System.Collections;

/// <summary>
/// ゴール用のクラス。の予定。
/// </summary>
public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision PlayerSphere)
	{
		if(PlayerSphere.gameObject.name == ""){
			
		}
	}
}
