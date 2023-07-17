using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTest : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void Awake() {
        
    }
    void Start()
    {
        Rigidbody rd=GetComponent<Rigidbody>();
        rd.AddForce(transform.forward*10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
