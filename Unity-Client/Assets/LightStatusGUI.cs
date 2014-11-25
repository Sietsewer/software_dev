using UnityEngine;
using System.Collections;

public class LightStatusGUI : MonoBehaviour {

	public Texture Red;
	public Texture Orange;
	public Texture Green;
	private LampColourManager[] lights;

	// Use this for initialization
	void Start () {
		lights = GameObject.FindObjectsOfType(typeof(LampColourManager)) as LampColourManager[];
	}

	void OnGUI ()
	{
		foreach(LampColourManager light in lights){
			Texture texture;
			Vector3 screenPos = camera.WorldToScreenPoint(light.gameObject.transform.position);
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
			GUI.DrawTexture(new Rect(screenPos.x, screenPos.y, (float)texture.width, (float)texture.height),texture);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
