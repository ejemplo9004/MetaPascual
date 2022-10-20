using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadHeredador : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = target.rotation;
    }
}
