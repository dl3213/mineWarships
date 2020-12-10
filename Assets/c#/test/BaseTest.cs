using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTest : MonoBehaviour
{
    // Start is called before the first frame update

    //允许子类重写 start
    protected virtual void Start()
    {
        print("base");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
