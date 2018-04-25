using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public class MakeMaze : MonoBehaviour {
	
	public GameObject Cube1;

    private Vector3 nextCoursePos = Vector3.zero;

    private int Straight = 1;
	private int Direction = 0;

    public List<Vector3> MazePosList;
    
	// Use this for initialization
	public void Start () {
		MakeMazeMethod();
	}
	
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
