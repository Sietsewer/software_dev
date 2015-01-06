using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour
{
	private LightsController lights;

		public string message = "Default Message.";
		public bool sendString;
		public bool sendOutMessage;
		private Networking net;
		public InMessageBehaviour inMessageBehaviour;
		public OutMessageBehaviour outMessageBehaviour;

		// Use this for initialization
		void Start ()
		{
				net = gameObject.GetComponent<Networking> ();
				Debug.Log (MessageHandler.stringToInMessage ("NOAR").toString ());
		lights = new LightsController();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnGUI ()
		{
				if (GUI.Button (new Rect (10, 10, 100, 50), "Send")) {
						if (this.sendString) {
								net.sendMessage (this.message);
						} else {
								if (this.sendOutMessage) {
										OutMessage om = new OutMessage ();
										om.num = outMessageBehaviour.num;
										om.inbound = outMessageBehaviour.inBound;
										om.outbound = outMessageBehaviour.outBound;
										om.vehicle = outMessageBehaviour.vehicle;
										net.sendMessage (om.toMessage ());
								} else {
										net.sendMessage (this.inMessageBehaviour.inMessage.toMessage ());

								}
						}
				}
				if (GUI.Button (new Rect (10, 70, 100, 50), "Force read")) {
						//net.forceRead ();
			lights.printAll();
				}
		}
}
