using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightVectorTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.right+=new Vector3(1,1,1)*Time.deltaTime;
       transform.position+=transform.right*5*Time.deltaTime;
    }
}
