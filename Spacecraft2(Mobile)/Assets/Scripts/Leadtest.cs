using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Leadtest : MonoBehaviour
{
    // Start is called before the first frame update
   GameObject Player;
[SerializeField] GameObject SelectedTarget;
private int iterations = 3; // increase this to get a better result
[SerializeField] float ProjectileSpeed = 200;
[SerializeField] GameObject cube;
Rigidbody rigidbody;
NavMeshAgent agent;
[SerializeField] float speed=0;

void Start()
{
 rigidbody=SelectedTarget.GetComponent<Rigidbody>();
 //agent=Se
  agent=SelectedTarget.GetComponent<NavMeshAgent>();
  //speed=agent.speed;
  
}

Vector3 CalculateLead(Vector3 target, Vector3 targetSpeed ) 
{
    float dist = (Player.transform.position - target).magnitude;
    float timeToTarget = dist / ProjectileSpeed;
    Vector3 newTargetPosition = SelectedTarget.transform.position + targetSpeed * timeToTarget;
    return newTargetPosition;
}


void LateUpdate () {
    SetSpeed();
    Vector3 TargetSpeed = SelectedTarget.transform.forward * speed;//rigidbody.velocity.magnitude;
    Vector3 aimTarget = SelectedTarget.transform.position;
    for (var i = 0;i<iterations;i++)
        aimTarget = CalculateLead(aimTarget,TargetSpeed);
    //TLI_HUD.transform.position=PlayerCamera.camera.WorldToViewportPoint(aimTarget);
    cube.transform.position=aimTarget;
}
void SetTarget(GameObject target)
{
    SelectedTarget=target;
}
void SetPlayer(GameObject player)
{
    Player=player;
}
void SetSpeed()
{
    if(Vector3.Distance(Player.transform.position,SelectedTarget.transform.position) <= agent.stoppingDistance*1.5f|| !agent.hasPath)
    {
        //print("I am stopped"+ Vector3.Distance(Player.transform.position,SelectedTarget.transform.position));
        speed=0;
    }
    else
    {
   // print("Distance"+Vector3.Distance(Player.transform.position,SelectedTarget.transform.position));
    speed=agent.speed;
    }
}
}

