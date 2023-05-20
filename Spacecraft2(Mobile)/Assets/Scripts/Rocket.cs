using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]GameObject target;
    [SerializeField] float rotSpeed;
    [SerializeField] float force;
    [SerializeField] float speed;
    [SerializeField] ParticleSystem engineParticle;
    CapsuleCollider collider;
    bool IsRocketLaunched=false;
    float damage;
     Rigidbody rigidbody;
    // Start is called before the first frame update
    void Awake() {
        collider=GetComponent<CapsuleCollider>();
        collider.enabled=false;
    }
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        Invoke("LaunchRocket",1f);
        Invoke("Destroy",10f);
       // collider=GetComponent<BoxCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRocketLaunched&& target!=null)
        {
        Vector3 direct= Vector3.RotateTowards(transform.forward,target.transform.position-transform.position,rotSpeed,0f);
        transform.rotation=Quaternion.LookRotation(direct);
         rigidbody.AddRelativeForce(Vector3.forward*speed);
        }
        else if(IsRocketLaunched && target==null)
        {Destroy(gameObject);}
    }
    void Destroy()
    {
        engineParticle.Stop();
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision col)
    {
        //if(col.gameObject.tag=="Enemy")
        if(col!=null &&  col.gameObject.TryGetComponent<HPController>(out HPController hp))
        col.gameObject.SendMessage("TakeDamage",damage);
       // print("Destoy Rocket");
        Destroy(gameObject);
        
    }
    void SetDamage(float Damage)
    {
        damage=Damage;
    }
    void SetTarget(GameObject Target)
    {
        target=Target;
    }
    void LaunchRocket()
    {
        collider.enabled=true;
        engineParticle.Play();
        IsRocketLaunched=true;
        rigidbody.velocity=Vector3.zero;
    }
}
