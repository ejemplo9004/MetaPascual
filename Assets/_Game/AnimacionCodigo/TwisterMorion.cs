using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwisterMorion : MonoBehaviour
{
    public AnimationCurve curvaAnimacion;
    public AnimationCurve curvaAnimacionY;
    public bool activo = false;
    public float velocidad;

    float t = 0;
    
    void Start()
    {
        Actualizar();
    }

    void Update()
    {
		if (activo)
		{
            Actualizar();
		}
    }

    public void Actualizar()
	{
        transform.localScale = (Vector3.right + Vector3.forward) * curvaAnimacion.Evaluate(t) + Vector3.up*curvaAnimacionY.Evaluate(t);
        if (t >= 1)
        {
            activo = false;
        }
        t += Time.deltaTime * (velocidad / 10f);
        if (t > 1)
        {
            t = 1;
        }
    }


    [ContextMenu("Desactivar")]
    public void Desactivar()
    {
        StartCoroutine(Desactivando());
    }
    IEnumerator Desactivando()
    {
        for (int i = 0; i <= 20; i++)
        {
            yield return new WaitForSeconds(1f / 20f);
            t = (20f - i) / 20f;
            Actualizar();
        }
    }
    [ContextMenu("Activar")]
    public void Activar()
	{
        t = 0;
        activo = true;
	}
}
