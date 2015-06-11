using UnityEngine;
using System.Collections;


public class LampColourManager : MonoBehaviour {

	// Use this for initialization
	private Material rood;
	private Material oranje;
	private Material groen;

	public bool go = false;
	private bool stopping = false;
	private bool stop = true;
	private float count = 0.0f;
	private float stopTime = 3.0f;

	public enum Colours{ Rood, Oranje, Groen }
	public Colours nextColour = Colours.Rood;
	[HideInInspector]
	public InMessageBehaviour LightID;
	public Colours currentColour = Colours.Groen;

	void Start () {
		LightID = gameObject.GetComponent<InMessageBehaviour>();
		foreach(Transform child in transform){
			if(child.gameObject.name == "Lamp_R"){
				rood = child.transform.GetComponent<Renderer>().material;
			}
			if(child.gameObject.name == "Lamp_O"){
				oranje = child.transform.GetComponent<Renderer>().material;
			}
			if(child.gameObject.name == "Lamp_G"){
				groen = child.transform.GetComponent<Renderer>().material;
			}
		}

		/*rood = GameObject.Find("Lamp_R").renderer.material;
		oranje = GameObject.Find("Lamp_O").renderer.material;
		groen = GameObject.Find("Lamp_G").renderer.material;*/
	}
	public void changeColour (InMessage.Settings colours){
		switch (colours){
		case InMessage.Settings.Rood:
			nextColour = Colours.Rood;
			break;
		case InMessage.Settings.Oranje:
			nextColour = Colours.Oranje;
			break;
		case InMessage.Settings.Groen:
			nextColour = Colours.Groen;
			break;
		}
	}
	public void changeColour (Colours colour){
		rood.color = Color.black;
		oranje.color = Color.black;
		groen.color = Color.black;
		switch(colour){
		case Colours.Rood:
			rood.color = Color.red;
			break;
		case Colours.Oranje:
			oranje.color = Color.yellow;
			break;
		case Colours.Groen:
			groen.color = Color.green;
			break;
		}
	}
	// Update is called once per frame
	void Update () {
		if(go){
			nextColour = Colours.Groen;
			stop = false;
		} else {
			if(!stop){
				stopping = true;
				nextColour = Colours.Oranje;
			}
		}
		if(stopping){
			count += Time.deltaTime;
			if(count > stopTime){
				stop = true;
				stopping = false;
				count = 0.0f;
				nextColour = Colours.Rood;
			}
		}

		if(nextColour != currentColour){
			changeColour(nextColour);
			currentColour = nextColour;
		}
	}
}
