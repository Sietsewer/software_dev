//!!Possible spaghetti ahead!!\\
using UnityEngine;
using System.Collections;

/// <summary>
/// Script that spawns vehicles.
/// </summary>
public class Spawner : MonoBehaviour {
	#region variables
	public bool messageOnTrainDelete = false;
	/// <summary>
	/// Whether this spawnpoint spawns on its own. Spawns at <c>SpawnEvery</c> interval, with no more than <c>maxAlive</c> in the world.
	/// </summary>
	public bool selfSpawn = true;
	/// <summary>
	/// The maximum of amount vehicle alive at a time. See <c>selfSpawn</c>.
	/// </summary>
	public int maxAlive = 2;
	/// <summary>
	/// Amount of vehicles currently alive.
	/// </summary>
	public int alive = 0;
	/// <summary>
	/// The GameObject that will be spawned.
	/// </summary>
	public GameObject spawnMe;
	//instance of the gameObject that will be spawned.
	private GameObject spawnMeInst;
	/// <summary>
	/// The target waypoints.
	/// </summary>
	public GameObject targetWaypoints;
	//The NavController used to manage waypoints of the vehicle.
	private NavController navC;
	/// <summary>
	/// The delay between spawns. See <c>selfSpawn</c>.
	/// </summary>
	public float SpawnEvery = 5.0f;
	//used for timing spawns.
	private float counter;
	//Waypoints of the vehicles.
	private GameObject[] wayPoints;
	/// <summary>
	/// Whether this spawner is a train or not. Used for <c>SpawnRoulette</c> to prevent train spawns.
	/// </summary>
	public bool isTrain = false;
	#endregion

	// Use this for initialization
	void Start () {
		//Creates instance of vehicle and activates it.
		spawnMeInst = (GameObject)Instantiate(spawnMe);
		spawnMeInst.SetActive(false);

		//Inits array on amount of childer the waypoints GameObject has, then fills targetWaypoints with them.
		wayPoints = new GameObject[targetWaypoints.transform.childCount];
		int i = 0;
		foreach(Transform child in targetWaypoints.transform){
			wayPoints[i] = child.gameObject;
			i++;
		}

		//Inits the nav controller.
		navC = spawnMeInst.GetComponent<NavController>();
		navC.target = targetWaypoints.transform;
		navC.setWaypoints(wayPoints);

		//Sets the instance to the correct position.
		spawnMeInst.transform.position = this.transform.position;
		spawnMeInst.transform.rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//Handles spawning based on timer.
		if(selfSpawn){
			if(maxAlive >= 1){
				counter += Time.deltaTime;
				if(counter > this.SpawnEvery){
					if(alive < maxAlive){
						spawn ();
						counter = 0.0f;
						alive++;
					}
				}
			}
		}
	}

	/// <summary>
	/// Force spawn on this spawner.
	/// </summary>
	public void spawn(){
		GameObject spawnee = (GameObject)Instantiate(spawnMeInst);
		spawnee.SetActive(true);
		NavController nav = spawnee.GetComponent<NavController>();
		nav.setWaypoints(wayPoints);
		nav.spawner = this;
	}

	/// <summary>
	/// Cars the destroyed. Also used for keeping track of vehicles alive.
	/// </summary>
	public void carDestroyed(){
		alive--;
	}
}
