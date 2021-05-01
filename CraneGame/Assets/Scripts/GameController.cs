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
    int FallButtonFlg = 0;

    public enum  GameState{
        MAIN,
        GAMEOVER
    }
    GameState currentGameState;

    // Start is called before the first frame update
    void Start()
    {
       
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


}
