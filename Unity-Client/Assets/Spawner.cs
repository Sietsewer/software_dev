using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnMe;
	public GameObject spawnMeInst;
	public GameObject targetWaypoint;
	private NavController navC;
	public float SpawnEvery = 5.0f;
	private float counter;
		// Use this for initialization
	void Start () {

		navC = spawnMeInst.GetComponent<NavController>();
		navC.target = targetWaypoint.transform;
		Contact
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		spawnMeInst.transform.position = this.transform.position;
		spawnMeInst.transform.rotation = this.transform.rotation;
		if(counter > this.SpawnEvery){
			Instantiate(spawnMeInst);
			counter = 0.0f;
		}
	}
}
