using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AssemblyCSharp;

public class Game : MonoBehaviour {
	private GameState gameState = new GameState();

	void Start() {
		// Init game state

		initGameState ();
	}

	void initGameState() {
		var savePath = Application.persistentDataPath + "/save";

		FileStream stream;

		var formatter = new BinaryFormatter ();

		if (!File.Exists (savePath)) {
			stream = File.Create (savePath);
			formatter.Serialize (stream, gameState);
			stream.Close ();
		} else {
			stream = File.OpenRead (savePath);
			gameState = (GameState)formatter.Deserialize (stream);
			stream.Close ();
		}
			
		var shipObject = Instantiate (Resources.Load ("Prefabs/ship", typeof(GameObject)) as GameObject);
		var ship = shipObject.GetComponent<Ship> ();
		ship.Load (gameState.shipData);

		Ship.playerShip = ship;
	}

	void Update() {
	}
}