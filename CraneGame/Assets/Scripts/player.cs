// ゲームの機械の動き
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;


public class player : MonoBehaviour
{
    public PlayerState.Type currentPlayerState;
    int FallPlayerFlg=1; 
    int UseKindArm=1;

    // 移動方向の設定
    int dir = 0;

    Rigidbody2D rigidbody;

    public GameController GameControll;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameInfo.InitializePlayer;
        currentPlayerState = PlayerState.Type.NORMAL; 
        rigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayerState == PlayerState.Type.NORMAL){
            xMove(dir);
        }
        
        else if (currentPlayerState == PlayerState.Type.FALL){
            yMove(1);
        }
        
    }

    public void SetDirection(int n){
        dir = n;
    }

    
    public void TouchPrize(){

        if(currentPlayerState == PlayerState.Type.FALL){

            FallPlayerFlg -= 1;
            if (FallPlayerFlg == 0){
                StartCoroutine("yMoveAni");
            }
        }
        else return;
    }

    IEnumerator yMoveAni(){

        ChangecurrentPlayerState(PlayerState.Type.ANIMATION);

        GameObject ArmG = transform.Find("arm").gameObject;
        GameObject Arm = ArmG.transform.GetChild(UseKindArm).gameObject;
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

        while(currentPlayerState == PlayerState.Type.FALL){
            yield return new WaitForSeconds(1.0f);
        }
       
        yield return new WaitForSeconds(1.0f);

        while(true){
            if(this.transform.position.y >= GameInfo.InitializePlayer.y) break;
            yMove(-1);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1.0f);

        GameControll.JudgePrize();

        RrectTran.DORotate(
            new Vector3(0.0f,0.0f,RInitialAngle.z),
            1.0f
        );
        
        LrectTran.DORotate(
            new Vector3(0.0f,0.0f,LInitialAngle.z),
            1.0f
        );

        yield return new WaitForSeconds(1.0f);

        FallPlayerFlg = 1;
        ChangecurrentPlayerState(PlayerState.Type.NORMAL);
        Debug.Log(currentPlayerState);
    }

    public void ChangecurrentPlayerState(PlayerState.Type state){

        currentPlayerState = state; 
    }
    
    public bool GetNormalState(){

        if(currentPlayerState == PlayerState.Type.NORMAL){
            return true;
        }
        else{
            return false;
        }
    }
    

    void xMove(int dir){

        // 移動するとき
        if(dir != 0){
            rigidbody.MovePosition(transform.position + new Vector3(GameInfo.MSPEED * dir, 0.0f ,0.0f));
        }
    }

    void yMove(int dir){
        rigidbody.MovePosition(transform.position - new Vector3(0.0f, GameInfo.FSPEED * dir, 0.0f));
    }
}