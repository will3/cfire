using System;
using System.Collections.Generic;
using UnityEngine;
using Cubiquity;

namespace AssemblyCSharp
{
	[Serializable]
	public class Voxel
	{
		public Vector3i coord;
		public int[] textureIds = new [] { 0, 0, 0, 0, 0, 0 }; // Left, right, down, top, back forward
		public bool transparent;
		public int up; // Up direction
	}
}

