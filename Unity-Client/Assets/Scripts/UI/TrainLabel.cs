using UnityEngine;
using System.Collections;
/// <summary>
/// Label for train crossing. Displays an icon at gameobject position which represents the status of the linked CrossingController. Disable script to hide.
/// </summary>
public class TrainLabel: MonoBehaviour {
	#region variables
	//variables about visability range of the icon.
	public float maxDist = 200.0f;
	public float minDist = 10.0f;

	//Variables which hold the various states of the icon.
	public Texture Red;
	public Texture White;
	public Texture Off;
	
	public CrossingController cc;
	private Camera camera;

	//Variables about the blinking of the light.
	private bool on;
	private float blinkCounter = 0.0f;
	private float blinkDuration = 1.0f;
	#endregion
	
	void Start () {
		//Find main camera
		camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
	}
	// Update is called once per frame
	void Update () {
		//Advances counter to time blinks.
		blinkCounter += Time.deltaTime;
	}

	void OnGUI ()
	{
		//Checks the status of the CrossingController.
		Texture texture = on ? (cc.isTriggered ? Red : White) : Off;
		//Alternates on bool based on time.
		if (blinkCounter > blinkDuration) {
			on = !on;
			blinkCounter = 0.0f;
		}

		//Grabs the screen position of the gameObject, and dot product to see if object is roughly ahead of the camera.
		//Prevents icons behind camera from drawing.
		Vector3 screenPos = camera.WorldToScreenPoint(transform.position);
		Vector3 heading = gameObject.transform.position - camera.transform.position;
		if(Vector3.Dot(camera.transform.forward, heading) > 0 && GlobalFlags.showLabels){
			//Draws the icon.
			Color guiColor = Color.white;
			float dist = Vector3.Distance(gameObject.transform.position, camera.transform.position);
			guiColor.a = (dist > maxDist)||(dist < minDist) ? 0.0f : (1.0f-dist/maxDist)*0.9f;
			GUI.color = guiColor;
			GUI.DrawTexture(new Rect(screenPos.x - (texture.width/2), Screen.height - screenPos.y+44, (float)texture.width, (float)texture.height),texture);
		}
	}
}
