using UnityEngine;
using System.Collections;

/// <summary>
/// ゴール用のクラス。
/// </summary>
public class Goal : MonoBehaviour {

    private bool _goal = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnGUI()
    {
        if (_goal)
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            var style = new GUIStyle();
            style.fontSize = 20;
            style.normal.textColor = Color.cyan;

            var pos = new Rect(screenWidth * 0.05f, screenHeight * 0.10f, screenWidth * 0.95f, screenHeight * 0.30f);
            GUI.Label(pos, "Goal!!!", style);
        }
    }

    void OnCollisionEnter(Collision PlayerSphere)
	{
		if(PlayerSphere.gameObject.tag == "Player")
        {
            _goal = true;
            Time.timeScale = 0.0f;
        }
	}
}
