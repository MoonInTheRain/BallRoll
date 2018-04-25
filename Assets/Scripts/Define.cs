using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 定数を定義するクラス
/// </summary>
public static class Define
{
    /// <summary> 迷路に使うブロックの数 </summary>
    public static int   MazeLength       = 50;
    /// <summary> 迷路の直線の最小ブロック </summary>
    public static int   MinStraight      = 1;
    /// <summary> 重力加速度 </summary>
    public static float GravityPower     = 5f;
    /// <summary> 加速度センサーの遊び </summary>
    public static int   AccelerationPlay = 20;
    /// <summary> 迷路で曲がる確率 </summary>
    public static float RateOfChangeDirection = 0.5f;
}
