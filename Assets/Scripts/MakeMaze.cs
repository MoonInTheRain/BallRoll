using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// 迷路を作るクラス
/// </summary>
public class MakeMaze : MonoBehaviour {
	
	public GameObject Cube1;

    private Vector3 nextCoursePos = Vector3.zero;

    /// <summary>
    /// 現在伸ばしている直線の長さ
    /// </summary>
    private int Straight = 1;

    /// <summary>
    /// 迷路を伸ばす方向。
    /// ０：奥、＋１：右、－1：左
    /// </summary>
	private int Direction = 0;

    /// <summary>
    /// 迷路のポジションを保存しているリスト。
    /// 現状特に使用していない。
    /// </summary>
    public List<Vector3> MazePosList;
    
	// Use this for initialization
	public void Start () {
		MakeMazeMethod();
	}
	
    /// <summary>
    /// 迷路作成本体
    /// </summary>
	private void MakeMazeMethod () {

        MazePosList = new List<Vector3>();

        for (int length = 1; length <= Define.MazeLength; length++)
		{
            DecideDirection();
            SetPos();
            MazePosList.Add(nextCoursePos);
            Instantiate(Cube1, nextCoursePos, Quaternion.identity);
		}
	}

    /// <summary>
    /// 曲がるかどうかを決定
    /// </summary>
    private void DecideDirection()
    {
        if (Straight <= Define.MinStraight)
        {
            Straight++;
            return;
        }

        if (Random.value < Define.RateOfChangeDirection)
        {
            Direction = (Direction != 0) ? 0 :
                        (Random.value < 0.5) ? 1 : -1;
            Straight = 0;
        }
    }

    /// <summary>
    /// 次に設置するポジションを決定
    /// </summary>
    private void SetPos()
    {
        switch (Direction)
        {
            case 0:
                nextCoursePos.z++;
                break;
            case -1:
                nextCoursePos.x--;
                break;
            case 1:
                nextCoursePos.x++;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
