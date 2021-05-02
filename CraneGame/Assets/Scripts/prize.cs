using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prize : MonoBehaviour
{
    PrizeInfo.Type currentPrizeType; 
    public player Player;   
    [SerializeField] private Sprite[] PrizeSprite;

    //int FallPlayerFlg = 1;

    // Start is called before the first frame update
    void Start()
    {
        InitializePrizeType();
        InitializePrizeSize();
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

    void InitializePrizeSize(){

        float x = Random.Range(0.1f,2.0f);
        float y = Random.Range(0.1f,2.0f);

        Vector3 size = transform.localScale;
        size = new Vector3(size.x*x, size.y*y, size.z);
        transform.localScale = size;

    }

    void ChangePrizeType(PrizeInfo.Type color){

        currentPrizeType = color;

        switch(currentPrizeType){

            case PrizeInfo.Type.RED:
                GetComponent<SpriteRenderer>().sprite = PrizeSprite[0];
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                break;

            case PrizeInfo.Type.YELLOW:
                GetComponent<SpriteRenderer>().sprite = PrizeSprite[1];
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                break;

            case PrizeInfo.Type.BLUE:
                GetComponent<SpriteRenderer>().sprite = PrizeSprite[2];
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                break;

            default:
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col){

        if (col.gameObject.transform.parent.tag == "Player" || 
            col.gameObject.transform.parent.tag == "arm"    ){ 

            Player.TouchPrize();
        }
    }

    


}
