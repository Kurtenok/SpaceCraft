using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerShootController : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    // Start is called before the first frame update
    [SerializeField] FixedJoystick joystick;
    [SerializeField] GameObject aim;
    [SerializeField] float ranging;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> turrets;
    [SerializeField] float minAimDistance;
   // [SerializeField] int MIN;
    void Start()
    {
        aim.transform.position=player.transform.position;
        aim.transform.parent=player.transform;
    }
    void FixedUpdate()
    {
    //    print("Hozisonal "+joystick.Horizontal);
    //    print("Vertical "+joystick.Vertical);
    //    if(joystick.Vertical>0 && joystick.Horizontal>0)
    //    {aim.transform.position=new Vector3(Mathf.Clamp(joystick.Horizontal*ranging,minAimDistance,1*ranging),player.transform.position.y,Mathf.Clamp(joystick.Vertical*ranging,minAimDistance,1*ranging));}
    //    else if(joystick.Vertical>0 && joystick.Horizontal<0)
    //    {aim.transform.position=new Vector3(Mathf.Clamp(joystick.Horizontal*ranging,-minAimDistance,1*ranging),player.transform.position.y,Mathf.Clamp(joystick.Vertical*ranging,minAimDistance,1*ranging));}
    //    else if(joystick.Vertical<0 && joystick.Horizontal>0)
    //     {aim.transform.position=new Vector3(Mathf.Clamp(joystick.Horizontal*ranging,minAimDistance,1*ranging),player.transform.position.y,Mathf.Clamp(joystick.Vertical*ranging,-minAimDistance,1*ranging));}
    //     else if(joystick.Vertical<0 && joystick.Horizontal<0)
    //     {{aim.transform.position=new Vector3(Mathf.Clamp(joystick.Horizontal*ranging,-minAimDistance,1*ranging),player.transform.position.y,Mathf.Clamp(joystick.Vertical*ranging,-minAimDistance,1*ranging));}}
    Vector2 joy=new Vector2(joystick.Horizontal,joystick.Vertical);
   // print("Magnitude"+joy.magnitude);
   // print(Mathf.Sqrt((Mathf.Abs(joystick.Horizontal)*ranging)+(Mathf.Abs(joystick.Vertical)*ranging)));
        if(joy.magnitude>0.2f)
        {   //print("MOORE");
            Vector3 pos=new Vector3(player.transform.position.x+joystick.Horizontal*ranging,player.transform.position.y,player.transform.position.z+joystick.Vertical*ranging);
        aim.transform.position=pos;}
    }
     // Vector2 joyspos=new Vector2(joystick.Horizontal,joystick.Vertical);
       //Vector2 clamp=Vector2.ClampMagnitude(minAimDistance,joyspos)
    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        
        foreach(GameObject turret in turrets)
        {
        turret.SendMessage("SetIsСontrolManualFalse");
        }
    }
    
     public virtual void OnPointerDown(PointerEventData ped)
    {
        aim.transform.position=Vector3.zero;
        foreach(GameObject turret in turrets)
        {
        turret.SendMessage("SetIsСontrolManualTrue");
        }
    }
}
