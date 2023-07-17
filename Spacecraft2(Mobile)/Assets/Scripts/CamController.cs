using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    [SerializeField] Vector3 cameraoffset;
    [SerializeField] float camSpeed;
    [SerializeField] float scrollSpeed;
    [SerializeField] GameObject LeaderPrefab;
    [SerializeField] float clampCamPosX;
    [SerializeField] float clampCamPosZ;
    [SerializeField] float clampMinCamPosY;
    [SerializeField] float clampMaxCamPosY;
    Vector3 leader;
    
    [SerializeField] Camera camera;
    // Start is called before the first frame update
    void Awake() 
    {
        Player=GameObject.FindGameObjectWithTag("Player");
        
    }
    void Start()
    {
        leader=Player.transform.position+cameraoffset;
        //leader=Instantiate(LeaderPrefab,Player.transform.position+cameraoffset,Quaternion.identity);
        //transform.position=Player.transform.position+cameraoffset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKey(KeyCode.W)||Input.mousePosition.y>=Screen.height-40)
        {
            leader+=new Vector3(0,0,camSpeed);
        }
        if(Input.GetKey(KeyCode.A) || Input.mousePosition.x<=40)
        {
            leader+=new Vector3(-camSpeed,0,0);
        }
        if(Input.GetKey(KeyCode.S) || Input.mousePosition.y<=40)
        {
            leader+=new Vector3(0,0,-camSpeed);
        }
        if(Input.GetKey(KeyCode.D) || Input.mousePosition.x>=Screen.width-40)
        {
            leader+=new Vector3(camSpeed,0,0);
        }
       
        //Vector3 NewCamPosition= new Vector3(Player.transform.position.x + cameraoffset.x,cameraoffset.y,Player.transform.position.z + cameraoffset.z);
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
        GameObject leader2=Instantiate(LeaderPrefab,leader,Quaternion.identity);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            float zoomDistance = scrollSpeed * Input.GetAxis("Mouse ScrollWheel");
            leader2.transform.Translate(ray.direction * zoomDistance, Space.World);
            leader=leader2.transform.position;
            Destroy(leader2);
        }
        leader.x=Mathf.Clamp(leader.x,-clampCamPosX,clampCamPosX);
        leader.z=Mathf.Clamp(leader.z,-clampCamPosZ,clampCamPosZ);
        leader.y=Mathf.Clamp(leader.y,clampMinCamPosY,clampMaxCamPosY);
       
        transform.position=Vector3.Lerp(transform.position,leader,camSpeed);
    }
}
