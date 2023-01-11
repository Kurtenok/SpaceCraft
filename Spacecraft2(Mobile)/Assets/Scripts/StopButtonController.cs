using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StopButtonController : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
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
        Player.SendMessage("CancelStop");
    }
    
     public virtual void OnPointerDown(PointerEventData ped)
    {
        print("Stop");
         Player.SendMessage("Stop");
    }
}
