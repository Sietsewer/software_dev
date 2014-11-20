using UnityEngine;
using System;
using System.Collections;

public class NavController : MonoBehaviour {
	public NavMeshAgent nav;
	public Transform target;
	public float mindist = 10.0f;
	private GameObject[] wayPoints;
	private int wayPointIndex = 0;
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
			nextWaypoint();
		}
	}

	public void halt(){
	}

	public void drive(){
	}

	public void setWaypoints(GameObject[] wayPoints){
		this.wayPoints = wayPoints;
		wayPointIndex = 0;
		nav.SetDestination(wayPoints[wayPointIndex].transform.position);
	}

	private void nextWaypoint(){
		wayPointIndex++;
		try{
			nav.SetDestination(wayPoints[wayPointIndex].transform.position);
		} catch (NullReferenceException e){
			Destroy(this.gameObject);
		}
	}
}
