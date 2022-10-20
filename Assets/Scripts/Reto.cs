using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reto : MonoBehaviour
{
    public Vector3 posicionInicial;
    Quaternion rotInicial;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        rotInicial = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.5f)
        {
            transform.position = posicionInicial;
            transform.rotation = rotInicial;
            rb.velocity = Vector3.zero;
        }
    }
}
