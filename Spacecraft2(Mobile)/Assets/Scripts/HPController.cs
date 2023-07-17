using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;


public class HPController:MonoBehaviour {
	[SerializeField] float MaxShield;
	[SerializeField] float CurrentShield;

	[SerializeField] float Hull;
	[SerializeField] GameObject deadBody;
	[SerializeField] ParticleSystem[] HullHitParticle;
	[SerializeField] ParticleSystem[] ShipFireParticle;
	[SerializeField] ParticleSystem ShieldHitParticle;

	Vector3 bulletPosition;
	 private WaitForSeconds regTick= new WaitForSeconds(0.1f);
    Coroutine regen;
	bool isDestoryed=false;
	bool isShipBurning=false;
	public Quaternion rotate;
	 public Slider shieldBar;
	  public Slider HealthBar;
    private Camera camera_;
	Rigidbody thisRigidbody;
	float maxHull;
	[HideInInspector]
    public UnityEvent OnDie;
	//ShieldBar bar;
	
		void Awake()
	{
		 camera_=Camera.main;
		CurrentShield=MaxShield;
		shieldBar.maxValue=MaxShield;
        shieldBar.value=MaxShield;
		HealthBar.maxValue=Hull;
		HealthBar.value=Hull;
		thisRigidbody=GetComponent<Rigidbody>();
		maxHull=Hull;
		//bar.GetComponent<ShieldBar>();
		//bar.SetBar(CurrentShield);
	}
	/*void LateUpdate()
    {
        shieldBar.transform.LookAt(new Vector3(transform.position.x,camera_.transform.position.y,camera_.transform.position.z));
        shieldBar.transform.Rotate(0,180,0);
    }*/
	void Start (){
		

	}
	public void TakeDamage(float damage)
	{
		/*if((CurrentShield+Hull)>damage)
		{
            if(CurrentShield>0 && CurrentShield> damage)
            {
            CurrentShield-=damage;
            shieldBar.value =CurrentShield;
            }
            else if (CurrentShield>0 && CurrentShield<= damage)
            {
            float dmg= damage-CurrentShield;
            CurrentShield=0;
            isDestoryed=true;
            shieldBar.value =CurrentShield;
            Hull-=dmg;
            }
            else if(Hull>0 && Hull>damage)
            {
            Hull-=damage;
            }
            
            if(regen!=null)
            {
            StopCoroutine(regen);
            }
            print("pre");
            regen=StartCoroutine(RegenShield());
        }
		else
		{
        print("Ship Destroyed");
		DestroyShip();
		}
        */
		if(CurrentShield+Hull>damage)
		{
		StartShieldRegen();
		if(CurrentShield>0 && CurrentShield> damage)
		{
		CurrentShield-=damage;
		shieldBar.value =CurrentShield;
		}
		else if (CurrentShield>0 && CurrentShield<= damage)
		{
			float dmg= damage-CurrentShield;
			CurrentShield=0;
			shieldBar.value =CurrentShield;
			Hull-=dmg;
			HealthBar.value=Hull;
			//DestroyForceField();
		}
		else if(Hull>0 && Hull>damage)
		{
			Hull-=damage;
			HealthBar.value=Hull;
		}
		if(Hull<maxHull/3&& !isShipBurning)
		{
			isShipBurning=true;
			BurnShip();
		}
		
		}
		else
		{
		//gameObject.transform.position=run;
		//Invoke("DestroyShip",0.1f);
		//StopShooting();
		if(deadBody)
		{
		GameObject gameObject= Instantiate(deadBody,transform.position,transform.rotation);
		gameObject.SendMessage("GetBullet",bulletPosition);
		}
		DestroyShip();
		
		}
	}
	void DestroyShip()
	{
		Destroy(gameObject);
		OnDie.Invoke();
		foreach(ParticleSystem p in ShipFireParticle)
		{
			Destroy(p);
		}
	}

	void Update (){
	}
	
	void StartShieldRegen()
	{
		if(regen!=null)
		StopCoroutine(regen);
		regen=StartCoroutine(RegenShield());
	}
	
	
	void OnCollisionEnter(Collision col)
	{
		if((col.gameObject.tag!="Bullet") && (col.gameObject.tag!="Rocket"))
		TakeDamage((VelocityToDamage(col.rigidbody)+VelocityToDamage(thisRigidbody))*10);
		if(CurrentShield<=0)
		{	
			ParticleSystem clone;
			foreach(ParticleSystem p in HullHitParticle) 
			{
			Quaternion rot = col.transform.rotation;	
			rot.y-=180;
			clone=Instantiate(p,col.transform.position,rot);
			}
			/*var clone1=Instantiate(HullHitParticle[0],col.transform.position,col.transform.rotation);
			var clone2=Instantiate(HullHitParticle[1],col.transform.position,col.transform.rotation);*/
		}
		else
		{
			if(deadBody)
			{
				//print("SendMessage" +col.gameObject.transform.position);
				bulletPosition=col.gameObject.transform.position;
			//deadBody.SendMessage("GetBullet",bulletPosition);
			}
			Quaternion rot = col.transform.rotation;	
			rot.y-=180;
			var clone=Instantiate(ShieldHitParticle,col.transform.position,rot);
		}
	}
	
	private IEnumerator RegenShield()
    {
        //print("corutina started");
        yield return new WaitForSeconds(5);
       // isDestoryed=false;
      // print("regen started");
        while (CurrentShield<MaxShield)
        {
            CurrentShield += MaxShield/100;
          	shieldBar.value =CurrentShield;
            yield return regTick;
        }
    }
	float VelocityToDamage(Rigidbody rigidbody)
	{
		float damage=Mathf.Sqrt(Mathf.Pow(Mathf.Abs(rigidbody.velocity.x),2)+(Mathf.Pow(Mathf.Abs(rigidbody.velocity.z),2)));
		//print("taran" + damage);
		return damage;
	}
	void BurnShip()
	{
		foreach(ParticleSystem p in ShipFireParticle)
		{
			p.Play();
		}
	}

}
