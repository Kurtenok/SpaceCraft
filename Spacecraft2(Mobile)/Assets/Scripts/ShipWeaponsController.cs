using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponsController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string[] Enemy;
    List<TurretController> turretControllers= new List<TurretController>();
    List<RocketLauncher> rocketLaunchers= new List<RocketLauncher>();
    Coroutine chekTag;
    private void Awake() {
        for(int i=0;i<transform.childCount;i++)
        {
        //Transform trans=this.transform.Find("GEneric_turret_rotata4").Find("Sphere");
       // TurretController turretController=trans.GetComponent<TurretController>();
        //print(turretController);
        if(transform.GetChild(i).name=="GEneric_turret_rotata4")
        {
            TurretController turretController=transform.GetChild(i).Find("Sphere").GetComponent<TurretController>();
             if(!turretControllers.Contains(turretController))
            turretControllers.Add(turretController);
        }
        
       

         if(transform.GetChild(i).name=="Red")
        {
            RocketLauncher rocketLauncher=transform.GetChild(i).GetComponent<RocketLauncher>();
            if(!rocketLaunchers.Contains(rocketLauncher))
            rocketLaunchers.Add(rocketLauncher);
        }
        
       
    }

        //turretControllers.AddRange(transform.Find("GEneric_turret_rotata4").GetComponents<TurretController>());
        if(turretControllers.Count>0 && Enemy.Length>0)
        {
            foreach(TurretController turret in turretControllers)
            {
                turret.SetEnemy(Enemy);
            }
        }
       // rocketLaunchers.AddRange(this.gameObject.GetComponentsInChildren<RocketLauncher>());
        if(rocketLaunchers.Count>0&& Enemy.Length>0)
        {
            foreach(RocketLauncher launcher in rocketLaunchers)
            {
                launcher.SetEnemy(Enemy);
            }
        }
    }
   /* private void OnValidate() {
         Debug.Log("valodate worked");
        if(chekTag==null)
        {
        Debug.Log("tag check started");
        chekTag=StartCoroutine(CheckTag());
        }
    }*/
    IEnumerator CheckTag()
    {
        while(true)
        {
            Debug.Log("coroutine started");
            bool tagsIncorrect=false;
            yield return new WaitForSeconds(2.0f);
            List<string> tags=new List<string>();
            tags.AddRange(UnityEditorInternal.InternalEditorUtility.tags);
            foreach(string enemy in Enemy)
            {
                if(!tags.Contains(enemy))
                {
                    Debug.Log("Inoorect tag "+enemy);
                    tagsIncorrect=true;
                }
            }
            if(!tagsIncorrect)
            {
                Debug.Log("stop coroutine");
                StopCoroutine(chekTag);
                chekTag=null;
            }
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
