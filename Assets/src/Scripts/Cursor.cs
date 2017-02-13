using System;
using UnityEngine;
using Cubiquity;

namespace AssemblyCSharp
{
	public class Cursor : MonoBehaviour
	{
		private Material cursorMaterial;
		private Material cursorInvalidMaterial;
		private LineRenderer lineRenderer;

		private bool valid;
		private Vector3i _coord;
		public Vector3i coord {
			get {
				return _coord;
			}
		}

		public void SetValid(bool valid) {
			if (this.valid != valid) {
				this.valid = valid;
				lineRenderer.sharedMaterial = valid ? cursorMaterial : cursorInvalidMaterial;
			}
		}

		void Start() {
			lineRenderer = GetComponent<LineRenderer> ();

			cursorInvalidMaterial = Resources.Load ("Materials/cursor-invalid") as Material;
			cursorMaterial = Resources.Load ("Materials/cursor") as Material;

			var offset = new Vector3 (-0.5f, -0.5f, -0.5f);
			var a = new Vector3 (0, 0, 0) + offset;
			var b = new Vector3 (1, 0, 0) + offset;
			var c = new Vector3 (1, 0, 1) + offset;
			var d = new Vector3 (0, 0, 1) + offset;

			var e = new Vector3 (0, 1, 0) + offset;
			var f = new Vector3 (1, 1, 0) + offset;
			var g = new Vector3 (1, 1, 1) + offset;
			var h = new Vector3 (0, 1, 1) + offset;

			var points = new [] {
				a, e, a, b, f, b, c, g, c, d, h, d, a, e, f, g, h, e
			};

			lineRenderer.numPositions = points.Length;

			lineRenderer.SetPositions (points);

			lineRenderer.sharedMaterial = cursorMaterial;
		}

		void Update() {
			var camera = Camera.main;
			var ray = camera.ScreenPointToRay(Input.mousePosition);

			RaycastHit hitInfo;
			if (Physics.Raycast (ray, out hitInfo, Mathf.Infinity)) {
				var point = hitInfo.point + (camera.transform.position - hitInfo.point).normalized * 0.01f;
				var coord = new Vector3i (
					            (int)Math.Round (point.x),
					            (int)Math.Round (point.y),
					            (int)Math.Round (point.z));
				transform.position = coord.to_f();
				_coord = coord;
			}
		}
	}
}

