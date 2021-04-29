// ゲームの機械の動き


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int d){


        Debug.Log("wwwwwwwwwwww");
        Vector3 pos = transform.position;
        pos.x += GameInfo.MSPEED * d;
        transform.position = pos;

    }
}
