using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {
	public string message = "Default Message.";
	public bool sendString;
	private Networking net;


	public InMessageBehaviour inMessageBehaviour;

	// Use this for initialization
	void Start () {
		net = gameObject.GetComponent<Networking>();
		Debug.Log (MessageHandler.getMessage ("NOAR").toString ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button(new Rect(10, 10, 50, 50), "Send")){
			net.sendMessage(this.sendString?this.message:this.inMessageBehaviour.inMessage.toMessage());
		}

	}
}
