using UnityEngine;
using System.Collections;

public class LightTriggerController : MonoBehaviour {

	public Networking net;
	public OutMessageBehaviour omb;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other){
		OutMessage om = new OutMessage ();
		om.num = omb.num;
		om.inbound = omb.inBound;
		om.outbound = omb.outBound;
		om.vehicle = omb.vehicle;
		net.sendMessage (om.toMessage ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
