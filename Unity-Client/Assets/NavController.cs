using UnityEngine;
using System.Collections;

public class NavController : MonoBehaviour {
	public NavMeshAgent nav;
	public Transform target;
	public float mindist = 10.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(target.position, transform.position) > mindist){
			nav.SetDestination(target.position);
		} else {
			nextWaypoint();
		}

	}

	private void nextWaypoint(){
		Debug.Log("NEXT!");
	}
}
