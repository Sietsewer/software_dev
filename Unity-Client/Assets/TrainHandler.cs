using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TrainHandler : MonoBehaviour {
	public CrossingController cc;
	public bool cleared = false;
	private bool once = true;
	void Start () {
		if(GameObject.FindObjectsOfType(this.GetType()).Length > 1) Destroy(this);
		cc.open = false;
	}

	void Update(){
		if(cleared&&once){
			cc.open = true;
			once = false;
		}
	}
}
