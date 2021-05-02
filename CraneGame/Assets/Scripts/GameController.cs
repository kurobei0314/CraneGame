//　ゲームの一連の流れを操作する
// ボタン押したときの処理、

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class GameController : MonoBehaviour
{
    public player Player;
    public Button AMButton;
    public GameObject Prize;
    public GameObject[] Prizes;
    int FallButtonFlg = 0;
    public GameObject prizePosition;
    public GameObject prizeGetPosition;

    public enum  GameState{
        MAIN,
        FALL,
        GAMEOVER
    }
    GameState currentGameState;
    int currentLoopNum;

    // Start is called before the first frame update
    void Start()
    {
        currentLoopNum = 0;
        InitializePrize();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentGameState == GameState.FALL){
        
            if(Player.GetNormalState()){

                if(currentLoopNum == GameInfo.LOOPNUM){
                    ChangecurrentGameState(GameState.GAMEOVER);
                }
                else{
                    ChangecurrentGameState(GameState.MAIN);
                }
                currentLoopNum += 1;
                FallButtonFlg = 0;
            }
        }
    }

    public void RButtonTouch(){

        if(currentGameState == GameState.MAIN){
            Player.SetDirection(1);
            AMButton.ChangeButtonState();
            AMButton.TouchChangeButtonSprite("R");
        }
    }

    public void LButtonTouch(){

        if(currentGameState == GameState.MAIN){
            Player.SetDirection(-1);
            AMButton.ChangeButtonState();
            AMButton.TouchChangeButtonSprite("L");
        }
    }

    public void UpButton(){

        if(currentGameState == GameState.MAIN){
            Player.SetDirection(0);
            AMButton.ChangeButtonState();
            AMButton.UpChangeButtonSprite();
        }
    }

    public void FButtonTouch(){

        if(currentGameState == GameState.MAIN){
            if(FallButtonFlg == 0){
                Player.ChangecurrentPlayerState(PlayerState.Type.FALL);
                AMButton.ChangeButtonState();
                AMButton.TouchChangeButtonSprite("F");
                ChangecurrentGameState(GameState.FALL);
                /*
                while(true){
                    if(player.GetNormalState()){
                        FallButtonFlg = 0;
                        if(currentLoopNum == GameInfo.LOOPNUM){
                            ChangecurrentGameState(GameState.GAMEOVER);
                        }
                        currentLoopNum += 1;
                        break;
                    }

                }
                */
            }
            FallButtonFlg += 1;
        }
    }

    void ChangecurrentGameState(GameState state){

        currentGameState = state;
    }

    void InitializePrize(){

        Prizes = new GameObject[GameInfo.PRIZENUM];
        float y = prizePosition.transform.position.y;

        for (int i=0;i<GameInfo.PRIZENUM;i++){
            
            float x = UnityEngine.Random.Range(-3.5f,3.5f);
            Prizes[i] = Instantiate(Prize, new Vector3(x,y,0.0f),Quaternion.identity) as GameObject;
        }
    }

    public void JudgePrize(){

        Debug.Log("wa-i");

        for (int i = 0; i < GameInfo.PRIZENUM; i++){

            float hPosition = Prizes[i].transform.position.y;
            float GetPositionY = prizeGetPosition.transform.position.y;

            if( GetPositionY < hPosition ){

                Prizes[i].SetActive(false);
                JudgePoint(Prizes[i].GetComponent<prize>().GetPrizeType());
            }
        }
    }

    public void JudgePoint(PrizeInfo.Type color){

        return;
    }
}
