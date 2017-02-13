using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class Ship : MonoBehaviour {
	public Chunks chunks;
	public static Ship playerShip;

	// Use this for initialization
	void Start () {
		
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	public void Load(ChunkData data) {
		chunks.Load (data);
	}
}
