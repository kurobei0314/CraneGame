using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prize : MonoBehaviour
{
    PrizeInfo.Type currentPrizeType;

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

        if      (0.0f <= random && random < 0.4f){
            ChangePrizeType(PrizeInfo.Type.RED);
        }
        else if (0.4f <= random && random < 0.8f){
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

                GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
                break;

            case PrizeInfo.Type.BLUE:

                GetComponent<SpriteRenderer>().color = new Color(1,0,0,1);
                break;

            default:

                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                break;
        }
    }

    


}