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
    public GameObject AMButton;
    int FallButtonFlg = 0;

    private float angularFrequency = 5f;
    static readonly float DeltaTime = 0.0333f;

    public enum  GameState{
        MAIN,
        GAMEOVER
    }
    GameState currentGameState;

    public enum  ButtonState{
        ON,
        OFF
    }
    ButtonState currentButtonState;

    // Start is called before the first frame update
    void Start()
    {
        GameObject RButton = AMButton.transform.Find("Right").gameObject;
        GameObject LButton = AMButton.transform.Find("Left").gameObject;
        GameObject FButton = AMButton.transform.Find("Fall").gameObject;

        currentButtonState = ButtonState.OFF;

        float time = 0.0f;

        Observable.Interval(TimeSpan.FromSeconds(DeltaTime)).Subscribe(_ =>
        {
            var Rcolor = RButton.GetComponent<Image>().color; 
            var Lcolor = LButton.GetComponent<Image>().color;
            var Fcolor = FButton.GetComponent<Image>().color;

            if (currentButtonState == ButtonState.OFF){

                time += angularFrequency * DeltaTime;
               
               
                Rcolor.a = Mathf.Sin(time) * 0.5f + 0.5f;
                Lcolor.a = Mathf.Sin(time) * 0.5f + 0.5f;
                Fcolor.a = Mathf.Sin(time) * 0.5f + 0.5f;
                
                /*
                RButton.GetComponent<Image>().color = Rcolor; 
                LButton.GetComponent<Image>().color = Lcolor;
                FButton.GetComponent<Image>().color = Fcolor;
                */
            }
            else if (currentButtonState == ButtonState.ON){

                time = 0.0f;
                
                Rcolor.a = 1.0f;
                Lcolor.a = 1.0f;
                Fcolor.a = 1.0f;
            }

            RButton.GetComponent<Image>().color = Rcolor; 
            LButton.GetComponent<Image>().color = Lcolor;
            FButton.GetComponent<Image>().color = Fcolor;

        }).AddTo(this);

        //ボタンの動作
        //RButton.GetComponent<Button>().onClick.AddListener(RButtonTouch);
        //LButton.GetComponent<Button>().onClick.AddListener(LButtonTouch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RButtonTouch(){

        Player.SetDirection(1);
        ChangeButtonState();
    }

    public void LButtonTouch(){

        Player.SetDirection(-1);
        ChangeButtonState();
    }

    public void UpButton(){

        Player.SetDirection(0);
        ChangeButtonState();
    }

    public void FButtonTouch(){

        if(FallButtonFlg == 0){
            Player.ChangecurrentPlayerState();
            ChangeButtonState();
        }
        FallButtonFlg += 1;
    }

    void ChangeButtonState(){
        currentButtonState = 1 - currentButtonState;
    }

    

}
