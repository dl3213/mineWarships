using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform target;
    int a = 0;

    // Start is called before the first frame update
    void Start()
    {
        // target = this.transform.Find("Cube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //正上方45度10m处
        Vector3 target = new Vector3(0,10,0);
        print(transform.position);
        Debug.DrawLine(transform.position ,transform.position+Quaternion.Euler(45,0,0) * target , Color.red);

    //    transform.RotateAround(target.position, transform.up, 1f); 

    //     if(Input.GetKey(KeyCode.A))
    //     {
            
    //     }
    //     if(Input.GetKey(KeyCode.D))
    //     {
    //     }
    }
}
