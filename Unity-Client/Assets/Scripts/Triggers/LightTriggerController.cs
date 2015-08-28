using UnityEngine;
using System.Collections;

public class LightTriggerController : MonoBehaviour {
	public bool quickTrigger = false;
	public float minDelay = 0.2f;
	private int count;
	private int prevCount;
	private float timeCount;
	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider other){
		count++;
	}

	void OnTriggerExit(Collider other){
		count--;
	}

	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if(quickTrigger || (timeCount > minDelay && prevCount != count)){
			prevCount = count;
			timeCount = 0;
		}
	}
}

