using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    enum Turret{Wait,Attack}
    Turret turret;
    SphereCollider col;
    [SerializeField] GameObject target;
    [SerializeField] GameObject Rocket;
   [SerializeField] Transform[] RocketSpawner;
   [SerializeField] float damage;
   [SerializeField] float force;
   float DistanceToTarget;
   [SerializeField] string[] Enemy;
   [SerializeField] bool IsShooting;
   [SerializeField] GameObject Lead;
   GameObject lead;

   Rigidbody rig;
   bool isCanShoot=true;
   
    // Start is called before the first frame update
    void Start()
    {
        col=GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
         if(turret==Turret.Attack && target!=null)
        {
            //if(!(Vector3.Angle(transform.position,target.transform.position)<90 &&Vector3.Angle(transform.position,target.transform.position)>0))
           AttackEnemy();
        }
        else if(target==null && IsShooting==true)
        {
           // isStoped=fla;
           IsShooting=false;
          StopShooting();
          if (lead != null)
          Destroy(lead);
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
            if (lead != null)
             Destroy(lead);
    }
    void Shoot()
    {
           // if(isEnemyForward())
           // {
            foreach(Transform t in RocketSpawner)
            {
            GameObject bul= Instantiate(Rocket,t.position,t.transform.rotation);
            Rigidbody rig=bul.GetComponent<Rigidbody>();
            rig.AddRelativeForce(Vector3.forward*force);
            bul.SendMessage("SetDamage",damage);
            bul.SendMessage("SetTarget",lead);
            }
           // }
            //print("stop");}
    }
    void AttackEnemy()
    {
        
        if(Vector3.Distance(this.transform.position,target.gameObject.transform.position)<=DistanceToTarget&&target!=null&& isCanShoot)
        {
            
            
            if(!IsShooting)
            {
               
                IsShooting=true;
                InvokeRepeating("Shoot",0,2f);
//                print("repeat");
            }
            /*else //if(!IsShooting)
            {
                if(IsShooting)
                { CancelInvoke("Shoot");
                    IsShooting=false;
                }
            }*/
           
        }
        else
        {
            StopShooting();
            CanShootFalse();
            Invoke("CanShootTrue",1f);
        }
    }
    void OnTriggerEnter(Collider collider)
        {
            //print("1");
            if(isEnemyInList(collider.gameObject.tag)&&target==null)
        {
           // print("2");
            turret=Turret.Attack;
            target=collider.gameObject;
           // print("Inst Lead");
            lead= Instantiate(Lead,target.transform.position,transform.rotation);
            lead.SendMessage("SetTarget",target);
            
            lead.SendMessage("SetPlayer",this.gameObject);
            DistanceToTarget=Vector3.Distance(this.transform.position,target.transform.position);
            AttackEnemy();
            //print("2");
           // while(Vector3.Distance(this.transform.position,collision.gameObject.transform.position)<=col.radius)
          // {
            //this.transform.LookAt(collision.gameObject.transform.position);
           // }
        }

        }
         void CanShootTrue()
    {
        isCanShoot=true;
    }
    void CanShootFalse()
    {
        isCanShoot=false;
    }
    public string[] GetEnemy()
    {
        return Enemy;
    }
    public void SetEnemy(string[] Enemies)
    {
       Enemy=Enemies;
    }
    bool isEnemyInList(string en)
    {
        foreach (string enemy in Enemy)
        {
            if (enemy==en)
            return true;
        }
        return false;
    }
}
