using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    enum Turret{Wait,Attack}
    Turret turret;
    
   SphereCollider col;
    [SerializeField] GameObject target;
   [SerializeField] float accuracy;
   [SerializeField] GameObject Bullet;
   [SerializeField] Transform[] BulletSpawner;
   [SerializeField] float speed;
   [SerializeField] float damage;
   Vector3 vector=new Vector3(270,0,0);
   Rigidbody rig;
    [SerializeField]bool IsShooting;
   //public Vector3 TurretHigh;
   float DistanceToTarget;
   SphereCollider sphereCollider;
   float radius;
   [SerializeField] string[] Enemy;
   [SerializeField] float rotSpeed;
   [SerializeField] GameObject startPosition;

   [SerializeField] float maxRightRotAgle;
   [SerializeField] float maxLeftRotAgle;
   [SerializeField] float fireRate;
   bool isCanShoot;
   
   float YStartValue;
   
    bool isStoped;
    

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
           AttackEnemy();
        }
        else if(target==null && IsShooting==true)
        {
           StopShooting();
        }
        
        
    }
    void OnTriggerEnter(Collider collider)
        {
            if(isEnemyInList(collider.tag)&&target==null)
        {
            turret=Turret.Attack;
            target=collider.gameObject;
            DistanceToTarget=Vector3.Distance(this.transform.position,target.transform.position);
            AttackEnemy();
        }

        }
    void AttackEnemy()
    {
        
        if(Vector3.Distance(this.transform.position,target.gameObject.transform.position)<=DistanceToTarget&&target!=null)
        {
            //print("Shoot");
            Vector3 direct= Vector3.RotateTowards(transform.forward,target.transform.position-transform.position,rotSpeed,0f);
            //print(direct);
             if((transform.localEulerAngles.y<maxRightRotAgle)||(transform.localEulerAngles.y>maxLeftRotAgle))
            {
            transform.rotation=Quaternion.LookRotation(direct);
            if(!IsShooting && isEnemyForward())
            {
               // print("3");
                IsShooting=true;
                InvokeRepeating("Shoot",0,fireRate);
            }
            else{}
            }
            else
            {
                Vector3 direct2= Vector3.RotateTowards(transform.forward,startPosition.transform.position-transform.position,rotSpeed,0f);
                transform.rotation=Quaternion.LookRotation(direct2);
                if(IsShooting)
                { CancelInvoke("Shoot");
                    IsShooting=false;
                }
            }
           
            foreach(Transform t in BulletSpawner)
            {
             t.localEulerAngles=Random.insideUnitSphere*accuracy*DistanceToTarget;
            }
        }
        else
        {
            StopShooting();
        }
    }
    public void StopShooting()
    {
            target=null;
            IsShooting=false;
            CancelInvoke("Shoot");
            turret=Turret.Wait;
            col.enabled=false;
            col.enabled=true;
    }
    
    void Shoot()
    {
            foreach(Transform t in BulletSpawner)
            {
            GameObject bul= Instantiate(Bullet,t.position,t.transform.rotation);
            bul.SendMessage("SetDamage",damage);
            rig = bul.GetComponent<Rigidbody>();
            rig.AddRelativeForce(Vector3.forward*speed);
            }
    }
    void PRINT()
    {
       // print("3");
    }
    bool isEnemyForward()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, DistanceToTarget+1.0f))
        {
       // print("Raycast"); 
        if(isEnemyInList(hit.collider.tag))
        {//print("Enemy above");
        return true; }
        else
        return false;}
         else
        return false;
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
    void CanShootTrue()
    {
        isCanShoot=true;
    }
    void CanShootFalse()
    {
        isCanShoot=false;
    }
}

