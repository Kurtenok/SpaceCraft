using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotSpeed;
    private WaitForSeconds stopTick= new WaitForSeconds(0.05f);
    
    [SerializeField] int stoppingTicks=10;
    Coroutine stop;
    Coroutine acceleration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        //Vector3 move=Vector3.zero;
       // move.x=joystick.Horizontal*moveSpeed;

       //rigidbody.velocity=new Vector3(joystick.Horizontal*moveSpeed,rigidbody.velocity.y,joystick.Vertical*moveSpeed);
        Vector3 velocity=new Vector3(joystick.Horizontal*moveSpeed,rigidbody.velocity.y,joystick.Vertical*moveSpeed);
        rigidbody.AddForce(transform.forward*((Mathf.Abs(joystick.Horizontal)+Mathf.Abs(joystick.Vertical))*moveSpeed));
        if(joystick.Horizontal!=0 || joystick.Vertical!=0)
        {
            if(stop!=null)
            {
                rigidbody.angularVelocity=Vector3.zero;
                StopCoroutine(stop);
            }
            Vector3 direct= Vector3.RotateTowards(transform.forward,velocity,rotSpeed,0f);
            transform.rotation=Quaternion.LookRotation(direct);
            
        }
    }
    public void Stop()
    {
        //rigidbody.velocity=Vector3.zero;
        stop =StartCoroutine(stopping());
    }
    public IEnumerator stopping()
    {
       // Vector3 angular=((rigidbody.angularVelocity)/stoppingTicks);
        rigidbody.angularVelocity=Vector3.zero;
        Vector3 speed=-((rigidbody.velocity)/stoppingTicks);
        while(rigidbody.velocity!=Vector3.zero)
        {
            rigidbody.velocity+=speed;
            //rigidbody.angularVelocity+=angular;
            //rigidbody.velocity-=stoppingSpeed;
           // print(rigidbody.velocity);
            yield return stopTick;
        }
        
    }
    public void CancelStop()
    {
        //rigidbody.velocity=Vector3.zero;
        StopCoroutine(stop);
    }   
     public IEnumerator accelerating()
    {
        rigidbody.AddRelativeForce(Vector3.forward*moveSpeed);
        print("accelerating");
        yield return stopTick;
    }
    public void CancelAccelerating()
    {
        StopCoroutine(acceleration);
    }
    public void Accelerating()
    {
        acceleration=StartCoroutine(accelerating());
    }
}
