using UnityEngine;
using System.Collections;

public class LightsController {

	private LampColourManager[] lights;

	// Use this for initialization
	public LightsController() {
		lights = GameObject.FindObjectsOfType(typeof(LampColourManager)) as LampColourManager[];
		//Find all GameObjects with LampColourManager; all gameobjects that are lights.
	}
		
	public void setLight(InMessage im){
		foreach(LampColourManager light in lights){
			if(light.LightID.inMessage.vehicle  == im.vehicle &&
			   light.LightID.inMessage.inbound  == im.inbound &&
			   light.LightID.inMessage.outbound == im.outbound){
				light.changeColour(im.setting);
				//Check if light is same as requested,
				//set colour if so.
			}
		}
	}
}
