using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class PlauerMouseController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> selectedShips;
    [SerializeField] float offset;
    [SerializeField] List<GameObject> ships;
    [SerializeField] Texture selectTexture;

    Coroutine coroutine1;
    Ray ray;
    RaycastHit hit;
    Vector3 startMousePos;
    float mouseX;
    float mouseY;
    float selectedWidth;
    float selectedHeight;
    [SerializeField] bool selection=false;
    [SerializeField]Vector3 selectionStartPoint;
    [SerializeField] GameObject guide;
    Dictionary<GameObject,Coroutine> attackers;
   
    //[SerializeField]GameObject 
    void Start()
    {
         ships.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
        mouseX=Input.mousePosition.x;
        mouseY=Screen.height-Input.mousePosition.y;
        selectedWidth=startMousePos.x-mouseX;
        selectedHeight=Input.mousePosition.y-startMousePos.y;
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            ClearList();
            SelectGroupOfShips(ships);
        }
        
        
        if(Input.GetMouseButtonDown(0))
       {
            //print(mouseX+"  "+mouseY);
             selection=true;
            ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            startMousePos=Input.mousePosition;
            
            if(Physics.Raycast(ray,out hit,100))
            {
                
                selectionStartPoint=hit.point;
                
                if(hit.collider.gameObject.GetComponent<PlayerSelectionController>())
                {
                    if(!selectedShips.Contains(hit.collider.gameObject))
                    {
                        if(Input.GetKey(KeyCode.LeftShift))
                        {
                        //print("Shift worked");
                        AddShip(hit.collider.gameObject);
                        }
                        else
                        {
                          //  print("CLEAR SHIPS");
                            ClearList();
                            AddShip(hit.collider.gameObject);
                        }
                    }
                    else
                        {
                          //  print("CLEAR SHIPS");
                            ClearList();
                            AddShip(hit.collider.gameObject);
                        }
                }
               /* else
                {
                    if(!Input.GetKey(KeyCode.LeftShift))
                    {ClearList();}
                }*/
            }
            
           
        }
        
        /*void OnGUI()
        {
             float mouseX=Input.mousePosition.x;
                    float mouseY=Screen.height-Input.mousePosition.y;
                    float selectedWidth=startMousePos.x-mouseX;
                    float selectedHeight=Input.mousePosition.y-startMousePos.y;
            GUI.DrawTexture(new Rect(mouseX,mouseY,selectedWidth,selectedHeight),selectTexture);
            print("GUI");
        }*/
        if(Input.GetMouseButtonUp(0))
        {
             //print("UP");
            selection=false;
            //print("selection false" + selection);

                ray=Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray,out hit,300))
                {
                    if(IsPointsClose(selectionStartPoint,hit.point,1f))
                    {
                        /*if(hit.collider.gameObject.GetComponent<PlayerSelectionController>())
                        {
                            if(!selectedShips.Contains(hit.collider.gameObject))
                            {
                                if(Input.GetKey(KeyCode.LeftShift))
                                {
                                //print("Shift worked");
                                AddShip(hit.collider.gameObject);
                                }
                                else
                                {
                                //  print("CLEAR SHIPS");
                                    ClearList();
                                    AddShip(hit.collider.gameObject);
                                }
                            }
                            else
                                {
                                //  print("CLEAR SHIPS");
                                    ClearList();
                                    AddShip(hit.collider.gameObject);
                                }
                        }*/
                    }
                    else
                    {
                       
                        if(!Input.GetKey(KeyCode.LeftShift))
                        {
                        ClearList();
                        }
                        foreach(GameObject ship in ships)
                        {
                            float x=ship.transform.position.x;
                            float z=ship.transform.position.z;
                            if((x>selectionStartPoint.x && x<hit.point.x) || (x<selectionStartPoint.x && x>hit.point.x))
                            {
                                if((z>selectionStartPoint.z && z<hit.point.z) || (z<selectionStartPoint.z && z>hit.point.z))
                                {
                                   // print("Ship added");
                                    AddShip(ship);
                                }
                            }
                        }
                    }
                }
            
        }
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray;
            RaycastHit hit;
            ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,100))
            {
                if(hit.collider.tag=="Enemy")
                {
                  //  print("attack Enemy");
                    //AttackEnemy(hit.collider.gameObject);
                    StartCoroutine(Atack(hit.collider.gameObject,selectedShips));
                }
                else
                {
                if(selectedShips.Count>1)
                {
                    foreach(GameObject ship in selectedShips)
                    {
                        if(attackers.ContainsKey(ship))
                        {
                            Coroutine coroutine;
                            attackers.TryGetValue(ship,out coroutine);
                            StopCoroutine(coroutine);
                            attackers.Remove(ship);
                        }    
                    }
                    float i=0.5f;
                    bool locateright=true;
                    foreach (var ship in selectedShips)
                    {            
                      //         
                        NavMeshAgent agent;
                        agent=ship.GetComponent<NavMeshAgent>();
                        if(locateright)
                        {
                        agent.SetDestination(hit.point+(transform.right*offset*i));
                        locateright=false;
                        }
                        else
                        {
                        agent.SetDestination(hit.point+(-transform.right*offset*i));
                        locateright=true;
                        i++;
                        } 
                    }
                }
                else if(selectedShips.Count==1)
                {
                    NavMeshAgent agent;
                    agent=selectedShips[0].GetComponent<NavMeshAgent>();
                    agent.SetDestination(hit.point);
                }
                }
            }
           
        }
        
    }
    void AddShip(GameObject ship)
    {
        selectedShips.Add(ship);
        ship.SendMessage("Select");
    } 
    void ClearList()
    {
        foreach(GameObject ship in selectedShips)
        {
            ship.SendMessage("DisSelect");
        }
        selectedShips.Clear();
    }
    void SelectGroupOfShips(List<GameObject> localships)
    {
        foreach(GameObject ship in localships)
        {
            AddShip(ship);
        }
      
    }
    void DisSelectShip(GameObject ship)
    {
        ship.SendMessage("DisSelect");
        selectedShips.Remove(ship);
    }
    void OnGUI()
    {
        if (selection &&( selectedWidth>5|| selectedHeight>5 || selectedWidth<-5|| selectedHeight<-5))
        {
            GUI.DrawTexture(new Rect(mouseX,mouseY,selectedWidth,selectedHeight),selectTexture);
        }
    }
    bool IsPointsClose(Vector3 p1,Vector3 p2,float amplitude)
    {
        if(Mathf.Abs(Mathf.Abs(p1.x)-Mathf.Abs(p2.x))>amplitude || Mathf.Abs(Mathf.Abs(p1.z)-Mathf.Abs(p2.z))>amplitude)
        return false;
        return true;
    }
    void AttackEnemy(GameObject enemy)
    {
        foreach(GameObject player in selectedShips)
        {
            Vector3 rand=Random.insideUnitSphere*5;
            rand.y=0;
            Vector3 temp=enemy.transform.position+rand;
            NavMeshAgent agent;
            agent=player.GetComponent<NavMeshAgent>();
            agent.SetDestination(temp);
        }
    }
    IEnumerator Atack(GameObject enemy,List<GameObject> Ships)
    {
        while(enemy!=null)
        {
        foreach(GameObject player in Ships)
        {
            Vector3 rand=Random.insideUnitSphere*40;
            rand.y=0;
            Vector3 temp=enemy.transform.position+rand;
            NavMeshAgent agent;
            agent=player.GetComponent<NavMeshAgent>();
            agent.SetDestination(temp);
        }
        yield return new WaitForSeconds(1.5f);
        /*print("Coroutine attack started");
        GameObject empty=Instantiate(guide,player.transform.position,Quaternion.identity);
        empty.transform.RotateAround(enemy.transform.position,Vector3.up,25f*Time.deltaTime);
        NavMeshAgent agent;
        agent=player.GetComponent<NavMeshAgent>();
        agent.SetDestination(empty.transform.position);
        Destroy(empty);
        yield return new WaitForSeconds(0.4f);*/
        }
    }
    IEnumerator Fade()
{
    for (int i=0;i<5;++i)
    {
        print("corot worked");
        yield return null;
    }
}
}
