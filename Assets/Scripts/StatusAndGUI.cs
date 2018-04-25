using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// UIを描画するクラス。
/// なんでキャンバスを使わなかったのか、謎。
/// todo: 気が向いたらキャンバスに切り替えたい。
/// </summary>
public class StatusAndGUI : MonoBehaviour
{
	public GameObject Camera;

	private CameraMove _cameraMove;
	
	private float _speed;
	
	Vector3 _setAcc;
	float   _setRadY;
	float   _setRadX;
	
	private bool _stopToggle => (Time.timeScale == 0.0f);

    private Vector3 _savePos;

	// GUI
	void OnGUI () {
		
		float screenWidth  = Screen.width;
		float screenHeight = Screen.height;

        var buttonSkin = GUI.skin.button;
        buttonSkin.fontSize = 20;

        GUI.Label(new Rect(screenWidth * 0.05f, screenHeight * 0.05f, screenWidth * 0.95f, screenHeight * 0.1f),"SPEED : " + _speed.ToString("F3"));

        //Stop
        var stopRect = new Rect(screenWidth * 0.05f, screenHeight * 0.9f, screenWidth * 0.3f, screenHeight * 0.1f);
        var stopLabel = _stopToggle ? "Move" : "Stop";

        if(GUI.Toggle(stopRect, _stopToggle, stopLabel, buttonSkin))
        {
            if (_stopToggle == false)
            {
                // 切り替わった瞬間だけ時間を止める。
                Time.timeScale = 0.0f;
            }
        }
        else
        {
            if (_stopToggle == true)
            {
                // 切り替わった瞬間だけ時間を進める。
                Time.timeScale = 1.0f;
            }
        }
		
		//ReStart
        if( GUI.Button(new Rect(screenWidth * 0.35f, screenHeight * 0.9f, screenWidth * 0.3f, screenHeight * 0.1f),"Restart", buttonSkin) ) {
            Restart();
        }
		
		//ResetButton
        if( GUI.Button(new Rect(screenWidth * 0.65f, screenHeight * 0.9f, screenWidth * 0.3f, screenHeight * 0.1f),"Reload", buttonSkin) ) {
            SceneManager.LoadScene("Main");
        }
	}

    private void Restart()
    {
        var restartPos = _savePos;
        restartPos.y += 1.5f;
        this.transform.localPosition = restartPos;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
	
	// Use this for initialization
	void Start () {
	
		_cameraMove = Camera.GetComponent<CameraMove>();
		
		_setAcc = GetAcceleration();
        _setRadY = Mathf.Atan(_setAcc.y / _setAcc.z);
		_setRadX = Mathf.Acos(_setAcc.x / _setAcc.magnitude);
		
		Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // 重力の計算をさせるため、FixedUpdateで実行させる必要がある。はず。

		_speed = this.GetComponent<Rigidbody>().velocity.magnitude;

		Physics.gravity = GetGravityVector();

        // プラットフォームがアンドロイドかチェック
        if (Application.platform == RuntimePlatform.Android)
        {
            // エスケープキー取得
            if (Input.GetKey(KeyCode.Escape))
            {
                // アプリケーション終了
                Application.Quit();
                return;
            }
        }

        if(this.transform.position.y < -10)
        {
            Restart();
        }
	}

    /// <summary>
    /// 加速度センサーのベクトルを取得
    /// 取得できない場合は下向きの重力を返す
    /// </summary>
    /// <returns></returns>
    private Vector3 GetAcceleration()
    {
        var accVector = Input.acceleration;

        if (accVector == Vector3.zero)
        {
            accVector.z = Define.GravityPower;
        }

        return accVector;
    }

    /// <summary>
    /// 加速度センサーをUnity内の重力に変換するメソッド。
    /// なぜこのクラスにいるのかは不明。
    /// todo: 気が向いたら別のクラスに移したい。
    /// todo: なんとなく、もう少し綺麗に書けそうな気がする。
    /// </summary>
    /// <returns></returns>
    private Vector3 GetGravityVector()
    {
        var accVector = GetAcceleration();

        var radY = Mathf.Atan(accVector.y / accVector.z);
        var radX = Mathf.Acos(accVector.x / accVector.magnitude);
        var radianX = Mathf.Round((radX - _setRadX) * Define.AccelerationPlay) / Define.AccelerationPlay;
        var radianY = Mathf.Round((radY - _setRadY) * Define.AccelerationPlay) / Define.AccelerationPlay;
        var psi   = _cameraMove.Psi;

        var VectorX = Mathf.Sin(radianX) * Define.GravityPower * -1f;
        var VectorZ = Mathf.Sin(radianY) * Define.GravityPower * -1f;

        var result = Vector3.zero;
        result.x = Mathf.Cos(psi * Mathf.Deg2Rad) * VectorX + Mathf.Sin(psi * Mathf.Deg2Rad) * VectorZ;
        result.z = Mathf.Cos(psi * Mathf.Deg2Rad) * VectorZ - Mathf.Sin(psi * Mathf.Deg2Rad) * VectorX;
        result.y = Mathf.Cos(radianX) * Mathf.Cos(radianY) * Define.GravityPower * -1f;

        return result;
    }

    /// <summary>
    /// 球がブロックに設置したときに、そのブロックの座標をセーブする。
    /// todo: これも別のクラスに移したい。
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        _savePos = collision.transform.position;
    }
}
