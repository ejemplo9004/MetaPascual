using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automirador : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
