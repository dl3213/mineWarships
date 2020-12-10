using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    // Transform nextCamera;
    // public float movaSpeed = 0.02F;
    public Transform target;

    public Transform nCamera;

    // public bool isFollow = false;

    // Vector3 offDir;

    public Transform targetLooAt;

    public float mouseSpeed = 3F;

    bool freeCrtl = false;

    // public AnimationCurve curve;
    // public float dx = 0;

    // Vector3 offset;

    void Start()
    {   
        print("game start ......");

        //初始朝向


        // Camera.main.gameObject.SetActive(false);
        Cursor.visible = false;
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,60,.5F);



        // Cursor.lockState=CursorLockMode.Confined;
        // target = GameObject.Find("mainWarship").transform;
        // targetLooAt = target.transform.Find("b2_Stealth_Bomber").transform;
        // print(GameObject.Find("playerGO").transform.Find("pCamera").name);
        // nextCamera =  GameObject.Find("player").transform.Find("pCamera").transform;//target.Find("b2_Stealth_Bomber").transform.Find("boomerCamera").transform;//target.Find("cvwaitCamera/Stealth_Bomber/boomerCamera").transform;
        //                                         // .gameObject.SetActive(true);
        // // print(GameObject.Find("UIObject").transform.Find("ui").name);
        GameObject.Find("UIObject").transform.Find("ui").gameObject.SetActive(true);

        Camera.main.transform.forward = nCamera.forward;
        Camera.main.transform.rotation = nCamera.rotation;

        // offset = Camera.main.transform.position-target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,60,2F*Time.deltaTime);
        // float nowFV = Camera.main.fieldOfView;
        // if(Mathf.Abs(60-nowFV)<0.5F)
        // {
        //     Camera.main.fieldOfView=60;
        // }

        // Camera.main.transform.position = Vector3.Lerp(transform.position,nCamera.position,.5F);
        // Camera.main.transform.rotation = Quaternion.Lerp(transform.rotation,nCamera.rotation,.5F);
        
        // Vector3 cDir = transform.position - nCamera.position;
        // if(cDir.magnitude<0.1F && !isFollow)
        // {
        //     print("camera ready ......");
        //     Camera.main.transform.position = nCamera.position;
        //     Camera.main.transform.rotation = nCamera.rotation;
            
        //     isFollow = true;
        //     offDir = transform.position - target.position;
        // }

        // offDir = transform.position - target.position;

        // if(isFollow){
        //     print("camera following ......");
        //     // Vector3 offDir = transform.position - target.position;
        //     transform.position = offDir + target.position;
        //     // transform.rotation = 
        //     // transform.Rotate(0,-15*Time.deltaTime,0);
        // }
        
        // Vector3 offset = target.position-transform.position;
        // Camera.main.transform.position = target.position + offset;
        cameraMove();
        // Camera.main.transform.LookAt(target);

        
    }

    void cameraMove()
    {
        // Camera.main.tpransform.position += new Vector3(1,0,0);
        Vector3 mCp = Camera.main.transform.position;
        Vector3 nCp = nCamera.position;
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
            Camera.main.transform.forward = nCamera.forward * Time.deltaTime;
            // Camera.main.transform.rotation = nextCamera.rotation ;//* Time.deltaTime;
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
            // Camera.main.transform.rotation = Quaternion.LookRotation(targetLooAt.position-Camera.main.transform.position);==lookat
            Camera.main.transform.RotateAround(target.position,target.up,mouseX*mouseSpeed);
            // Camera.main.transform.rotation = Quaternion.LookRotation(targetLooAt.position-Camera.main.transform.position);
            // Quaternion dir = Quaternion.LookRotation(tp-cp);
            // Quaternion.Lerp(Camera.main.transform.rotation,dir,0.1f);

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
