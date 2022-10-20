using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitarAnim : MonoBehaviour
{
    public float    frecuencia;
    public float    amplitud;
    public Vector3  direccion;

    Vector3 posInicial;

    void Start()
    {
        posInicial = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = posInicial + direccion * (Mathf.Sin(Time.time * frecuencia) * amplitud);
    }
}
