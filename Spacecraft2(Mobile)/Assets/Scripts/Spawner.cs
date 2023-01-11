
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] Dictionary<GameObject,int> enemies;

    //[SerializeField] Dictionary<int,Dictionary<GameObject,int>> wawes;
    //[SerializeField] List<GameObject> spawners;
    //[Serializable]
    [SerializeField] int spawnRadius;

//[Serializable]
// public struct Enemies
// {
//     private GameObject enemy;
//     private int quantity;
//     public int GetQuantity()
//     {return quantity;}
//      public GameObject GetEnemy()
//     {return enemy;}
// }
// [SerializeField] private Enemies[] enemies;
    
[Serializable]
    public struct Enemies
    {
        public GameObject enemy;
        public int quantity;
        public int timeBeforeSpawn;
         public int GetQuantity()
    {return quantity;}
      public GameObject GetEnemy()
    {return enemy;}
    public int GeTime()
    {return timeBeforeSpawn;}
    }


    [SerializeField] private Enemies[] enemies;
     GameObject[] spawnersArr;
    private void Awake() {
        spawnersArr=(GameObject.FindGameObjectsWithTag("Spawner"));  
    }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    int QuantityOfAllEnemies()
    {
        int quant=0;
        for(int i=0;i<enemies.Length;++i)
        {
            quant+=enemies[i].GetQuantity();
        }
        return quant;
    }
   int[] QuantityOfSpawnEnemies()
    {
        int[] mas=new int[enemies.Length];
         for(int i=0;i<enemies.Length;++i)
        {
            mas[i]=enemies[i].GetQuantity();
        }
        return mas;
    }
    void Update()
    {
        
    }
    IEnumerator SpawnEnemies()
    {
        for(int i=0;i<enemies.Length;++i)
        {
            yield return new WaitForSeconds(enemies[i].GeTime());
            int iter=0;
            int quantity=enemies[i].GetQuantity();
            while(quantity>0)
           {
               int rand=UnityEngine.Random.Range(0,quantity+1);
               for(int j=0;j<rand;++j)
               {
            
                    Vector3 randompoint=spawnersArr[UnityEngine.Random.Range(0,spawnersArr.Length)].transform.position+UnityEngine.Random.insideUnitSphere*spawnRadius;
                    NavMeshHit hit;
                    if(NavMesh.SamplePosition(randompoint,out hit,10f,NavMesh.AllAreas))
                    {
                    GameObject enemy=Instantiate(enemies[i].GetEnemy(),hit.position,Quaternion.identity);
                    }
                    else
                    j--;
               }
               quantity-=rand;
               iter++;
               if(iter>2000)
               {print("Too much iterations!!!!!");
               break;
               }
           }
        }
        

    }
    
}
