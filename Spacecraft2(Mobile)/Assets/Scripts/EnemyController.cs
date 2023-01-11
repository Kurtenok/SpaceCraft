using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player=null;
    GameObject station=null;
    NavMeshAgent agent;
    [SerializeField] float agrrange; 
    Rigidbody rigidbody;
    bool isWalking=false;
    //float stoppingDistace;
    void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
        player=GameObject.FindGameObjectWithTag("Player");
        station=GameObject.FindGameObjectWithTag("Station");
        rigidbody=GetComponent<Rigidbody>();
        //stoppingDistace=agent.stoppingDistance;
    }
    void Start()
    {
        //float newX=player.transform.position.x+Random.Range(-5,5);
            //float newZ=player.transform.position.z+Random.Range(-5,5);
           /* if(player){
            Vector3 dest= new Vector3(0,0,0)+player.transform.position;
            agent.SetDestination(dest);
            }*/
    }
    
    // Update is called once per frame
    void Update()
    {
        //print(rigidbody.velocity);
        //if(!isWalking)
        //{
        if(player!=null && Vector3.Distance(transform.position,player.transform.position)<=agrrange)
        {
        if(Vector3.Distance(transform.position,player.transform.position)<=agrrange)
        {
            isWalking=true;
            //float newX=player.transform.position.x+Random.Range(-5,5);
            //float newZ=player.transform.position.z+Random.Range(-5,5);
            Vector3 dest= player.transform.position;
            agent.SetDestination(dest);
        }
        else{}
        /*if(!agent.hasPath)
        {
            float newX=player.transform.position.x+Random.Range(-5,5);
            float newZ=player.transform.position.z+Random.Range(-5,5);
            Vector3 dest= new Vector3(newX,0,newZ)+player.transform.position;
            agent.SetDestination(dest);
        }*/
        //agent.stoppingDistance=stoppingDistace;
        //print("New Path accuried");
        //agent.SetDestination(player.transform.position);
        }
        else
        {
            isWalking=false;
            agent.stoppingDistance=15;
            //float newX=station.transform.position.x+Random.Range(-10,30);
           // float newZ=station.transform.position.z+Random.Range(-30,30);
            Vector3 dest= station.transform.position;
            agent.SetDestination(dest);
       // }
        }
    }
}
