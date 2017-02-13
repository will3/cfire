using System;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AssemblyCSharp;

public class Game : MonoBehaviour {
	private static Game instance;
	public static Game Instance {
		get {
			return instance;
		}
	}

	private Game() {
		instance = this;
	}

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

	public void Save() {
		gameState.shipData = Ship.playerShip.chunks.Save ();

		var savePath = Application.persistentDataPath + "/save";
		var formatter = new BinaryFormatter ();
	
		var stream = File.Create (savePath);
		formatter.Serialize (stream, gameState);
		stream.Close ();
	}

	void Update() {
	}
}