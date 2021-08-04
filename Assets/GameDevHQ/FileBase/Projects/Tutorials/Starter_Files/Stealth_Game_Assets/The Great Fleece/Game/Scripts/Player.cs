using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{



    void Start()
    {
        
    }

    void Update()
    {
        //if left click
        //cast a ray from mouse pos
        //debug the floor position hit
        //create object at floor position
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                Debug.Log($"We clicked at {hit.point}");
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = hit.point;
            }
        }
    }
}
