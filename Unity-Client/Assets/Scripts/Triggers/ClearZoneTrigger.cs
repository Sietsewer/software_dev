using UnityEngine;
using System.Collections;

/// <summary>
/// Trigger used to detect if a train is on a crossing, or has passed it. ONLY WORKS FOR ONE TRAIN,
/// OTHERWISE BUGGED.
/// </summary>
public class ClearZoneTrigger : Trigger {

	public enum Status {AllClear, Traincoming, Trainpassed}
	public Status status = Status.AllClear;
	private GameObject train;

	void start(){
		//used for DEBUGGING, change flag in GlobalFlags
		this.GetComponent<MeshRenderer> ().enabled = GlobalFlags.showStopTriggers;
	}

	void Update(){
		switch (status) {
		case Status.AllClear:
			train = GameObject.FindGameObjectWithTag("Train");
			if(train!=null) status = Status.Traincoming;
			break;
		case Status.Traincoming:
			break;
		case Status.Trainpassed:
			train = GameObject.FindGameObjectWithTag("Train");
			if(train==null) status = Status.AllClear;
			break;
			break;
		}
	}

	//Called when a collider exits the collider. Checks whether the collider is a train. If it is,
	//crossing is marked as passed.
	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == ("Train")){
			status = Status.Trainpassed;
		}
	}

	/// <summary>
	/// Is triggered if there is a train coming. Untriggers when train has passed the crossing.
	/// </summary>
	/// <value><c>true</c> if is triggered; otherwise, <c>false</c>.</value>
	public override bool isTriggered {
		get {
			return status == Status.Traincoming; 
		}
	}
}
