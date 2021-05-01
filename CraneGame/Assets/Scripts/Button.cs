using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class Button : MonoBehaviour
{


    public enum  ButtonState{
        ON,
        OFF
    }

    ButtonState currentButtonState;

    private float angularFrequency = 5f;
    static readonly float DeltaTime = 0.0333f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject RButton = transform.Find("Right").gameObject;
        GameObject LButton = transform.Find("Left").gameObject;
        GameObject FButton = transform.Find("Fall").gameObject;

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
    }

    public void ChangeButtonState(){
        currentButtonState = 1 - currentButtonState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
