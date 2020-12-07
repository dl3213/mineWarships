using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F18 :  MonoBehaviour
{
    public Transform p1,bornp;//跑道终点,初始点

    public int nowState = -1;//状态

    public AnimationCurve curve4speed;
    public float durTime = 3;//跑道持续时间
    public float maxRotation = 30;//旋转最大角度

    public float moveSpeed = 0F;
    public float AddSpeed = 0.2F;//速度增量

    public float normalSpeed = 0.5F;

    // public float speedMag;
    public float speedOfSound;//风速 m/s
    [Range(0,1.8F)]
    public float Ma = 0F;//马赫
    public float MaMax = 1.8F;

    // Start is called before the first frame update
    void Start()
    {
        speedOfSound = (340/10)/4;//考虑到模型大小未统一,进行风速倍速处理
        print("speedOfSound => " + speedOfSound);
        // moveSpeed = speedOfSound * Ma;
        // moveSpeed = 
        //初始化位置
        transform.position = bornp.position;
        // transform.rotation =
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1*Time.deltaTime*10));
        ctrl();
        
    }

    void ctrl()
    {
        // if(moveSpeed<0.2F)
        //     moveSpeed += AddSpeed*Time.deltaTime;
        // if(Mathf.Abs(moveSpeed-1F)< 0.0001F)nowState = 3;

        switch (nowState)
        {
            case -1://初始出生
            {   
                print("开始......");
                if(Input.GetKey(KeyCode.W))nowState=0;
            };break; 
            case 0://跑道阶段
            {
                
                print(Ma+"  <==跑道中... => " + curve4speed.Evaluate(Ma));
                Ma += Time.deltaTime/durTime;
                // moveSpeed = curve.Evaluate(x);
                // if(moveSpeed > takeOffSpeed)moveSpeed = takeOffSpeed;
                transform.position = Vector3.Lerp(bornp.position,p1.position,
                                                curve4speed.Evaluate(Ma));
                Vector3 p1Dir = p1.position - transform.position;
                if(p1Dir.magnitude < 1)
                {
                    print("跑道完毕 => " + Ma);
                    // callTeammates();
                    nowState = 1;
                    callTeammates();
                    // Invoke("callTeammates", 1f);
                }
            };break;
            case 1://升空及滞空
            {
                print("升空及滞空=> " + Ma);
                
                transform.Translate( Ma * speedOfSound * Vector3.forward,Space.Self);
                // transform.Rotate(0,0,0);
                // transform.rotation = Quaternion.Lerp(transform.rotation,
                //                         Quaternion.Euler(transform.rotation.eulerAngles.x,
                //                                 transform.rotation.eulerAngles.y,0),0.3F);;
                if(transform.position.y<1000)
                    transform.Translate(Vector3.up,Space.Self);
                if(Input.GetKey(KeyCode.W))
                {
                    if(Ma < MaMax)
                        Ma += Ma * Time.deltaTime;
                }
                if(Input.GetKey(KeyCode.A))
                {
                    transform.Rotate(0,-maxRotation*Time.deltaTime,0);//1*Time.deltaTime*5);//maxRotation*Time.deltaTime);
                    // transform.Rotate(transform.forward);
                    // Quaternion qdir = Quaternion.AngleAxis(maxRotation,Vector3.forward);
                    // transform.rotation = Quaternion.Lerp(transform.rotation,qdir,0.01F); 
                }
                if(Input.GetKey(KeyCode.D))
                {
                    transform.Rotate(0,maxRotation*Time.deltaTime,0);//-1*Time.deltaTime*5);//-maxRotation*Time.deltaTime);
                    // transform.Rotate(-transform.forward);
                    // Quaternion qdir = Quaternion.AngleAxis(-maxRotation,Vector3.forward);
                    // transform.rotation = Quaternion.Lerp(transform.rotation,qdir,0.01F); 
                }
                if(Input.GetKey(KeyCode.S))
                {
                    if(Ma>0.2F)
                    Ma -= Ma * Time.deltaTime;
                }
            };break;
            case 2://正常制空
            {
                // transform.Translate( Vector3.forward,Space.Self);
                
            };break;
            case 3://满速
            {
                // print("引擎满载... ==> " + moveSpeed);
                // moveSpeed = Mathf.Lerp(moveSpeed,normalSpeed,0.1F);
                // nowState = 1;
            };break;
            default:
            {
                print("nullState");
            }break; 
        }

        // if(nowState == 0)//正常飞行
        // {
        //     transform.Translate( Vector3.forward,Space.Self);
        //     if(transform.position.y<3000)
        //         transform.Translate(Vector3.up,Space.Self);
        // }

    }

    void callTeammates()
    {
        print("===========callTeammates");
    }
}
