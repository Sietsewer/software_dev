using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnMe;
	private GameObject spawnMeInst;
	public GameObject targetWaypoint;
	private NavController navC;
	public float SpawnEvery = 5.0f;
	private float counter;
	private GameObject[] wayPoints;
	private int currentPoint;
		// Use this for initialization
	void Start () {
		spawnMeInst = (GameObject)Instantiate(spawnMe);
		spawnMeInst.SetActive(false);
		wayPoints = new GameObject[targetWaypoint.transform.childCount];

		int i = 0;
		foreach(Transform child in targetWaypoint.transform){
			wayPoints[i] = child.gameObject;
			i++;
		}
		/*for(int i = 0; i < targetWaypoint.transform.childCount; i++){
			wayPoints[i] = targetWaypoint.transform.GetChild(i).gameObject;
		}*/

		navC = spawnMeInst.GetComponent<NavController>();
		navC.target = targetWaypoint.transform;
		navC.setWaypoints(wayPoints);

		spawnMeInst.transform.position = this.transform.position;
		spawnMeInst.transform.rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if(counter > this.SpawnEvery){
			GameObject spawnee = (GameObject)Instantiate(spawnMeInst);
			spawnee.SetActive(true);
			spawnee.GetComponent<NavController>().setWaypoints(wayPoints);
			counter = 0.0f;
		}
	}
}
