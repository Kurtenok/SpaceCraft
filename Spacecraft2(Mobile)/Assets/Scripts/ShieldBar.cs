using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    private Camera camera_;
    public static ShieldBar intance;
    

    void Awake()
    {
        camera_=Camera.main;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x,camera_.transform.position.y,camera_.transform.position.z));
        transform.Rotate(0,180,0);
       
    }
    /*private IEnumerator RegenShield()
    {
        yield return new WaitForSeconds(5);
        while (CurrentShield<MaxShield)
        {
            CurrentShield += MaxShield/100;
            //shieldBar.value =CurrentShield;
            yield return regTick;
        }
    }*/
   public void SetBar(float CurShield)
    {
       // shieldBar.value=CurShield;
    }
}
