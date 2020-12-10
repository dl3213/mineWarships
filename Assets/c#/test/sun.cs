using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : BaseTest
{
    // Start is called before the first frame update
    // void Start()
    // {
    //     print("sun");
    // }

    protected override void Start()
    {
        base.Start();

        //sun sdo
        print("sun");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void load()
    {
        //通过代码读取资源
        GameObject go = Resources.Load<GameObject>("目录/资源名称");

        //创建资源
        // Instantiate(go);

        
    }
}
