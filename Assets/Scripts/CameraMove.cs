using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float Psi;
	public float Theta;

    public GameObject Player;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = Player.transform.position;

        if (1 == Input.touchCount) {
            // CameraCenter.Rotate(Vector3.forward*Input.GetTouch(0).deltaPosition.x*0.1f);
            // CameraCenter.Rotate(Vector3.right*Input.GetTouch(0).deltaPosition.y*0.1f);
            // CameraCenter.Rotate(0, 0, Input.GetTouch(0).deltaPosition.x*0.1f);
            // CameraCenter.Rotate(0, Input.GetTouch(0).deltaPosition.y*0.1f, 0);
            this.transform.Rotate(Input.GetTouch(0).deltaPosition.y*0.1f, 0, 0);
            this.transform.Rotate(0, Input.GetTouch(0).deltaPosition.x*0.1f, 0, Space.World);
			Psi   = this.transform.eulerAngles.y;
			Theta = this.transform.eulerAngles.x;
			// Camera_pos.x += Input.GetTouch(0).deltaPosition.y*0.1f;
			// Camera_pos.z += Input.GetTouch(0).deltaPosition.x*0.1f;
			// transform.eulerAngles = Camera_pos;
        }
	}
}
