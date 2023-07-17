using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpBut2 : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    // Start is called before the first frame update
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player=GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        
    }
     public virtual void OnPointerUp(PointerEventData ped)
    {
        Player.SendMessage("CancelAccelerating");
    }
    
     public virtual void OnPointerDown(PointerEventData ped)
    {
        print("Stop");
         Player.SendMessage("Accelerating");
    }
}
