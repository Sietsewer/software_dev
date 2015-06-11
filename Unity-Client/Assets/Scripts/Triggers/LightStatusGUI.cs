using UnityEngine;
using System.Collections;

public class LightStatusGUI : MonoBehaviour {

	public float maxDist = 200.0f;
	public float minDist = 10.0f;

	public Texture Red;
	public Texture Orange;
	public Texture Green;
	private LampColourManager[] allLights;
	public LampColourManager[] selectedLights;
	public bool showSelected = false;
	public bool showFreecam = true;

	// Use this for initialization
	void Start () {
		allLights = GameObject.FindObjectsOfType(typeof(LampColourManager)) as LampColourManager[];
	}

	void OnGUI ()
	{
		if(showSelected){
			foreach(LampColourManager light in selectedLights){
				Texture texture = null;
				Vector3 screenPos = GetComponent<Camera>().WorldToScreenPoint(light.gameObject.transform.position+new Vector3(0.0f, 5.0f, 0.0f));
				switch(light.currentColour){
				case LampColourManager.Colours.Groen:
					texture = Green;
					break;
				case LampColourManager.Colours.Oranje:
					texture = Orange;
					break;
				case LampColourManager.Colours.Rood:
					texture = Red;
					break;
				}
				Vector3 heading = light.gameObject.transform.position - GetComponent<Camera>().transform.position;
				if(Vector3.Dot(GetComponent<Camera>().transform.forward, heading) > 0){
					Color guiColor = Color.white;
					float dist = Vector3.Distance(light.gameObject.transform.position, GetComponent<Camera>().transform.position);
					guiColor.a = (dist > maxDist)||(dist < minDist) ? 0.0f : (1.0f-dist/maxDist)*0.9f;
					GUI.color = guiColor;
					GUI.DrawTexture(new Rect(screenPos.x - (texture.width/2), Screen.height - screenPos.y, (float)texture.width, (float)texture.height),texture);
				}
			}
		} else if (showFreecam){
			foreach(LampColourManager light in allLights){
				Texture texture = null;
				Vector3 screenPos = GetComponent<Camera>().WorldToScreenPoint(light.gameObject.transform.position+new Vector3(0.0f, 5.0f, 0.0f));
				switch(light.currentColour){
				case LampColourManager.Colours.Groen:
					texture = Green;
					break;
				case LampColourManager.Colours.Oranje:
					texture = Orange;
					break;
				case LampColourManager.Colours.Rood:
					texture = Red;
					break;
				}
				Vector3 heading = light.gameObject.transform.position - GetComponent<Camera>().transform.position;
				if(Vector3.Dot(GetComponent<Camera>().transform.forward, heading) > 0){
					Color guiColor = Color.white;
					float dist = Vector3.Distance(light.gameObject.transform.position, GetComponent<Camera>().transform.position);
					guiColor.a = (dist > maxDist)||(dist < minDist) ? 0.0f : (1.0f-dist/maxDist)*0.9f;
					GUI.color = guiColor;
					GUI.DrawTexture(new Rect(screenPos.x - (texture.width/2), Screen.height - screenPos.y, (float)texture.width, (float)texture.height),texture);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
