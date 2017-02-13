using System;
using Cubiquity;

namespace AssemblyCSharp
{
	[Serializable]
	public class GameState {
		public ChunkData shipData = new ChunkData();

		public GameState() {
			var coord = new Vector3i (0, 0, 0);
			var voxel = new Voxel ();
			voxel.coord = coord;
			voxel.textureIds = new [] { 0, 0, 0, 0, 0, 0 };
			shipData.data [coord] = voxel;
		}
	}
}

