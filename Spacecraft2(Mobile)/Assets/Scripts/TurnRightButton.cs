using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnRightButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    GameObject thruster;
    GameObject player;
    Rigidbody rigidbody;
    Coroutine acceleration;
    private WaitForSeconds stopTick= new WaitForSeconds(0.05f);
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindWithTag("Player");
        thruster=player.transform.Find("Thruster").gameObject;
        rigidbody=thruster.GetComponent<Rigidbody>();
        if(thruster==null)
        {
            print("please add thruster to player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public virtual void OnPointerUp(PointerEventData ped)
    {
        StopCoroutine(acceleration);
        print("CancelAccelerating");
    }
     public virtual void OnPointerDown(PointerEventData ped)
    {
       acceleration=StartCoroutine(accelerating());
    }
    private IEnumerator accelerating()
    {
        rigidbody.AddRelativeForce(Vector3.right*speed);
        print("accelerating");
        yield return stopTick;
    }
}
