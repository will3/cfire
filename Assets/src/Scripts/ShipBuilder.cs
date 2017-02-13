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
		var ship = Ship.playerShip;
		if (ship != null) {
			cursor.SetValid (getCoordValid ());

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				var v = new Voxel ();
				var coord = cursor.coord;
				ship.chunks.Set(coord.x, coord.y, coord.z, v);
				Game.Instance.Save ();
			}
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
