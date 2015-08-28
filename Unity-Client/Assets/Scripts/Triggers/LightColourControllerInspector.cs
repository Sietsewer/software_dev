using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LightColourController))]
[CanEditMultipleObjects]
public class LightColourControllerInspector : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		LightColourController myScript = (LightColourController)target;

		if(myScript.automaticGreen)
			EditorGUILayout.FloatField ("Green Time", myScript.greenTime);

		//Only run when game is running.
		if (Application.isPlaying) {
			if (GUILayout.Button ("Go")) {
				myScript.go = true;
			}
			if (GUILayout.Button ("Stop")) {
				myScript.go = false;
			}
		}
	}
}