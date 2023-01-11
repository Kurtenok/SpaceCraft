using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPosTest : MonoBehaviour
{
    // Start is called before the first frame update
    Camera _camera;
    void Start()
    {
        _camera=GameObject.FindObjectOfType<Camera>();
      Vector3 position = _camera.WorldToScreenPoint(transform.position);
      print(position);
      transform.position=position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
