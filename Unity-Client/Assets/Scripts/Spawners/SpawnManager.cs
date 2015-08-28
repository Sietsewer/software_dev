//!!INTERFACE CODE - SPAGHETTI PRONE!!\\
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

[ExecuteInEditMode()]
/// <summary>
/// Spawn manager.
/// </summary>
public class SpawnManager : MonoBehaviour {
	public ExtendedFlycam flyCam;
	public Spawner[] carSpawners;
	public Spawner[] bikeSpawners;
	public Spawner[] busSpawners;
	public Spawner[] trainSpawners;
	public Spawner[] pedSpawners;
	Spawner[] selectedSpawner;

	public SpawnRoulette sr;

	bool freeCamming;

	bool showSpawnrates = false;
	bool help = false;

	void Start () {
		selectedSpawner = carSpawners;
	}

	void setStyle(LightColourController.Colours colour){
		switch(colour){
		case LightColourController.Colours.Green:
			GUI.color = Color.green;
			break;
		case LightColourController.Colours.Orange:
			GUI.color = Color.yellow;
			break;
		case LightColourController.Colours.Red:
			GUI.color = Color.red;
			break;
		}
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (250, Screen.height - 35, 170, 20), "Free Camera")) {
			FreeCam(true);
		}

		if(!sr.enabled){
			if (GUI.Button (new Rect (50, Screen.height - 35, 170, 20), "Spawn Manager")||(Input.GetKey(KeyCode.Escape)&&showSpawnrates)) {
				showSpawnrates = !showSpawnrates;
				help = false;
			}
		} else {
			showSpawnrates = false;
			GUI.Button(new Rect (50, Screen.height - 35, 170, 20), "Spawn Roulette!");
		}

		if (GUI.Button (new Rect (50, Screen.height - 85, 170, 20), "Help (F1)")||(Input.GetKey(KeyCode.Escape))) {
			help = !help;
			showSpawnrates = false;
		}

		if (GUI.Button (new Rect (50, Screen.height - 110, 170, 20), "Quit (Esc)")||(Input.GetKey(KeyCode.Escape))) {
			Application.Quit();
		}

		if(help){
			int posx = Screen.width/2-300;
			int posy = Screen.height/2-200;
			int _posx = posx + 10;
			int _posy = posy + 10;
			GUI.Box (new Rect (posx, posy, 600, 400), "");
			GUI.Label (new Rect (_posx+20, _posy+20, 2000, 300), "F1 - Toggle help\n\tShows and hides this window.\n\nL - Toggle Labels\n\tShows and hides labels above traffic lights.\n\nSpace/Enter - Toggle freecam\n\tToggles free camera.\n\nR - Toggle random spawns\n\tDisables Spawn Manager, and spawns vehicles completely at random."+
			           "\n\nFreecam\nWASD - Cam Translation\nMouse - Cam Rotation\n Shift - Go faster");
		}

		if(showSpawnrates){
			int posx = Screen.width/2-300;
			int posy = Screen.height/2-200;
			int _posx = posx + 10;
			int _posy = posy + 10;
			GUI.Box (new Rect (posx, posy, 600, 400), "");
			//GUI.Label (new Rect (posx+10, posy+10, 100, 30), "Cars");
			int counter = 0;

			if (GUI.Button (new Rect (posx+(1*90), 35, 80, 20), "Cars")) {
				selectedSpawner = carSpawners;
			}
			if (GUI.Button (new Rect (posx+(2*90), 35, 80, 20), "Bikes")) {
				selectedSpawner = bikeSpawners;
			}
			if (GUI.Button (new Rect (posx+(3*90), 35, 80, 20), "Busses")) {
				selectedSpawner = busSpawners;
			}
			if (GUI.Button (new Rect (posx+(4*90), 35, 80, 20), "Trains")) {
				selectedSpawner = trainSpawners;
			}
			if (GUI.Button (new Rect (posx+(5*90), 35, 80, 20), "Pedestrians")) {
				selectedSpawner = pedSpawners;
			}
			foreach(Spawner s in selectedSpawner){
				GUI.Label (new Rect (_posx, _posy + (counter * 20), 200, 30), s.gameObject.name);
				if (GUI.Button (new Rect (_posx + 200, _posy + (counter * 20) + 2, 60, 15), "Spawn")) {
					s.spawn();
				}
				s.SpawnEvery = (int)GUI.HorizontalSlider (new Rect (_posx + 270, _posy + (counter * 20) + 2, 50, 15), s.SpawnEvery, 3.0F, 30.0F);
				GUI.Label(new Rect (_posx + 330, _posy + (counter * 20), 30, 20),s.SpawnEvery+"");
				s.enabled = GUI.Toggle(new Rect (_posx + 370, _posy + (counter * 20), 30, 20), s.enabled, "");
				counter++;
			}
		}
	}
	

	void FreeCam (bool freeCam){
		Cursor.visible = !freeCam;
		flyCam.enabled = freeCam;
		Screen.lockCursor = freeCam;
		showSpawnrates = false;
		freeCamming = freeCam;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetButtonUp("Cancel")){
			Application.Quit();
		}
		if( Input.GetButtonUp("Exit Freelook")){
			FreeCam (!freeCamming);
		}
		if( Input.GetButtonUp("Show Labels")){
			GlobalFlags.showLabels = !GlobalFlags.showLabels;
		}
		if( Input.GetButtonUp("Help")){
			help = !help;
			if(help){
				showSpawnrates = false;
			}
		}
		if( Input.GetButtonUp("Random Spawn")){
			sr.enabled = !sr.enabled;
		}
	}
}
