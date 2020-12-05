using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://baike.baidu.com/item/B-2%E8%BD%B0%E7%82%B8%E6%9C%BA/3148017?fromtitle=B2&fromid=1750556&fr=aladdin
//4 B2-Boomer only
public class boomer : MonoBehaviour
{
    // Start is called before the first frame update
    //Vector3 runWayV;
    //public Transform s1,s2;

    [Range(0,1)]
    public float moveSpeed = 1F;
    public float AddSpeed = 0.2F;

    public float speedOfSound = 340F;
    public float ma = 0.95F;

    public float rotationSpeed = 15F;

    float maxSpeed;
    float flyHigh;

    public float actHigh = 15200F;

    public int flyingState = 0;//-:-1 0:0 +:1

    void Start()
    {
        //runWayV = s1.position - s2.position;
        //this.transform.forward = s1.position - transform.position;
        // print(transform.forward);
        maxSpeed = speedOfSound * ma* 0.01F;
        flyHigh = actHigh * 0.001F;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
        // transform.Translate( 0, 0, moveSpeed * Time.deltaTime);
        flyCtrl();
        cameraMove();
    }

    void flyCtrl()
    {
        // if(flyingState == 0 && transform.position.y < actHigh)
        // {
        //     transform.position += transform.forward * speedOfSound * ma;
        //     transform.position += transform.up;
        // }
        if(flyingState == 1)
        {
            // float to= Mathf.Lerp(0,speedOfSound * ma,0.5F);
            // transform.Translate( 0, 0, to * Time.deltaTime);
            transform.Translate( moveSpeed* maxSpeed*Vector3.forward,Space.Self);
            transform.Translate(flyHigh*Vector3.up,Space.Self);
            
        }
        // if(flyingState == -1)
        // {
        //     moveSpeed -= AddSpeed;
        // }

        if(Input.GetKey(KeyCode.W))
        {
            flyingState = 1;
            if(moveSpeed < 1F)
            moveSpeed += AddSpeed;

        }
        if(Input.GetKey(KeyCode.S))
        {
            // flyingState = -1;
            if(moveSpeed>0F)
            moveSpeed -= AddSpeed;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-rotationSpeed*Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
        }
    }

    void cameraMove()
    {
        // print(this.name);
        // print(transform.Find("Camera").position);
        // Camera.main.transform.position -= new Vector3(0,0,0);
    }
}
