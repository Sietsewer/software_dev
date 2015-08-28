using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Controls vehicle navigation. Manages vehicle waypoints.
/// </summary>
public class NavController : MonoBehaviour {
	#region variables
	//Vars for detecting other vehicles.
	public bool useBreakLine = true;
  	public float minBreakSpeed = 0.0f;
	public float mindist = 10.0f;
	public GameObject brakeLineStart;
	public GameObject brakeLineEnd;

	//Vars for navigation
	public Spawner spawner;
	public NavMeshAgent nav;
	private float originalSpeed;
	public Transform target;
	private GameObject[] wayPoints;
	private int wayPointIndex = 0;
	#endregion

	void Start(){
		//Car prefab has three (disabled) car models. This picks a random one and enables it. Result is random model.
		List<GameObject> cars = new List<GameObject>();
		foreach(Transform child in this.transform){
			if(child.gameObject.name.Contains("car_")){
				cars.Add(child.gameObject);
			}
		}
		cars[UnityEngine.Random.Range(0, cars.Count)].SetActive(true);
		originalSpeed = nav.speed;
	}

	// Update is called once per frame
	void Update () {
		try{
			//Switches to next waypoint if in range.
			if(Vector3.Distance(wayPoints[wayPointIndex].transform.position, transform.position) < mindist){
				nextWaypoint();
			}
			//Deletes vehicle when last waypoint is reached.
		} catch (IndexOutOfRangeException e){
			Destroy(this.gameObject);
		}
		if(useBreakLine){
			RaycastHit hit;
			//Casts ray in front of vehicle to check for other vehicles. If so, brake the vehicle.
			if(Physics.Linecast(brakeLineStart.transform.position,
		                    brakeLineEnd.transform.position, out hit)){
				nav.speed = hit.distance/2 > minBreakSpeed ? hit.distance/2 : minBreakSpeed;
				if(hit.distance < 5){
					nav.speed = minBreakSpeed;
				}
			} else {
				nav.speed = originalSpeed;
			}
		}
	}

	/// <summary>
	/// Sets the waypoints for the vehicle to travel in its lifetime.
	/// </summary>
	/// <param name="wayPoints">Waypoints.</param>
	public void setWaypoints(GameObject[] wayPoints){
		this.wayPoints = wayPoints;
		wayPointIndex = 0;
		nav.SetDestination(wayPoints[wayPointIndex].transform.position);
	}

	/// <summary>
	/// Makes the vehicle drive to its next waypoint in line.
	/// </summary>
	private void nextWaypoint(){
		wayPointIndex++;
		try{
			nav.SetDestination(wayPoints[wayPointIndex].transform.position);
		} catch (NullReferenceException e){
			Destroy(this.gameObject);
		}
	}

	/// <summary>
	/// Calls back to spawner for an accurate vehicle count spawned by spawner.
	/// </summary>
	void OnDestroy(){
		if(spawner != null)spawner.carDestroyed();
	}
}
