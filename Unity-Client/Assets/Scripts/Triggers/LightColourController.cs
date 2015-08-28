using UnityEngine;
using System.Collections;


public class LightColourController : Trigger {
	#region Variables
	//Components of specific lamps of the light. Link to parts that will change colour.
	/// <summary>
	/// The red lamp.
	/// </summary>
	public Renderer redLamp;

	/// <summary>
	/// The orange lamp. If this is not assigned, set orangeTime to 0.0f.
	/// </summary>
	public Renderer orangeLamp;

	/// <summary>
	/// The green lamp.
	/// </summary>
	public Renderer greenLamp;

	//Materials to change lamp colour.
	private Material redMaterial;
	private Material orangeMaterial;
	private Material greenMaterial;

	//Variables for light timing.
	private float count = 0.0f;

	/// <summary>
	/// The time the light stays orange when it turns red.
	/// </summary>
	public float orangeTime = 3.0f;
	private float _greenTime = 10.0f;
	private float greenTimeMinimum = 6.0f;//Can't be changed by traffic law.
	//Used for when forcing a change to red, while still using minimum green time.
	private bool cutoffGreen = false;

	//Variables for determining light colours.
	/// <summary>
	/// The colours a light might be.
	/// </summary>
	public enum Colours{ Red, Orange, Green }
	private Colours _lightColour = Colours.Red;
	
	/// <summary>
	/// Whether the light should automatically switch colour.
	/// </summary>
	public bool automaticGreen = true;

	private Colours previousLightColour = Colours.Red;

	/// <summary>
	/// Gets the current light colour.
	/// </summary>
	/// <value>The light colour.</value>
	public Colours lightColour {
		get{ return _lightColour;}
	}
	#endregion

	/// <summary>
	/// Gets or sets the time a light remains green, if automaticGreen is set to true.
	/// </summary>
	/// <value>The green time.</value>
	public float greenTime{
		get{return _greenTime;}
		set{_greenTime = value < greenTimeMinimum ? greenTimeMinimum : value;}
	}
	
	/// <summary>
	/// Can be used as a way to check if a car can go, and to set wheter the light is green or red.
	/// </summary>
	/// <value><c>true</c> if you may pass; otherwise, <c>false</c>.</value>
	public bool go{
		get{ return _lightColour == Colours.Green;}
		set{
			if(value){
				_lightColour = Colours.Green;
			} else {
				cutoffGreen = true;
			}
		}
	}

	void Start () {
		redLamp.material.color = Color.black;
		//Prevents error for lights without orange lamps.
		if (orangeLamp != null) orangeLamp.material.color = Color.black;
		greenLamp.material.color = Color.black;
		switch(_lightColour){
		case Colours.Red:
			redLamp.material.color = Color.red;
			break;
		case Colours.Orange:
			orangeLamp.material.color = Color.yellow;
			break;
		case Colours.Green:
			greenLamp.material.color = Color.green;
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		/// Counting only needed when light is green or orange.
		if (_lightColour != Colours.Red) count += Time.deltaTime;
		switch (_lightColour) {
		case Colours.Green:
			//Switch light to orange if greentime is passed (granted greentime > 0), or can cut off.
			if ((automaticGreen && count >= _greenTime) || (cutoffGreen && count >= greenTimeMinimum)){
				count = 0;
				_lightColour = this.orangeTime <= 0 ? Colours.Red : Colours.Orange;
				cutoffGreen = false;
			}
			break; 
		case Colours.Orange:
			if (orangeTime > 0 && count >= orangeTime){
				_lightColour = Colours.Red;
				count = 0;
			}
			break;
		case Colours.Red:
			count = 0;
			break;
				}

		//Switches the in-game colour of the lights to represent the value of lightColour.
		if(_lightColour != previousLightColour){
			redLamp.material.color = Color.black;
			//Prevents error for lights without orange lamps.
			if (orangeLamp != null) orangeLamp.material.color = Color.black;
			greenLamp.material.color = Color.black;
			switch(_lightColour){
			case Colours.Red:
				redLamp.material.color = Color.red;
				break;
			case Colours.Orange:
				orangeLamp.material.color = Color.yellow;
				break;
			case Colours.Green:
				greenLamp.material.color = Color.green;
				break;
			}
			previousLightColour = _lightColour;
		}
	}

	/// <summary>
	/// Gets a value indicating whether this <see cref="LightColourController"/> is triggered.
	/// </summary>
	/// <value><c>true</c> if is triggered; otherwise, <c>false</c>.</value>
	public override bool isTriggered{
		get{
			return !go;
		}
	}
}
