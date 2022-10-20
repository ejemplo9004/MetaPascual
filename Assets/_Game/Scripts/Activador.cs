using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activador : MonoBehaviour
{
    public Activacion[] activaciones;
    public Activacion[] desactivaciones;
    public Animator animator;
    void Start()
    {

    }
    [ContextMenu("Activar")]
    public void Activar()
    {
        for (int i = 0; i < activaciones.Length; i++)
        {
            StartCoroutine(activaciones[i].Activando());
        }
    }
    [ContextMenu("Desactivar")]
    public void Desactivar()
    {
        for (int i = 0; i < activaciones.Length; i++)
        {
            StartCoroutine(desactivaciones[i].Activando());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Activar();
        }
    }

    public void ActivarBool(string b)
    {
        animator.SetBool(b, true);
    }

    public void DesactivarBool(string b)
    {
        animator.SetBool(b, false);
    }
}

[System.Serializable]
public class Activacion
{
    public float delay = 0;
    public UnityEvent evento;


    public IEnumerator Activando()
    {
        yield return new WaitForSeconds(delay);
        evento.Invoke();
    }
}