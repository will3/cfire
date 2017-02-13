using System;
using UnityEngine;
using Cubiquity;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	[Serializable]
	public class ChunkData
	{
		public Dictionary<Vector3i, Voxel> data = new Dictionary<Vector3i, Voxel>();
		public int size = 16;
	}
}

