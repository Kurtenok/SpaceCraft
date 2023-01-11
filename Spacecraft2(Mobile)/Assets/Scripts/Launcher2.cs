using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Launcher2 : MonoBehaviour
{
    enum Turret{Wait,Attack}
    Turret turret;
    
   SphereCollider col;
    [SerializeField] GameObject target;
   [SerializeField] GameObject Rocket;
   [SerializeField] Transform[] RocketSpawner;
   [SerializeField] float damage;
   Vector3 vector=new Vector3(270,0,0);
   Rigidbody rig;
    [SerializeField]bool IsShooting;
   //public Vector3 TurretHigh;
   float DistanceToTarget;
   SphereCollider sphereCollider;
   float radius;
   [SerializeField] string Enemy;
   [SerializeField] float rotSpeed;
   [SerializeField] GameObject startPosition;

   [SerializeField] float maxRightRotAgle;
   [SerializeField] float maxLeftRotAgle;
   [SerializeField] float fireRate;
   
   float YStartValue;
   
   //public float damage;
    bool isStoped;
    

    // Start is called before the first frame update
    void Start()
    {
       // sphereCollider=GetComponent<SphereCollider>();
        col=GetComponent<SphereCollider>();
       
       // YStartValue=transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        //float a =Mathf.PingPong(0,30);
       //print(a);
        if(turret==Turret.Attack && target!=null)
        {
            //if(!(Vector3.Angle(transform.position,target.transform.position)<90 &&Vector3.Angle(transform.position,target.transform.position)>0))
           AttackEnemy();
        }
        else if(target==null && IsShooting==true)
        {
           // isStoped=fla;
           StopShooting();
        }
        //StopShooting();*/
        
        
    }
    void OnTriggerEnter(Collider collider)
        {
            //print("1");
            if(collider.gameObject.tag==Enemy&&target==null)
        {
           // print("2");
            turret=Turret.Attack;
            target=collider.gameObject;
            DistanceToTarget=Vector3.Distance(this.transform.position,target.transform.position);
            AttackEnemy();
            //print("2");
           // while(Vector3.Distance(this.transform.position,collision.gameObject.transform.position)<=col.radius)
          // {
            //this.transform.LookAt(collision.gameObject.transform.position);
           // }
        }

        }
    void AttackEnemy()
    {
        
        if(Vector3.Distance(this.transform.position,target.gameObject.transform.position)<=DistanceToTarget&&target!=null)
        {
            print("Shoot");
            //print(Vector3.Distance(this.transform.position,target.gameObject.transform.position));
            //if(transform.rotation.eulerAngles.y<90 && transform.rotation.eulerAngles.y>0)
            //this.transform.LookAt(target.transform.position);
            Vector3 direct= Vector3.RotateTowards(transform.forward,target.transform.position-transform.position,rotSpeed,0f);
            //Vector3 direct2 =new Vector3(direct.x, Mathf.Clamp(direct.y, 0, 90),direct.z);
            //print("direct2" + direct2);
             if((transform.localEulerAngles.y<maxRightRotAgle)||(transform.localEulerAngles.y>maxLeftRotAgle))
            {
                //print(transform.eulerAngles.y);
            transform.rotation=Quaternion.LookRotation(direct);
            if(!IsShooting && isEnemyForward())
            {
                print("3");
                IsShooting=true;
                InvokeRepeating("Shoot",0,fireRate);
            }
            else{}
            }
            else //if(!IsShooting)
            {
                Vector3 direct2= Vector3.RotateTowards(transform.forward,startPosition.transform.position-transform.position,rotSpeed,0f);
                transform.rotation=Quaternion.LookRotation(direct2);
                //print("direct2" + direct2);
                if(IsShooting)
                { CancelInvoke("Shoot");
                    IsShooting=false;
                }
            }
           
            //else if(IsShooting)
           // {
                //StopShooting();
           // }
            
            
            // if((gun.eulerAngles.z<90)||(gun.eulerAngles.z>270))
           // {
           // gun.Rotate(0,0,turnAngle);
          //  }
            //transform.localEulerAngles = new Vector3(transform.rotation.eulerAngles.x, Mathf.Clamp(transform.rotation.eulerAngles.y, 0, 90), transform.rotation.eulerAngles.z);
            //Vector3 rot1=
            //Vector3 rot=new Vector3(Mathf.Clamp(transform.rotation.eulerAngles.x, -90, 90), transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
           // this.transform.Rotate(rot);
            
            //print ("Angle" + Vector3.Angle(transform.position,target.transform.position));
           /* if(!IsShooting)
            {//&&  isEnemyForward()
                //if(isEnemyForward())
               // {
                print("3");
                IsShooting=true;
                InvokeRepeating("Shoot",0,0.2f);
                //Vector3.Angle(transform.position,target.transform.position)==0 &&
              // }
               
            }
            else
            {
                //if(IsShooting)
               // StopShooting();
            }*/
        }
        else
        {
            StopShooting();
            //col.radius=0;
            //RADIUS();
        }
    }
    public void StopShooting()
    {
            //print("4");
            target=null;
            IsShooting=false;
            CancelInvoke("Shoot");
            turret=Turret.Wait;
            col.enabled=false;
            col.enabled=true;
    }
    
    void Shoot()
    {
            foreach(Transform t in RocketSpawner)
            {
            GameObject bul= Instantiate(Rocket,t.position,t.transform.rotation);
            Rigidbody rig=bul.GetComponent<Rigidbody>();
            bul.SendMessage("SetDamage",damage);
            bul.SendMessage("SetTarget",target);
            }
            //print("stop");}
    }
    void PRINT()
    {
       // print("3");
    }
    bool isEnemyForward()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, DistanceToTarget+1.0f);
        print("Raycast"); 
        print("tag "+ hit.collider.tag);
        if(hit.collider.tag==Enemy)
        {print("Enemy above");
        return true; }
        else
        return false;
        
    }
    //void RADIUS()
    //{
      //  col.enabled=true;
  //  }
}

