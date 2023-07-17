using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldInner : MonoBehaviour
{
    [SerializeField] GameObject outerSide;
    private void Awake() {
        outerSide=transform.parent.gameObject;
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Bullet" || other.tag=="Rocket")
        {
       // print("Gameoj"+other.gameObject);
        outerSide.SendMessage("AddToList",other.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
