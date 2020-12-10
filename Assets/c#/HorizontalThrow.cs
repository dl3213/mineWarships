using System;
using UnityEngine;

public class HorizontalThrow : MonoBehaviour {

    private readonly float gravity = -9.8f;     //重力加速度
    private Vector2 horizontalDir;              //水平方向
    private float horizontalSpeed;              //水平速度
    private Vector3 startPos;                   //开始位置
    private float endY;                         //结束高度(地面高度)
    private float timer;                        //运动消耗时间
    private Action<GameObject> finishCallBack;  //落地后的回调
    private bool canMove = false;               //能否运动

    void Update ()
    {
        if (!canMove)
        {
            return;
        }

        //移动过程
        timer = timer + Time.deltaTime;

        float xOffset = horizontalSpeed * horizontalDir.x * timer;
        float zOffset = horizontalSpeed * horizontalDir.y * timer;
        float yOffset = 0.5f * gravity * timer * timer;

        Vector3 endPos = startPos + new Vector3(xOffset, yOffset, zOffset);
        if (endPos.y < endY)
        {
            endPos.y = endY;
            canMove = false;
        }
        transform.position = endPos;

        //移动结束
        if (!canMove)
        {
            finishCallBack(gameObject);
            Destroy(this);
        }
    }

    public void StartMove(Vector2 horizontalDir, float horizontalSpeed, float endY, Action<GameObject> finishCallBack)
    {
        this.horizontalDir = horizontalDir;
        this.horizontalSpeed = horizontalSpeed;
        startPos = transform.position;
        this.endY = endY;
        timer = 0;
        this.finishCallBack = finishCallBack;
        canMove = true;
    }
}