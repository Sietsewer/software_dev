using UnityEngine;
using System.Collections;


public class LampColourManager : MonoBehaviour {

	// Use this for initialization
	private Material rood;
	private Material oranje;
	private Material groen;

	public enum Colours{ Rood, Oranje, Groen }
	public Colours nextColour = Colours.Rood;
	[HideInInspector]
	public Colours currentColour = Colours.Groen;
	void Start () {
		rood = GameObject.Find("Lamp_R").renderer.material;
		oranje = GameObject.Find("Lamp_O").renderer.material;
		groen = GameObject.Find("Lamp_G").renderer.material;
	}
	public void changeColour (InMessage.Settings colours){
		switch (colours){
		case InMessage.Settings.Rood:
			changeColour(Colours.Rood);
			break;
		case InMessage.Settings.Oranje:
			changeColour(Colours.Oranje);
			break;
		case InMessage.Settings.Groen:
			changeColour(Colours.Groen);
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
		if(nextColour != currentColour){
			changeColour(nextColour);
			currentColour = nextColour;
		}
	}
}
