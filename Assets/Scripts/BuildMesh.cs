using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		Mesh mesh = gameObject.GetComponent<Mesh> ();Mesh
		MeshFilter mf = gameObject.GetComponent<MeshFilter> ();
		Mesh mesh = mf.mesh;

//		vertices
		Vector3 [] vertices = new Vector3[]{
			new Vector3(0,1,0), 
			new Vector3(1,1,0),
			new Vector3(1,0,0),
			new Vector3(0,0,0),
		};

//		triangles
		int[] triangles = new int[] {
			0, 1, 2,
			2, 3, 0
		};
//		uvs 

		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
