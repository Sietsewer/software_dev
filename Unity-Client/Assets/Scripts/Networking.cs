using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

public class Networking : MonoBehaviour
{

		// Use this for initialization

		public string ip = "172.16.90.157";
		public string port = "4443";
		private TcpClient clientSocket;
		private NetworkStream netStream;
		private StreamWriter streamWriter;
		private StreamReader streamReader;
		private bool connected = false;
		private float counter = 0.0f;
		public float readDelay = 1.0f;
		private bool socketReady = false;
		public LightsController lights;

		void Start ()
		{
				lights = new LightsController();
				try {
						clientSocket = new TcpClient (ip, int.Parse (port));
						Debug.Log ("Connection made.");
						connected = true;
				} catch (SocketException e) {
						Debug.Log ("Connection failed to start! : " + e.ToString ());
						connected = false;
				}
				if (connected) {
						netStream = clientSocket.GetStream ();
						netStream.ReadTimeout = 10;
						streamWriter = new StreamWriter (netStream);
						streamReader = new StreamReader (netStream);
				}
				socketReady = true;
				
		}
	
		// Update is called once per frame
		void Update ()
		{
				this.counter += Time.deltaTime;
				if (this.counter > this.readDelay && socketReady) {
						this.counter = 0;
						if (connected && netStream.DataAvailable) { // Order is important, else there be errors.
								//Debug.Log ("Reading message...");
								receiveMessage (streamReader.ReadLine ());
						}
				}
		}
		
		private void receiveMessage (string message)
		{
				if (!socketReady) 
						return;

				if (message.Length == 4) {
						InMessage receivedMessage = MessageHandler.stringToInMessage (message);
						this.lights.setLight(receivedMessage);

						Debug.Log (MessageHandler.stringToInMessage (message).toString ());
				} else {
						//Debug.Log ("RECEIVED: " + message);
				}
		}
		
		public void forceRead ()
		{
				Debug.Log ("Forcing read message...");
				receiveMessage (streamReader.ReadLine ());
		}

		public void sendMessage (string message)
		{
				if (!socketReady) {
						return;
		}
				//Debug.Log ("SENDING: " + message);
				streamWriter.WriteLine (message);
				streamWriter.Flush ();
				
		}
}
