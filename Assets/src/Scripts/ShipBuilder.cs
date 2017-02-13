using System;
using UnityEngine;
using AssemblyCSharp;

public class ShipBuilder : MonoBehaviour
{
	private AssemblyCSharp.Cursor cursor;

	void Start() {
		var obj = Instantiate (Resources.Load ("Prefabs/cursor") as GameObject);
		cursor = obj.GetComponent<AssemblyCSharp.Cursor> ();
	}

	void Update() {
		if (Ship.playerShip != null) {
			cursor.SetValid (getCoordValid ());
		}
	}

	bool getCoordValid() {
		var ship = Ship.playerShip;
		var coords = cursor.coord.NeighbourCoords ();

		foreach (var c in coords) {
			if (ship.chunks.Has (c.x, c.y, c.z)) {
				return true;
			}
		}

		return false;
	}
}
