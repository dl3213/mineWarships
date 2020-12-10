using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1 : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 s;

    void Start()
    {
        s = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(0,0,1)*transform.position.y*Mathf.Sqrt(2);
        Vector3 fin = transform.position+Quaternion.Euler(45,0,0) * target;
        Debug.DrawLine(s , fin, Color.red);
        transform.position = Vector3.Lerp(transform.position ,fin, Time.deltaTime);


    }
}
