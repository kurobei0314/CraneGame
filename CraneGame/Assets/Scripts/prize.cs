using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prize : MonoBehaviour
{
    PrizeInfo.Type currentPrizeType; 
    public player Player;   
    //int FallPlayerFlg = 1;

    // Start is called before the first frame update
    void Start()
    {
        InitializePrizeType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializePrizeType(){

        float random = Random.Range(0.0f,1.0f);
        Debug.Log(random);

        if      (0.0f <= random && random < 0.4f){
            ChangePrizeType(PrizeInfo.Type.RED);
        }
        else if (0.4f <= random && random < 0.8f){
            Debug.Log("wa---i");
            ChangePrizeType(PrizeInfo.Type.YELLOW);
        }
        else if (0.8f <= random && random <= 1.0f){
            ChangePrizeType(PrizeInfo.Type.BLUE);
        }
    }

    void ChangePrizeType(PrizeInfo.Type color){

        currentPrizeType = color;

        switch(currentPrizeType){

            case PrizeInfo.Type.RED:
                GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
                break;

            case PrizeInfo.Type.YELLOW:
                GetComponent<SpriteRenderer>().color = new Color(0,1,0,1);
                break;

            case PrizeInfo.Type.BLUE:
                GetComponent<SpriteRenderer>().color = new Color(0,0,1,1);
                break;

            default:
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col){

        if (col.gameObject.transform.parent.tag == "Player"){
            
            Player.TouchPrize();
        }
    }

    


}
