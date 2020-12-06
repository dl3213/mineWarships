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
    public float moveSpeed = 0F;
    public float AddSpeed = 0.2F;

    public float speedOfSound = 340F;
    public float ma = 0.95F;

    public float rotationSpeed = 0.2F;

    float maxSpeed;
    float flyHigh;

    public float zMaxRotation = 30;

    public float actHigh = 15200F;

    public int flyingState = -1;//-1 0 1
    public int higherTime = 2;
    public float higherH = 500F;
    public float highterAngle = 45F;

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
        attack();
        showArea(Camera.main);
    }
    void showArea(Camera c1)
    {
        
    }

    void attack()
    {
        Transform header = this.transform.Find("head").transform;

    }

    void flyCtrl()
    {
        // if(flyingState == 0 && transform.position.y < actHigh)
        // {
        //     transform.position += transform.forward * speedOfSound * ma;
        //     transform.position += transform.up;
        // }
        if(flyingState >= 0)
        {
            // float to= Mathf.Lerp(0,speedOfSound * ma,0.5F);
            // transform.Translate( 0, 0, to * Time.deltaTime);
            transform.Translate( moveSpeed* maxSpeed*Vector3.forward,Space.Self);
            if(transform.position.y<3000)
            transform.Translate(flyHigh*Vector3.up,Space.Self);
            // print(transform.rotation.eulerAngles.z);
            // if(transform.rotation.eulerAngles.z != 0)
                // transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,0), 0.05F));
        }
        // if(flyingState == -1)
        // {
        //     moveSpeed -= AddSpeed;
        // }

        if(Input.GetKey(KeyCode.W))
        {
            if(moveSpeed < 1F)
            moveSpeed += AddSpeed * Time.deltaTime;
            flyingState = 0;
            

        }
        if(Input.GetKey(KeyCode.S))
        {
            // flyingState = -1;
            if(moveSpeed>0.2F)
            moveSpeed -= AddSpeed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-zMaxRotation*Time.deltaTime,0);
            // transform.Rotate(0,0,10);
            // if(transform.rotation.eulerAngles.z<=0)transform.Rotate(0,0,zMaxRotation*Time.deltaTime*rotationSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,zMaxRotation*Time.deltaTime,0);
            // transform.Rotate(0,0,-10);
            // transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,-30), 0.05F)*Time.deltaTime);
            // if(transform.rotation.eulerAngles.z>=0)transform.Rotate(0,0,-zMaxRotation*Time.deltaTime*rotationSpeed);
        }
    }

    void cameraMove()
    {
        // print(this.name);
        // print(transform.Find("Camera").position);
        // Camera.main.transform.position -= new Vector3(0,0,0);
    }
}
