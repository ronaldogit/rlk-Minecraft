using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedualPillar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PillarData p = new PillarData (20f,10f,120f);
		Debug.Log ("angle" + p.angle +"\n" + 
			"centerPositions"	+ p.centerSidePositions[0] +"\n"
			+ "position" + p.localCenterPosition );
        //MakeCube (1f, Vector3.zero);

        foreach (float len in p.sideLens){
			Debug.Log ("len==" + len);
        }

        for (int i = 0; i < p.sideLens.Length; i++)
        {
            float len = (float)p.sideLens[i];
			Debug.Log ("len " + len + " i=  " + i);
            GameObject go =MakeCube(len, Vector3.zero);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + p.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, p.localRotations[i]);
        }
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
	public GameObject MakeCube(float scale, Vector3 localPos){
        Debug.Log(localPos);
		GameObject go = new GameObject("game");
		go.AddComponent<MeshFilter> ();
		MeshRenderer render =  go.AddComponent<MeshRenderer>();
        //render.material.shader =  ;
        render.material.color = Color.white;


		Mesh mesh = go.GetComponent<MeshFilter> ().mesh;
		//mesh.triangles = 
		//mesh.vertices = mesh 
		List<Vector3> vertices = new List<Vector3> ();
		List<int> triangles = new List<int> ();
		for (int i = 0; i < 6; i++) {
			//MakeFace (i, scale, pos);
			//vertices.AddRange (CubeMeshData.faceVertices (i, scale, localPos));
            vertices.AddRange(CubeMeshData.faceVertices3(i, scale, localPos));
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
        //Debug.Log(go.GetComponent<MeshCollider>().bounds);
		return go;
	}
}