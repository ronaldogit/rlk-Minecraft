using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedualPillar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PillarData p = new PillarData (2f,1f);
		Debug.Log ("angle" + p.angle +"\n" + 
			"centerPositions"	+ p.centerSidePositions[0] +"\n"
			+ "position" + p.localCenterPosition );
		MakeCube (1f, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	public Mesh MakeFace(int dir, float scale, Vector3 pos){
//		List<Vector3> vertices;
////		vertices.AddRange (CubeMeshData.faceVertices (dir, scale, pos));
//		int vCount = vertices.Count;
//		List<int> triangles;
//		triangles.Add (vCount -4 + 0);
//		triangles.Add (vCount -4 + 1);
//		triangles.Add (vCount -4 + 2);
//		triangles.Add (vCount -4 + 0);
//		triangles.Add (vCount -4 + 2);
//		triangles.Add (vCount -4 + 3);
//		Mesh mesh = new Mesh ();
//		mesh.Clear ();
//		mesh.vertices = vertices.ToArray ();
//		mesh.triangles = triangles.ToArray ();
//		mesh.RecalculateNormals ();
//		return mesh;
//	}
	public GameObject MakeCube(float scale, Vector3 pos){
		GameObject go = new GameObject ("ga", params[MeshFilter, MeshRenderer]);
		Mesh mesh = go.GetComponent<MeshFilter> ().mesh;
//		mesh.triangles = 
//	    mesh.vertices = mesh 
		List<Vector3> vertices = new List<Vector3> ();
		List<int> triangles = new List<int> ();
		for (int i = 0; i < 6; i++) {
//			MakeFace (i, scale, pos);
			vertices.AddRange (CubeMeshData.faceVertices (i, scale, pos));
			int vCount = vertices.Count;
			triangles.Add (vCount -4 + 0);
			triangles.Add (vCount -4 + 1);
			triangles.Add (vCount -4 + 2);
			triangles.Add (vCount -4 + 0);
			triangles.Add (vCount -4 + 2);
			triangles.Add (vCount -4 + 3);
		}
		mesh.Clear ();
		mesh.vertices = vertices.ToArray ();
		mesh.triangles = triangles.ToArray ();
		mesh.RecalculateNormals ();
		return go;
	}
}
