using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretController : MonoBehaviour
{
   enum Turret{Wait,Attack}
    Turret turret;
    
   SphereCollider col;
   [SerializeField]List<GameObject> enemiesInRange;
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
   [SerializeField] float maxRightRotAgle;
   [SerializeField] float maxLeftRotAgle;
   [SerializeField] float fireRate;
   //[SerializeField] GameObject sight;
   [SerializeField] GameObject VirtualSphere;
   GameObject sphere;
   //GameObject aim;
   //bool isСontrolManual=false;
  // GameObject player;
   float YStartValue;
   
    bool isStoped;
   
    private void Awake() {
       // player=GameObject.FindGameObjectWithTag("Player");
       sphere=Instantiate(VirtualSphere,transform.position,Quaternion.identity);
       sphere.transform.parent=this.gameObject.transform.parent;
      // aim=Instantiate(sight,transform.position,transform.rotation);
      // sight.transform.parent=gameObject.transform;
       col=GetComponent<SphereCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //sphere.transform.position=transform.position;
        if(turret==Turret.Attack && target!=null)
        {
           AttackEnemy();
        }
        else if(target==null && IsShooting==true)
        {
            ClearEnemiesInRange();
           if(enemiesInRange.Count>0)
            {
                target=FindClosestEnemy();
            }
            else
           StopShooting();
        }
        
        
    }
    void OnTriggerEnter(Collider collider)
        {
            if(isEnemyInList(collider.tag))
        {
            if(!(enemiesInRange.Contains(collider.gameObject)))
            {
            enemiesInRange.Add(collider.gameObject);
            print("added to list");
            }
            turret=Turret.Attack;
            if(target==null){
            target=collider.gameObject;}
            //DistanceToTarget=Vector3.Distance(this.transform.position,target.transform.position);
          //  AttackEnemy();
            
        }
        }
     void OnTriggerExit(Collider other)
    {
        if(target==other.gameObject)
        target=null;
        enemiesInRange.Remove(other.gameObject);
    }
    void AttackEnemy()
    {
            Vector3 direct= Vector3.RotateTowards(transform.forward,target.transform.position-transform.position,rotSpeed,0f);
            sphere.transform.rotation=Quaternion.LookRotation(direct);
           // print(direct.y);
             //Debug.DrawRay(transform.position, direct, Color.red);
          //  print(transform.localEulerAngles.y-direct.y);
             if((sphere.transform.localEulerAngles.y<maxRightRotAgle)||(sphere.transform.localEulerAngles.y>maxLeftRotAgle))
            {
            //print(sphere.transform.localEulerAngles.y);
            transform.rotation=Quaternion.LookRotation(direct);
           // print(direct.y);
            if(!IsShooting)
            {
                IsShooting=true;
                InvokeRepeating("Shoot",0,fireRate);
            }
            }
            else
            {
                StopShooting();
               /* Vector3 direct2= Vector3.RotateTowards(transform.forward,startPosition.transform.position-transform.position,rotSpeed,0f);
                transform.rotation=Quaternion.LookRotation(direct2);
                if(IsShooting)
                { CancelInvoke("Shoot");
                    IsShooting=false;
                }*/
            }
            foreach(Transform t in BulletSpawner)
            {
             t.localEulerAngles=Random.insideUnitSphere*accuracy*DistanceToTarget;
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
    /*void SetIsСontrolManualTrue()
    {
        target=sight;
        isСontrolManual=true;
    }
    void SetIsСontrolManualFalse()
    {
        isСontrolManual=false;
        target=FindClosestEnemy();
    }*/
    GameObject FindClosestEnemy()
    {
        GameObject closestEnemy=enemiesInRange[0];
        float min=Vector3.Distance(this.transform.position,enemiesInRange[0].transform.position);
        foreach(GameObject en in enemiesInRange)
        {
            if(Vector3.Distance(this.transform.position,en.transform.position)<min)
            {
                closestEnemy=en;
            }
        }
        return closestEnemy;
    }
    void ClearEnemiesInRange()
    {
        foreach(GameObject gameObject in enemiesInRange)
        {
            if(gameObject==null)
            {
                enemiesInRange.Remove(gameObject);
            }
        }
    }
}

