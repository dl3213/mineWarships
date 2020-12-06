using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    Transform nextCamera;
    public float movaSpeed = 0.02F;
    public Transform target;

    public Transform targetLooAt;

    public float mouseSpeed = 3F;

    bool freeCrtl = false;

    void Start()
    {   
        print("game start ......");
        // Camera.main.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState=CursorLockMode.Confined;
        target = GameObject.Find("mainWarship").transform;
        targetLooAt = target.transform.Find("b2_Stealth_Bomber").transform;
        // print(target.Find("Stealth_Bomber").transform.Find("boomerCamera").name);
        nextCamera =  target.Find("b2_Stealth_Bomber").transform.Find("boomerCamera").transform;//target.Find("cvwaitCamera/Stealth_Bomber/boomerCamera").transform;
                                                // .gameObject.SetActive(true);
        // print(GameObject.Find("UIObject").transform.Find("ui").name);
        GameObject.Find("UIObject").transform.Find("ui").gameObject.SetActive(true);

        Camera.main.transform.forward = nextCamera.forward;
        Camera.main.transform.rotation = nextCamera.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove();
        // Camera.main.transform.LookAt(target);

        
    }

    void cameraMove()
    {
        // Camera.main.tpransform.position += new Vector3(1,0,0);
        Vector3 mCp = Camera.main.transform.position;
        Vector3 nCp = nextCamera.position;
        // Vector3 mCr = Camera.main.transform.rotation.eulerAngles;
        // Vector3 nCr = nextCamera.rotation.eulerAngles;
        

        // if(!isEqual(mCp,nCp))
        // {
        //     float x2 = nCp.x - mCp.x;
        //     float delX = x2 / Mathf.Abs(x2);// * movaSpeed;
        //     float y2 = nCp.y - mCp.y;
        //     float delY = y2 / Mathf.Abs(y2);// * movaSpeed;
        //     float z2 = nCp.z - mCp.z;
        //     float delZ = z2 / Mathf.Abs(z2);// * movaSpeed;
        //     Camera.main.transform.position += new Vector3(delX,delY,delZ);
        //     print(isEqual(mCp,nCp));
        //     // float rx2 = nCr.x - mCr.x;
        //     // float delrX = rx2 / Mathf.Abs(rx2);
        //     // float ry2 = nCr.y - mCr.y;
        //     // float delrY = ry2 / Mathf.Abs(ry2);
        //     // float rz2 = nCr.z - mCr.z;
        //     // float delrZ = rz2 / Mathf.Abs(rz2);
        //     // Camera.main.transform.rotation = nextCamera.rotation;
        // }
        Camera.main.transform.position = Vector3.Lerp(mCp, nCp, 0.05F);
        if(!freeCrtl)
        {
            Camera.main.transform.forward = nextCamera.forward * Time.deltaTime;
            Camera.main.transform.rotation = nextCamera.rotation ;//* Time.deltaTime;
        }
        
        // Camera.main.transform.LookAt(targetLooAt);
        Camera.main.fieldOfView = 60;
        // print("now cv");
        // System.Threading.Thread.Sleep(2000);
        //  print("now cv2");


        if(Input.GetMouseButton(1))
        {
            // print("mouse right ==> ");
            // Camera.main.transform.forward = new Vector3(0,0,0);
            // Camera.main.transform.LookAt();
            // freeCrtl = true;
            float mouseX = Input.GetAxis ("Mouse X") * mouseSpeed;
            // print("mouse right ==> " + mouseX);
            // Camera.main.transform.Rotate(new Vector3(0, mouseX, 0) ,Space.World);
            Camera.main.transform.RotateAround(targetLooAt.position,targetLooAt.up,mouseX*mouseSpeed);
        }
        if(Input.GetMouseButtonUp(1))
        {
            freeCrtl = false;
        }
        if(Input.GetMouseButtonDown(1))
        {
            freeCrtl = true;
        }


    }

    // bool isEqual(Vector3 n1, Vector3 n2)
    // {
    //     float missing = 0.1F;
    //     float dx = n2.x - n1.x;
    //     float dy = n2.y - n1.y;
    //     float dz = n2.z - n1.z;
    //     print(dx + " , " + dy + " , " + dz);
    //     if( (Mathf.Abs(dx)<missing) 
    //         && (Mathf.Abs(dy)<missing) 
    //         && (Mathf.Abs(dz)<missing) )
    //     {
    //         return true;
    //     }
    //     return false;

    // }
}
