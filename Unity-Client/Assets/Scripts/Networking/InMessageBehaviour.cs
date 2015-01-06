using UnityEngine;
using System.Collections;

public class InMessageBehaviour : MonoBehaviour {

	public InMessage.Direction inBound;
	public InMessage.Direction outBound;
	public InMessage.Settings settings;
	public InMessage.Vehicle vehicle;

	public InMessage inMessage;


	// Use this for initialization
	void Start () {
		inMessage = new InMessage();
	}
	
	// Update is called once per frame
	void Update () {
		inMessage.inbound = this.inBound;
		inMessage.outbound = this.outBound;
		inMessage.setting = this.settings;
		inMessage.vehicle = this.vehicle;
	}
}
