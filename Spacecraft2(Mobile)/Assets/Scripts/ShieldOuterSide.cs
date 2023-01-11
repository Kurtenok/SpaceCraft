using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem hitParticle;
    List<GameObject> objectsToPass;

    void Start()
    {
        //ship=this.transform.parent.gameObject;
    }

    // Update is called once per frame
    /*private void OnCollisionEnter(Collision other) {
        print("Entered");
        if(!objectsToPass.Contains(other.gameObject))
        {
            if(hitParticle)
            {var clone=Instantiate(hitParticle,other.transform.position,Quaternion.identity);}
            print("Deleted by Shield");
            Destroy(other.gameObject);
        }
    }*/
    void OnCollisionEnter(Collision col)
	{
		print("Entered");
	}
    void Update()
    {
        
    }
    void AddToList(GameObject gameObject)
    {
        objectsToPass.Add(gameObject);
    }

}
