using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Transform rotateObj;
public Transform aroundObj;
public float rotSpeed=0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rotateObj.RotateAround(aroundObj.position, new Vector3(0,1,0),rotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
