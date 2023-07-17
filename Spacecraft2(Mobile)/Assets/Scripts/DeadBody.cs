using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : MonoBehaviour
{
    [SerializeField] GameObject[] bodyparts;
    [SerializeField]Vector3 bullet;
    GameObject camera;
    // Start is called before the first frame update
    private void Awake() 
    {
        camera=GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Start()
    {
        foreach(GameObject bodypart in bodyparts)
        {
           // Rigidbody rb;
          //  rb=bodypart.GetComponent<Rigidbody>();
         //   rb.AddForce(transform.forward*Random.Range(300,500));
         Vector3 vector=bullet+Random.insideUnitSphere*10;
           bodypart.transform.GetComponent<Rigidbody>().AddForce(vector * Random.Range(10,20));
        }
       Invoke("Destroy",2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetBullet(Vector3 bullet_)
    {
        bullet=bullet_;
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
}
