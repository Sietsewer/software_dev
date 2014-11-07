using UnityEngine;
using System.Collections;

public class StopTrigger : MonoBehaviour {

	// Use this for initialization
	public bool stop = true;
	void Start () {
	
	}
	void OnTriggerEnter(Collider other){
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(stop && nav!=null){
			nav.Stop();
		} else {
			nav.Resume();
			Debug.Log("CONTINUE");
		}

	}
	void OnTriggerStay(Collider other){
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(stop && nav!=null){
			nav.Stop();
		} else {
			nav.Resume();
			Debug.Log("CONTINUE");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
