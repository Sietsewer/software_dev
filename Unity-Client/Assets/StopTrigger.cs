﻿using UnityEngine;
using System.Collections;

public class StopTrigger : MonoBehaviour {

	// Use this for initialization
	public bool stop = true;
	public LampColourManager light;
	void Start () {
	}
	void OnTriggerEnter(Collider other){
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(stop && nav!=null){
			nav.Stop();
		} else {
			nav.Resume();
		}

	}
	void OnTriggerStay(Collider other){
		NavMeshAgent nav = other.gameObject.GetComponent<NavMeshAgent>();
		if(stop && nav!=null){
			nav.Stop();
		} else {
			nav.Resume();
		}
	}
	// Update is called once per frame
	void Update () {
		switch(light.currentColour){
		case LampColourManager.Colours.Groen:
			this.stop = false;
			break;
		case LampColourManager.Colours.Oranje:
			this.stop = true;
			break;
		case LampColourManager.Colours.Rood:
			this.stop = true;
			break;
		}
}
}