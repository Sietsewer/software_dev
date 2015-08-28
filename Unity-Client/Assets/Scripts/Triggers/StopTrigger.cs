using UnityEngine;
using System.Collections;

/// <summary>
/// Trigger to stop vehicles.
/// </summary>
public class StopTrigger : Trigger {

	//Used to keep track of amount of vehicles in stopTrigger, and if any are in at all.
	private int count;

	//field for property isTriggered.
	private bool _isTriggered;

	void Start () {
		//used for DEBUGGING, change flag in GlobalFlags
		this.GetComponent<MeshRenderer> ().enabled = GlobalFlags.showStopTriggers;
	}
	/// <summary>
	/// Raises the trigger enter event. Stops the vehicle in the trigger, if the stopTrigger is triggered.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter(Collider other){
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(TriggersTriggered){
			nav.Stop();
		} else {
			nav.Resume();
		}

		count++;
	}

	/// <summary>
	/// Raises the trigger stay event. If the vehicle is in the stopTrigger while it is untriggered, have vehicle resume driving.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay(Collider other){
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(TriggersTriggered){
			nav.Stop();
		} else {
			nav.Resume();
		}
	}

	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit(Collider other){
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		nav.Resume();

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
