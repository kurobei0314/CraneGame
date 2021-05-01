// ゲームの機械の動き


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;


public class player : MonoBehaviour
{
    public enum  PlayerState{
        NORMAL,
        FALL,
    }

    public PlayerState currentPlayerState;
    int FallPlayerFlg=1;
    // UseKindArmは1オリジン 
    int UseKindArm=1;

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

        FallPlayerFlg -= 1;

        if (FallPlayerFlg == 0){
            StartCoroutine("yMoveAni");
        }
    }

    IEnumerator yMoveAni(){

        ChangecurrentPlayerState();
        //yield return new WaitForSeconds(5.0f);

        GameObject Arm = transform.GetChild(UseKindArm).gameObject;
        GameObject RArm = Arm.transform.Find("Rarm").gameObject;
        GameObject LArm = Arm.transform.Find("Larm").gameObject;

        RectTransform RrectTran = RArm.GetComponent<RectTransform>();
        RectTransform LrectTran = LArm.GetComponent<RectTransform>();

        Vector3 RInitialAngle = RArm.transform.localEulerAngles;
        Vector3 LInitialAngle = LArm.transform.localEulerAngles; 
        
        RrectTran.DORotate(
            new Vector3(0.0f,0.0f,220.0f),
            1.0f
        );
        
        LrectTran.DORotate(
            new Vector3(0.0f,0.0f,-40.0f),
            1.0f
        );

        yield return new WaitForSeconds(1.0f);

        while(currentPlayerState == PlayerState.FALL){
            yield return new WaitForSeconds(1.0f);
        }
       
        yield return new WaitForSeconds(1.0f);

        while(true){
            if(this.transform.position.y >= GameInfo.InitializePlayer.y) break;
            yMove(-1);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1.0f);

        RrectTran.DORotate(
            new Vector3(0.0f,0.0f,RInitialAngle.z),
            1.0f
        );
        
        LrectTran.DORotate(
            new Vector3(0.0f,0.0f,LInitialAngle.z),
            1.0f
        );

        yield return new WaitForSeconds(1.0f);

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