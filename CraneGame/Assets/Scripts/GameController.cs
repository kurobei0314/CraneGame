//　ゲームの一連の流れを操作する
// ボタン押したときの処理、

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public player Player;
    public GameObject AMButton;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject RButton = AMButton.transform.Find("Right").gameObject;
        //GameObject LButton = AMButton.transform.Find("Left").gameObject;
    
        //ボタンの動作
        //RButton.GetComponent<Button>().onClick.AddListener(RButtonTouch);
        //LButton.GetComponent<Button>().onClick.AddListener(LButtonTouch);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum  GameState{
        MAIN,
        GAMEOVER
    }

    public void RButtonTouch(){

        Player.SetDirection(1);
    }

    public void LButtonTouch(){

        Player.SetDirection(-1);
    }

    public void UpButton(){

        Player.SetDirection(0);
    }

    public void FButtonTouch(){

        Player.ChangecurrentPlayerState();
    }

}
