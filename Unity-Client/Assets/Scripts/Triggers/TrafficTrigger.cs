using UnityEngine;
using System.Collections;

/// <summary>
/// Traffic trigger. Normal trigger that triggers based on parameters. Bools are for respective vehicle. False ignores the vehicle type.
/// </summary>
public class TrafficTrigger: Trigger {

	public bool pedestrians = true;
	public bool bikes = true;
	public bool cars = false;
	public bool trains = false;
	public bool busses = false;

	private int count;
	
	private bool _isTriggered;
	
	void Start () {
		//used for DEBUGGING, change flag in GlobalFlags
		this.GetComponent<MeshRenderer> ().enabled = GlobalFlags.showStopTriggers;
	}

	//Checks if GameObject would trigger this trigger.
	private bool doesTrigger(GameObject other){
		return 	(other.tag == "Pedestrian" 	&& pedestrians) ||
				(other.tag == "Bike" 		&& bikes) ||
				(other.tag == "Bus" 		&& busses) ||
				(other.tag == "Car" 		&& cars) ||
				(other.tag == "Train" 		&& trains);
	}
	
	void OnTriggerEnter(Collider other){
		if(doesTrigger(other.gameObject))
		count++;
	}

	void OnTriggerExit(Collider other){
		if(doesTrigger(other.gameObject))
		count--;
	}

	/// <summary>
	/// Gets a value indicating whether there are vehicles inside this trigger.
	/// </summary>
	/// <value><c>true</c> if is triggered; otherwise, <c>false</c>.</value>
	public override bool isTriggered{
		get{return count>0;}
	}
}