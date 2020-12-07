using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform target;
    int a = 0;

    public AnimationCurve curve;
    public float dx;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // target = this.transform.Find("Cube").transform;
        offset = transform.position - target.position;//计算相对距离
    }

    void OnGUI()
    {
        // if(GUILayout.RepeatButton("lerp"))
        // {
        //     dx += Time.deltaTime/10;// /持续时间
        //     // Vector3.LerpUnclamped
        //     this.transform.position = Vector3.LerpUnclamped(transform.position,target.position,curve.Evaluate(dx));
        // }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;

        // if()

        //正上方45度10m处
        // Vector3 target = new Vector3(0,10,0);
        // print(transform.position);
        // Debug.DrawLine(transform.position ,transform.position+Quaternion.Euler(45,0,0) * target , Color.red);

        // Vector3.Angle();
        // Vector3.OrthoNormalize();
        // Vector3.Project
        // Vector3.ProjectOnPlane
        //Vector3.反射

        //匀速移动:pos = V3.MoveTowards(startP,endP 1)


        //pos = V3.lerp()//渐渐到,但是不到

        //变速
        // AnimationCurve

        

    //    transform.RotateAround(target.position, transform.up, 1f); 

    }
}
