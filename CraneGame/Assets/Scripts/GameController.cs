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
    public GameObject player;
    public Button AMButton;
    public GameObject Prize;
    public GameObject[] Prizes;
    int FallButtonFlg = 0;
    public GameObject prizePosition;
    public GameObject prizeGetPosition;
    [SerializeField] private Text GameTimerText;
    private float GameTimes = GameInfo.TIME;

    public Text scoreText;

    public GameObject Canvas;
    GameObject MainCanvas,ResultCanvas;
    public GameObject Rcranegame;

    public static GameController instance; 

    public enum  GameState{
        MAIN,
        FALL,
        GAMEOVER
    }
    GameState currentGameState;
    int currentLoopNum;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLoopNum = 0;
        ScoreManager.instance.score = 0;
        InitializePrize();

        MainCanvas = Canvas.transform.Find("Main").gameObject;
        ResultCanvas = Canvas.transform.Find("Result").gameObject;
        
        MainCanvas.SetActive(true);
        ResultCanvas.SetActive(false);

        for (int i=0; i < GameInfo.PRIZENUM; i++){
                Prizes[i].SetActive(true);
        }

        Observable.Interval(TimeSpan.FromSeconds(0.4f)).Subscribe(_ =>
        {
            if(currentGameState == GameState.GAMEOVER){
                Vector3 scale = Rcranegame.transform.localScale;
                scale.x *= -1;
                Rcranegame.transform.localScale = scale;  
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

        if(currentGameState == GameState.MAIN ){
               GameTimeCounter();
        }
        else if(currentGameState == GameState.FALL){
        
            if(Player.GetNormalState()){
                
                currentLoopNum += 1;

                if(currentLoopNum == GameInfo.LOOPNUM){
                    ChangecurrentGameState(GameState.GAMEOVER);
                    player.SetActive(false);
                    MainCanvas.SetActive(false);
                    ResultCanvas.SetActive(true);
                    scoreText.text = ScoreManager.instance.score + "てん";

                    for (int i=0; i < GameInfo.PRIZENUM; i++){
                        Prizes[i].SetActive(false);
                    }

                }
                else{
                    ChangecurrentGameState(GameState.MAIN);
                }
                FallButtonFlg = 0;
                GameTimes = GameInfo.TIME;
            }
        }

        else if(currentGameState == GameState.GAMEOVER){

        }
    }

    void GameTimeCounter(){

        GameTimes = TimeCounter(GameTimes);
        GameTimerText.text = ((int)GameTimes).ToString();

        if((int)GameTimes <= 0) FallAction();
    }

    float TimeCounter(float time){

        time -= Time.deltaTime;
        return time;
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
        FallAction();
    }

    void FallAction(){

        if(currentGameState == GameState.MAIN){
            if(FallButtonFlg == 0){
                Player.ChangecurrentPlayerState(PlayerState.Type.FALL);
                AMButton.ChangeButtonState();
                AMButton.TouchChangeButtonSprite("F");
                ChangecurrentGameState(GameState.FALL);
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

        for (int i = 0; i < GameInfo.PRIZENUM; i++){

            float hPosition = Prizes[i].transform.position.y;
            float GetPositionY = prizeGetPosition.transform.position.y;

            if( GetPositionY < hPosition ){

                Prizes[i].SetActive(false);
                int PrizeScore = Prizes[i].GetComponent<prize>().GetPrizeScore();
                ScoreManager.instance.score += PrizeScore + (int)(GameTimes);  
            }
        }
    }
}
