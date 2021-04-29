// ゲームの機械の動き


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public enum  PlayerState{
        NORMAL,
        FALL
    }

    public PlayerState currentPlayerState;
    int FallPlayerFlg=0; 

    //　移動方向の設定
    int dir = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerState = PlayerState.NORMAL; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerState == PlayerState.NORMAL){
            Move(dir);
        }
        else if (currentPlayerState == PlayerState.FALL){
            Fall();
        }
    }

    public void SetDirection(int n){
        dir = n;
    }

    void OnCollisionEnter2D(Collision2D col){

        Debug.Log(FallPlayerFlg);

        if (FallPlayerFlg == 0){
            Debug.Log("wa-iwa-i-wa-i");
            ChangecurrentPlayerState();
            Debug.Log("currentPlayerState: ");
            Debug.Log(currentPlayerState);
        }
        FallPlayerFlg += 1;
    }

    public void ChangecurrentPlayerState(){

        currentPlayerState = 1 - currentPlayerState; 
    }
    
    void Move(int dir){

        // 移動するとき
        if(dir != 0){
            Vector3 pos = transform.position;
            pos.x += GameInfo.MSPEED * dir;
            transform.position = pos;
        }
    }

    void Fall(){

        Vector3 pos = transform.position;
        pos.y -= GameInfo.FSPEED;
        transform.position = pos;
    }
    
}