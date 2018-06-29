using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour {
	Mesh mesh;
	List<Vector3> vertices;
	List<int> triangles;
	float scale=1;
	float xPos=0f, yPos=0f, zPos=0f;

	void Awake(){
		mesh = GetComponent<MeshFilter> ().mesh;
	}

	// Use this for initialization
	void Start () {
		MakeCube (scale, new Vector3(xPos, yPos, zPos));
		UpdateMesh ();
	}

	void MakeCube(float scale, Vector3 pos){
		vertices = new List<Vector3> ();
		triangles = new List<int> ();
		for (int i = 0; i < 6; i++) {
			MakeFace (i, scale, pos);
		}
	}

	void MakeFace(int dir, float scale, Vector3 pos){
		vertices.AddRange (CubeMeshData.faceVertices (dir, scale, pos));
		print (dir);
		int vCount = vertices.Count;

		print (vCount);
		triangles.Add (vCount -4 + 0);
		triangles.Add (vCount -4 + 1);
		triangles.Add (vCount -4 + 2);
		triangles.Add (vCount -4 + 0);
		triangles.Add (vCount -4 + 2);
		triangles.Add (vCount -4 + 3);
	

//		triangles.Add (vCount -4);
//		triangles.Add (vCount -4 + 1);
//		triangles.Add (vCount -4 + 2);
//		triangles.Add (vCount -4);
//		triangles.Add (vCount -4 + 2);
//		triangles.Add (vCount -4 + 3);


	}

	void UpdateMesh(){
		mesh.Clear ();
		mesh.vertices = vertices.ToArray ();
		mesh.triangles = triangles.ToArray ();
		mesh.RecalculateNormals ();
	}


	// Update is called once per frame
	void Update () {
		
	}
}