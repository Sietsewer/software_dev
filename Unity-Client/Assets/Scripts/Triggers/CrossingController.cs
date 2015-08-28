using UnityEngine;
using System.Collections;

/// <summary>
/// Controls a train crossing.
/// </summary>
public class CrossingController : Trigger {
	/// <summary>
	/// The barriers of the crossing.
	/// </summary>
	public BarrierController[] barriers;
	/// <summary>
	/// The time it takes for the crossing to open.
	/// </summary>
	public float openingTime = 5.0f;
	//Used for timing.
	private float counter = 0.0f;
	//Holds status of crossing.
	private enum status {closed, opening, open}
	private status crossingStatus = status.opening;
	
	//Close the crossing.
	private void close(){
		crossingStatus = status.closed;
		setBarriers (false);
	}

	//open the crossing.
	private void open(){
		if (crossingStatus == status.closed) {
			crossingStatus = status.opening;
			setBarriers(true);
		}
	}

	// Update is called once per frame
	void Update () {
		//Closes or opens crossing based on triggers.
		if (TriggersTriggered) {
						this.close ();		
				} else {
						this.open ();
				}
		switch (crossingStatus){
		case status.closed:
			break;
		case status.opening:
			counter+=Time.deltaTime;
			if(counter > openingTime){
				crossingStatus = status.open;
				counter = 0.0f;
			}
			break;
		case status.open:
			break;
		}

	}

	/// <summary>
	/// Used to determine if crossing is triggered or not. Read-only.
	/// </summary>
	/// <value>true</value>
	/// <c>false</c>
	public override bool isTriggered{
		get{return crossingStatus != status.open;}
	}

	//Sets the barriers open or shut.
	private void setBarriers (bool value){
		foreach(BarrierController barrier in barriers){
			barrier.open = value;
		}
	}
}
