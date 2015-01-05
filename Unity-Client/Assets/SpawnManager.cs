using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class SpawnManager : MonoBehaviour {
	public ExtendedFlycam flyCam;
	public Spawner[] car;
	public Spawner[] bike;
	public Spawner[] bus;
	public Spawner[] train;
	public Spawner[] ped;
	bool showTab = false;
	Spawner[] selected;

	void Start () {
		selected = car;
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (50, Screen.height - 35, 170, 20), "Spawn Manager")) {
			showTab = !showTab;
		}
		if(showTab){
			Screen.showCursor = true;
			flyCam.enabled = false;
			int posx = Screen.width/2-300;
			int posy = Screen.height/2-200;
			int _posx = posx + 10;
			int _posy = posy + 10;
			GUI.Box (new Rect (posx, posy, 600, 400), "");
			//GUI.Label (new Rect (posx+10, posy+10, 100, 30), "Cars");
			int counter = 0;

			if (GUI.Button (new Rect (posx+90, 35, 80, 20), "Cars")) {
				selected = car;
			}
			if (GUI.Button (new Rect (posx+90+90, 35, 80, 20), "Bikes")) {
				selected = bike;
			}
			if (GUI.Button (new Rect (posx+90+90+90, 35, 80, 20), "Busses")) {
				selected = bus;
			}
			if (GUI.Button (new Rect (posx+90+90+90+90, 35, 80, 20), "Trains")) {
				selected = train;
			}
			if (GUI.Button (new Rect (posx+90+90+90+90+90, 35, 80, 20), "Pedestrians")) {
				selected = ped;
			}
			foreach(Spawner s in selected){
				GUI.Label (new Rect (_posx, _posy + (counter * 20), 200, 30), s.gameObject.name);
				if (GUI.Button (new Rect (_posx + 200, _posy + (counter * 20) + 2, 60, 15), "Spawn")) {
					s.spawn();
				}
				s.SpawnEvery = (int)GUI.HorizontalSlider (new Rect (_posx + 270, _posy + (counter * 20) + 2, 50, 15), s.SpawnEvery, 3.0F, 30.0F);
				GUI.Label(new Rect (_posx + 330, _posy + (counter * 20), 30, 20),s.SpawnEvery+"");
				s.enabled = GUI.Toggle(new Rect (_posx + 370, _posy + (counter * 20), 30, 20), s.enabled, "");
				counter++;
			}
		}else{
			Screen.showCursor = false;
			flyCam.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
