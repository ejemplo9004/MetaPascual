using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionMatas : MonoBehaviour
{
    public MeshRenderer[] mallas;
    public float tiempoEfecto;
    public float periodo = 0.05f;
    public AnimationCurve curva;

    public List<Material> materiales;
    bool lleno;
    float estado;
    void Start()
    {
        mallas = GetComponentsInChildren<MeshRenderer>();
		for (int i = 0; i < mallas.Length; i++)
		{
			for (int j = 0; j < mallas[i].materials.Length; j++)
			{
				if (mallas[i].materials[j].HasProperty("_estado"))
				{
                    materiales.Add(mallas[i].materials[j]);
				}

			}
		}
    }
    [ContextMenu("Aparecer")]
    public void Iniciar()
	{
        estado = 0;
        StartCoroutine(Aparecer());
	}

    public IEnumerator Aparecer()
	{
        float tReal = periodo / tiempoEfecto;
		while (estado < 1)
		{
			for (int i = 0; i < materiales.Count; i++)
			{
                materiales[i].SetFloat("_estado", curva.Evaluate(estado));
			}
            estado += tReal;
            yield return new WaitForSeconds(tReal);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
