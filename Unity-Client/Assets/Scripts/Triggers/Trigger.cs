//!!triggerwarning!!\\
using UnityEngine;
using System.Collections;

/// <summary>
/// Used for unifing all trigger-like objects used. Serves both as a trigger input and a trigger output for ease of use.
/// </summary>
public abstract class Trigger : MonoBehaviour {
	/// <summary>
	/// Used to determine if the trigger object is triggered or not. Read-only. 
	/// </summary>
	/// <value><c>true</c> if is triggered; otherwise, <c>false</c>.</value>
	public abstract bool isTriggered{ get; }

	/// <summary>
	/// The triggers the object listens to.
	/// </summary>
	public Trigger[] triggers;

	/// <summary>
	/// Trigger modes.
	/// <c>All Triggered</c> - <c>TriggersTriggered</c> is true when all triggers in <c>triggers</c> are triggered.
	/// <c>Any Triggered</c> - <c>TriggersTriggered</c> is true when any triggers in <c>triggers</c> are triggered.
	/// <c>None Triggered</c> - <c>TriggersTriggered</c> is true when no triggers in <c>triggers</c> are triggered.
	/// </summary>
	public enum TriggerMode {AllTriggered,AnyTriggered,NoneTriggered}
	public TriggerMode triggerMode = TriggerMode.AnyTriggered;

	//Implements trigger modes.
	public bool TriggersTriggered{
		get{
			if(triggers.Length == 0) return false;
			switch(triggerMode){
			case TriggerMode.AllTriggered:
				foreach(Trigger trigger in triggers){
					if(!trigger.isTriggered){
						return false;
					}
				}
				return true;
			case TriggerMode.AnyTriggered:
				foreach(Trigger trigger in triggers){
					if(trigger != null && trigger.isTriggered){

						return true;
					}
				}
				return false;
			case TriggerMode.NoneTriggered:
				foreach(Trigger trigger in triggers){
					if(trigger.isTriggered){
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}
}
