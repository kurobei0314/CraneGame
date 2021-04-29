// ゲームの機械の動き


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //　移動方向の設定
    int dir = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(dir);
    }

    public void SetDirection(int n){
        dir = n;
    }

    public void Move(int dir){

        // 移動するとき
        if(dir != 0){
            Vector3 pos = transform.position;
            pos.x += GameInfo.MSPEED * dir;
            transform.position = pos;
        }
    }
}