using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]GameObject target;
    void Start()
    {
       // RotateObject()
    }
    // rotateY;
    // Update is called once per frame
   public Transform target;

    // prints "close" if the z-axis of this transform looks
    // almost towards the target

    void Update()
    {
       
       this.transform.RotateAround(target.transform.position,Vector3.up,25f*Time.deltaTime);

        
       
    
    }
   
}
