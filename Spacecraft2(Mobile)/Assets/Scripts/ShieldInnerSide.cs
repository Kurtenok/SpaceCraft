using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldInnerSide : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject outerSide;
    private void Awake() {
        outerSide=transform.parent.gameObject;
    }
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        outerSide.SendMessage("AddToList",other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
