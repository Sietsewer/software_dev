using UnityEngine;
using System.Collections;

public class OutMessageBehaviour : MonoBehaviour {
	public int num;
	public OutMessage.Direction inBound;
	public OutMessage.Direction outBound;
	public OutMessage.Vehicle vehicle;
	public int count;
	
	public OutMessage outMessage;
	
	
	// Use this for initialization
	void Start () {
		outMessage = new OutMessage();
	}
	
	// Update is called once per frame
	void Update () {
		outMessage.inbound = this.inBound;
		outMessage.outbound = this.outBound;
		outMessage.num	= this.num;
		outMessage.vehicle = this.vehicle;
		outMessage.count = this.count;
	}
}
