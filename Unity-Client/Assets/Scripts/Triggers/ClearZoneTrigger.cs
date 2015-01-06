using UnityEngine;
using System.Collections;

public class ClearZoneTrigger : MonoBehaviour {

	void OnTriggerExit(Collider other){
		TrainHandler th = (TrainHandler)other.gameObject.GetComponent(typeof(TrainHandler));
		if(th!=null){
			th.cleared = true;
		}
	}
}
