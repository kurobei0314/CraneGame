using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo{

    // １回のゲームの制限時間
    public static readonly float TIME = 60.0f;

    // playerの動くスピード
    public static readonly float MSPEED = 0.05f;

    // playerの上下に動くスピード
    public static readonly float FSPEED = 0.05f;

    // playerの初期位置
    public static readonly Vector3 InitializePlayer = new Vector3 (-3.64f,4.41f,0.0f);

}

public static class PrizeInfo{
    public enum Type{
        RED,
        YELLOW,
        BLUE
    }


}