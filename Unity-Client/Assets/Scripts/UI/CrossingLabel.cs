using UnityEngine;
using System.Collections;

/// <summary>
/// Label for pedestrian and bike crossing. Contains an icon representing the state of the light, and two buttons to control it.
/// </summary>
public class CrossingLabel: MonoBehaviour {
	
	public float maxDist = 200.0f;
	public float minDist = 10.0f;
	
	public Texture Red;
	public Texture Green;

	// Array of lights controlled by this label. Only the colour of the first in the array will be shown.
	public LightColourController[] lights;
	private Camera camera;
	
	// Use this for initialization
	void Start () {
		//lights = transform.parent.gameObject.GetComponent<LightColourController> ();
		camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
	}

	void OnGUI ()
	{
		//Sets the label texture to the correct label.
		Texture texture = null;
		switch(lights[0].lightColour){
		case LightColourController.Colours.Green:
			texture = Green;
			break;
		case LightColourController.Colours.Red:
			texture = Red;
			break;
		}

		//Grabs the screen position of the gameObject, and dot product to see if object is roughly ahead of the camera.
		//Prevents icons behind camera from drawing.
		Vector3 screenPos = camera.WorldToScreenPoint(transform.position);
		Vector3 heading = gameObject.transform.position - camera.transform.position;
		if(Vector3.Dot(camera.transform.forward, heading) > 0 && GlobalFlags.showLabels){
			Color guiColor = Color.white;
			float dist = Vector3.Distance(gameObject.transform.position, camera.transform.position);
			guiColor.a = (dist > maxDist)||(dist < minDist) ? 0.0f : (1.0f-dist/maxDist)*0.9f;
			GUI.color = guiColor;
			GUI.DrawTexture(new Rect(screenPos.x - (texture.width/2), Screen.height - screenPos.y+44, (float)texture.width, (float)texture.height),texture);
			//Buttons for toggling lights.
			if (GUI.Button (new Rect (screenPos.x - (texture.width/2)-2, Screen.height - screenPos.y+22, 20, 20), "G"))
				setLights(true);
			if (GUI.Button (new Rect (screenPos.x - (texture.width/2)-2, Screen.height - screenPos.y, 20, 20), "S"))
				setLights(false);
		}
	}

	//Used to set all lights controlled by this label.
	private void setLights(bool setTo){
		foreach (LightColourController light in lights){
			light.go = setTo;
		}
	}
}
