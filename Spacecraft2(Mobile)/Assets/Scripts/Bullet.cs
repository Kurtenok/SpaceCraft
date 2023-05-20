using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isDestoryed;
    float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy",4f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision col)
    {
//        print("11");
        if((col.gameObject.TryGetComponent<HPController>(out HPController hp)&& col.gameObject!=null))
        {
        col.gameObject.SendMessage("TakeDamage",damage);
        }
        Destroy(gameObject);
        
    }
    //void IsShieldDestroyed(bool _isDestroyed)
   // {
       // isDestoryed=_isDestroyed;
   // }
    void SetDamage(float Damage)
    {
        damage=Damage;
    }
}