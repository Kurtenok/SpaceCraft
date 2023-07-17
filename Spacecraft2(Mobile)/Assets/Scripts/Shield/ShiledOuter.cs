using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiledOuter : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]ParticleSystem hitParticle;
    [SerializeField] List<GameObject> objectsToPass;
    Coroutine cleaning;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
      /*   if(other.tag=="Bullet" || other.tag=="Rocket")
        {
        print("Entered");
        if(!objectsToPass.Contains(other.gameObject))
        {
            if(hitParticle)
            {var clone=Instantiate(hitParticle,other.transform.position,Quaternion.identity);}
            print("Deleted by Shield");
            Destroy(other.gameObject);
        }
        }*/
         if(other.tag=="Bullet" || other.tag=="Rocket")
        {
            if(!objectsToPass.Contains(other.gameObject))
            {
            if(hitParticle)
            {var clone=Instantiate(hitParticle,other.transform.position,Quaternion.identity);}
            Destroy(other.gameObject);}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToList(GameObject gameObject)
    {
        /*if(cleaning!=null)
        {StopCoroutine(cleaning);
        cleaning=StartCoroutine(ClearList());}*/
        if(cleaning!=null)
		StopCoroutine(cleaning);
		cleaning=StartCoroutine(ClearList());
        objectsToPass.Add(gameObject);
    }
    IEnumerator ClearList()
    {
        yield return new WaitForSeconds(0.2f);
       // print("List cleaned");
        objectsToPass.Clear();
    }
}
