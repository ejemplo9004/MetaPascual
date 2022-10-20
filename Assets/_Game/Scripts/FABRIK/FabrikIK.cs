using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabrikIK : MonoBehaviour
{
    public Transform[] huesos;
    public float[] distanciaHuesos;
    public int iteraciones;

    public Transform objetivo;
    // Start is called before the first frame update
    void Start()
    {
        distanciaHuesos = new float[huesos.Length];

        for (int i = 0; i < huesos.Length; i++)
        {
            if (i<huesos.Length-1)
            {
                distanciaHuesos[i] = (huesos[i + 1].position - huesos[i].position).magnitude;
            }
            else
            {
                distanciaHuesos[i] = 0;
            }
        }
    }

    void Update()
    {
        EjecutarIK();
    }

    private void EjecutarIK()
    {
        Vector3[] finalPosiciones = new Vector3[huesos.Length];

        for (int i = 0; i < huesos.Length; i++)
        {
            finalPosiciones[i] = huesos[i].position;
        }

        for (int i = 0; i < iteraciones; i++)
        {
            finalPosiciones = ResolverPosicionesFW(ResplverPosicionesBK(finalPosiciones));
        }

        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].position = finalPosiciones[i];

            if (i != huesos.Length-1)
            {
                if ((finalPosiciones[i + 1] - huesos[i].position).magnitude > 0.01f) huesos[i].rotation = Quaternion.LookRotation(finalPosiciones[i + 1] - huesos[i].position);
                huesos[i].Rotate(90, 0, 0);
            }
            else{

                huesos[i].rotation = Quaternion.LookRotation(objetivo.position - huesos[i].position);
                huesos[i].Rotate(90, 0, 0);
            }
        }

    }

    private Vector3[] ResolverPosicionesFW(Vector3[] pos)
    {
        Vector3[] posicionesCalculadas = new Vector3[pos.Length];

        for (int i = 0; i < pos.Length; i++)
        {
            if (i == 0)
            {
                posicionesCalculadas[i] = huesos[0].position;
            }
            else
            {
                Vector3 posPrimaActual = pos[i];
                Vector3 posBaseAnterior = posicionesCalculadas[i -1];
                Vector3 direccion = (posPrimaActual - posBaseAnterior).normalized;
                posicionesCalculadas[i] = posBaseAnterior + direccion * distanciaHuesos[i];
            }
        }

        return posicionesCalculadas;
    }

    private Vector3[] ResplverPosicionesBK(Vector3[] pos)
    {
        Vector3[] posicionesCalculadas = new Vector3[pos.Length];

        for (int i =( pos.Length-1); i >= 0; i--)
        {
            if (i==pos.Length-1)
            {
                posicionesCalculadas[i] = objetivo.position;
            }
            else
            {
                Vector3 posPrimaSiguiente = posicionesCalculadas[i + 1];
                Vector3 posBaseActual = pos[i];
                Vector3 direccion = (posBaseActual - posPrimaSiguiente).normalized;
                posicionesCalculadas[i] = posPrimaSiguiente + direccion * distanciaHuesos[i];
            }
        }

        return posicionesCalculadas;
    }


}
