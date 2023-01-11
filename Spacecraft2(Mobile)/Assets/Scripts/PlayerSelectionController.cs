using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class PlayerSelectionController : MonoBehaviour
{
    public bool isSelected=false;
    [SerializeField] GameObject selectorPrefab;
    [SerializeField] Vector3 offset;
    GameObject selector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Select()
    {
        isSelected=true;
        selector=Instantiate(selectorPrefab,transform.position-offset,Quaternion.identity);
        selector.transform.parent=transform;
    }
    void DisSelect()
    {
        isSelected=false;
        Destroy(selector);
    }

}
