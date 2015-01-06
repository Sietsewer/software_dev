using UnityEngine;
using System.Collections;

public class LightTriggerController : MonoBehaviour {
	public bool quickTrigger = false;
	private Networking net;
	public OutMessageBehaviour omb;
	public float minDelay = 0.2f;
	private int count;
	private int prevCount;
	private float timeCount;
	// Use this for initialization
	void Start () {
		net = GameObject.FindObjectOfType(typeof(Networking)) as Networking;
	}

	void OnTriggerEnter(Collider other){
		count++;
	}

	void OnTriggerExit(Collider other){
		count--;
	}

	void sendMessage (){
		OutMessage om = new OutMessage ();
		om.num = omb.num;
		om.inbound = omb.inBound;
		om.outbound = omb.outBound;
		om.vehicle = omb.vehicle;
		omb.count = count;
		om.count = count;
		net.sendMessage (om.toMessage ());
	}
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if(quickTrigger || (timeCount > minDelay && prevCount != count)){
			sendMessage();
			prevCount = count;
			timeCount = 0;
		}
	}
}

