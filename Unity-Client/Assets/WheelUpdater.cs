using UnityEngine;
using System.Collections;

public class WheelUpdater : MonoBehaviour {

	public WheelCollider collider;
	// Use this for initialization
	void Start (){
	}
	
	// Update is called once per frame
	void Update () {
		WheelHit wheelHit = new WheelHit();
		if(collider.GetGroundHit(out wheelHit)){
			transform.position = wheelHit.point + new Vector3(0.0f, collider.radius, 0.0f);
		}
	}
}
