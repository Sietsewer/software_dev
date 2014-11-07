using UnityEngine;
using System.Collections;

public class NavController : MonoBehaviour {
	public NavMeshAgent nav;
	public Transform target;
	public float mindist = 10.0f;
	// Use this for initialization
	/*void Start (Transform target) {
		nav.SetDestination(target.position);
	}*/
	void Start(){
		nav.SetDestination(this.target.position);
	}

	void OnTriggerEnter(Collider other){
		//nav.Stop();
		//Debug.Log("Vehicle stopped.");
	}
	void OnTriggerExit(Collider other){
		//nav.Resume();
		//Debug.Log("Vehicle resumed.");
	}

	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(target.position, transform.position) > mindist){

		} else {
			Destroy(gameObject);
		}

	}

	public void halt(){
	}

	public void drive(){
	}

	private void nextWaypoint(){
		Debug.Log("NEXT!");
	}
}
