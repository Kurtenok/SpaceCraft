using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class EnemyPointer : MonoBehaviour {

    [SerializeField] HPController _enemyHealth;
     void Awake() {
       // _enemyHealth=GameObject.FindObjectOfType<HPController>();
       _enemyHealth=this.gameObject.GetComponent<HPController>();
    }
    private void Start() {
        PointerManager.Instance.AddToList(this);
        _enemyHealth.OnDie.AddListener(Destroy);
    }

    private void Destroy() {
        PointerManager.Instance.RemoveFromList(this);
    }

}
