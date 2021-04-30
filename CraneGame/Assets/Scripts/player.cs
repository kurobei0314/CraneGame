// ゲームの機械の動き


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class player : MonoBehaviour
{
    public enum  PlayerState{
        NORMAL,
        FALL,
    }

    public PlayerState currentPlayerState;
    int FallPlayerFlg=1; 

    //　移動方向の設定
    int dir = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameInfo.InitializePlayer;
        currentPlayerState = PlayerState.NORMAL; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerState == PlayerState.NORMAL){
            xMove(dir);
        }
        
        else if (currentPlayerState == PlayerState.FALL){
            yMove(1);
        }
        
    }

    public void SetDirection(int n){
        dir = n;
    }

    
    public void TouchPrize(){

        Debug.Log("wa-i");
        FallPlayerFlg -= 1;

        if (FallPlayerFlg == 0){
            StartCoroutine("yMoveAni");
        }
    }

    IEnumerator yMoveAni(){

        ChangecurrentPlayerState();
        //yield return new WaitForSeconds(5.0f);

        Debug.Log("wa--------------i");

        while(currentPlayerState == PlayerState.FALL){
            yield return new WaitForSeconds(1.0f);
        }
        Debug.Log("wwwwwwwwwwwwwwww");
        yield return new WaitForSeconds(1.0f);

        while(true){
            if(this.transform.position.y >= GameInfo.InitializePlayer.y) break;
            yMove(-1);
            yield return new WaitForSeconds(0.01f);
        }

    }

    public void ChangecurrentPlayerState(){

        currentPlayerState = 1 - currentPlayerState; 
    }
    
    void xMove(int dir){

        // 移動するとき
        if(dir != 0){
            Vector3 pos = transform.position;
            pos.x += GameInfo.MSPEED * dir;
            transform.position = pos;
        }
    }

    void yMove(int dir){

        Vector3 pos = transform.position;
        pos.y -= GameInfo.FSPEED * dir;
        transform.position = pos;
    }
    
}