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

    public enum  GameState{
        MAIN,
        GAMEOVER
    }
    GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {

        InitializePrize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RButtonTouch(){

        Player.SetDirection(1);
        AMButton.ChangeButtonState();
        AMButton.TouchChangeButtonSprite("R");
    }

    public void LButtonTouch(){

        Player.SetDirection(-1);
        AMButton.ChangeButtonState();
        AMButton.TouchChangeButtonSprite("L");
    }

    public void UpButton(){

        Player.SetDirection(0);
        AMButton.ChangeButtonState();
        AMButton.UpChangeButtonSprite();
    }

    public void FButtonTouch(){

        if(FallButtonFlg == 0){
            Player.ChangecurrentPlayerState();
            AMButton.ChangeButtonState();
            AMButton.TouchChangeButtonSprite("F");
        }
        FallButtonFlg += 1;
    }

    void InitializePrize(){

        Prizes = new GameObject[GameInfo.INITIALPRIZENUM];
        float y = prizePosition.transform.position.y;

        for (int i=0;i<GameInfo.INITIALPRIZENUM;i++){
            
            float x = UnityEngine.Random.Range(-3.5f,3.5f);
            Prizes[i] = Instantiate(Prize, new Vector3(x,y,0.0f),Quaternion.identity) as GameObject;
        }


    }


}
