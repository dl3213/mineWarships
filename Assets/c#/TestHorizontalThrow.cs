using UnityEngine;
using System.Collections.Generic;

public class TestHorizontalThrow : MonoBehaviour {

    public GameObject testGo;
    private bool isDebug = false;
    private List<GameObject> drawGoList = new List<GameObject>();

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //半径为1的方向圆
            float randomNum = Random.Range(0f, 1f);//[0, 1]
            float x = randomNum * 2 - 1;//[-1, 1]
            float z = Mathf.Sqrt(1 - x * x);
            if (Random.Range(0f, 1f) > 0.5f)
            {
                z = -z;
            }

            isDebug = true;
            HorizontalThrow horizontalThrow = testGo.AddComponent<HorizontalThrow>();
            horizontalThrow.StartMove(new Vector2(x, z), 3f, 0f, (go) => {
                isDebug = false;
                Debug.Log("移动结束");
            });
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            testGo.transform.position = new Vector3(0f, 5f, 0f);
            for (int i = 0; i < drawGoList.Count; i++)
            {
                Destroy(drawGoList[i]);
            }
            drawGoList.Clear();
        }

        if (isDebug)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = testGo.transform.position;
            go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            drawGoList.Add(go);
        }
    }
}