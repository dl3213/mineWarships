using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyTest : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform t1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = Quaternion.AngleAxis(10,transform.right);
    }

    void OnGUI()
    {
        // if(GUILayout.RepeatButton("RotateToward"))
        // {
        //     Quaternion dir = Quaternion.Euler(0,90,0);
        //     this.transform.rotation = 
        //         Quaternion.Lerp(transform.rotation,dir,0.1F);
        //     //角度接近
        //     if(Quaternion.Angle(this.transform.rotation,dir) < 1)
        //     {
        //         this.transform.rotation = dir;
        //     }
        // }

        if(GUILayout.RepeatButton("x轴注视旋转"))
        {
            // transform.forward = t1.position - transform.position;//立即
            
            //缓慢
            Quaternion dir = Quaternion.FromToRotation(Vector3.forward,t1.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation,dir,0.2F);
        }
    }
}
