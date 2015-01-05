using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnRoulette : MonoBehaviour {
	public Spawner[] pool;
	public float delay = 1.0f;
	private float countUp;
	// Use this for initialization
	void Start () {
		pool = Object.FindObjectsOfType(typeof(Spawner)) as Spawner[];
		foreach(Spawner s in pool){
			s.selfSpawn = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		countUp += Time.deltaTime;
		if(countUp > delay){
			Spawner s = pool[Random.Range( 0, pool.Length )];
			if(s.maxAlive > s.alive) s.spawn();
			countUp = 0;
		}
	}
}
