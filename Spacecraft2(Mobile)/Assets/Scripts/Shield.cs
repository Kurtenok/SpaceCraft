using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOuterSide : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] GameObject iiner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter(Collision col)
	{
		print("Entered");
	}
}
