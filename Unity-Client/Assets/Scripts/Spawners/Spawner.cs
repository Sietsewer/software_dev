using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public bool messageOnTrainDelete = false;
	public bool selfSpawn = true;
	private Networking net;
	public OutMessageBehaviour trainMessage;
	public bool isTrain = false;
	public CrossingController cc;
	public int maxAlive = 2;
	public int alive = 0;
	public GameObject spawnMe;
	private GameObject spawnMeInst;
	public GameObject targetWaypoint;
	private NavController navC;
	public float SpawnEvery = 5.0f;
	private float counter;
	private GameObject[] wayPoints;
	private int currentPoint;

	void sendMessage (int count){
		if(isTrain){
			net = GameObject.FindObjectOfType(typeof(Networking)) as Networking;
			OutMessage om = new OutMessage ();
			om.num = trainMessage.num;
			om.inbound = trainMessage.inBound;
			om.outbound = trainMessage.outBound;
			om.vehicle = trainMessage.vehicle;
			trainMessage.count = count;
			om.count = count;
			net.sendMessage (om.toMessage ());
		}
	}

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

	public void spawn(){
		GameObject spawnee = (GameObject)Instantiate(spawnMeInst);
		if(isTrain){
			TrainHandler th = (TrainHandler)spawnee.GetComponent(typeof(TrainHandler));
			th.cc = this.cc;
			sendMessage(1);
		}
		spawnee.SetActive(true);
		NavController nav = spawnee.GetComponent<NavController>();
		nav.setWaypoints(wayPoints);
		nav.spawner = this;
	}

	public void carDestroyed(){
		alive--;
		if(isTrain && messageOnTrainDelete){
			sendMessage(0);
		}
	}
}
