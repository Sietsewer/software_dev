using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TrainHandler : Trigger {
	public CrossingController cc;
	public bool cleared = false;
	private bool once = true;
	private bool _isTriggered = false;
	void Start () {
		if(GameObject.FindObjectsOfType(this.GetType()).Length > 1) Destroy(this);
		_isTriggered = false;
	}

	void Update(){
		if(cleared&&once){
			_isTriggered = true;
			once = false;
		}
	}

	public override bool isTriggered {
		get{return _isTriggered;}
	}
}
