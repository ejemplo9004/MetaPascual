using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TwisterMorion))]
public class AnimacionEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Activar"))
		{
			((TwisterMorion)target).Activar();
		}
	}
}
