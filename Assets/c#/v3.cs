using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class v3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public AnimationCurve curve;

    // Update is called once per frame
    void Update()
    {
        Vector3 v1 = new Vector3(112,20,540);
        // Vector3.Angle()//两向量夹角
        // Vector3.ClampMagnitude()//限制长度
        // v1.normalized;//返回v1的单位向量
        // v1.Normalize();//将v1设置为该自身单位向量
        // Vector3.OrthoNormalize(a,b,c);//返回与a垂直的bc
        // Vector3.Project(a,b);//返回a在b的投影
        // Vector3.ProjectOnPlane()
        // Vector3.Reflect()//反射
        // transform.position = Vector3.MoveTowards(this,endP,.1F);//
        // transform.position = Vector3.Lerp();//渐渐接近但不=
        // x += Time.deltaTime/5;
        // Vector3.LerpUnclamped(a,b,curve.Evaluate(x))//可超过终点

        // Quaternion.Euler()
        // transform.rotation.eulerAngles;
        //旋转时pos不动
        // transform.rotation = Quaternion.AngleAxis(30,Vector3.up);
        // transform.rotation = Quaternion.LookRotation(Vector);//z
        // transform.LookAt();//同上

        // transform.rotation =Quaternion.Lerp(transform.rotation,targerRotation,.1F*time.detaltime);
        // if(Quaternion.Angle()<1)transform.rotation = dir;

        // transform.rotation = Quaternion.RotateTowards()
        // 

        //x轴注视旋转 tf
        // transform.right = tf.pos-transform.position;//立即
        //x正方向 -> 注视目标位置的方向
        // dir = Quaternion.FromToRotation(Vector3.right,tf.pos - transform.position)
        // transform.rotation = dir//lerp

        //unity 贝塞尔
        
        //参数方程
    }
}
