using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralGrid : MonoBehaviour {
	Mesh mesh;
	Vector3[] vertices;
	int[] triangles;

	//grid settings
	public float cellSize = 1;
	public Vector3 gridOffset;
	public int gridSize;

	void Awake()
	{
		mesh = GetComponent<MeshFilter>().mesh;
	}

	// Use this for initialization
	void Start () {
//		MakeDiscreteProceduralGrid();
		MakeContiguousProceduralGrid();
		UpdateMesh ();
	}

	void UpdateMesh()
	{
		mesh.Clear ();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();
	}

	void MakeDiscreteProceduralGrid()
	{
		//set array sizes
		vertices = new Vector3[gridSize * gridSize * 4];
		triangles = new int[gridSize * gridSize * 6];
		//set vertex offset
		//populate the vertices and triangles arrays
		int v = 0;
		int t = 0;
		float vertexOffset = cellSize * 0.5f;

		for(int x = 0; x < gridSize; x++)
		{
			for (int y = 0; y < gridSize; y++) 
			{

				//set vertex offset
//				float vertexOffset = cellSize * 0.5f;
				Vector3 cellOffset = new Vector3(x*cellSize, 0, y*cellSize);
				vertices [v] = new Vector3 (-vertexOffset,  0,  -vertexOffset) +cellOffset + gridOffset;
				vertices [v+1] = new Vector3 (-vertexOffset,  0,   vertexOffset) +cellOffset + gridOffset;
				vertices [v+2] = new Vector3 ( vertexOffset,  0,  vertexOffset) +cellOffset + gridOffset;
				vertices [v+3] = new Vector3 ( vertexOffset, 0,  -vertexOffset) +cellOffset + gridOffset;

				triangles [t+0] = v+0;
				triangles [t+1] = v+1;
				triangles [t+2] = v+2;
				triangles [t+3] = v+2;
				triangles [t+4] = v+3;
				triangles [t+5] = v+0;	

				v += 4;
				t += 6;
			}
		}

//		//set vertex offset
//		float vertexOffset = cellSize * 0.5f;
//		vertices [0] = new Vector3 (-vertexOffset,  0,  -vertexOffset) + gridOffset;
//		vertices [1] = new Vector3 (-vertexOffset,  0,   vertexOffset) + gridOffset;
//		vertices [2] = new Vector3 ( vertexOffset,  0,  vertexOffset) + gridOffset;
//		vertices [3] = new Vector3 ( vertexOffset,  0,  -vertexOffset) + gridOffset;
//
//		triangles [0] = 0;
//		triangles [1] = 1;
//		triangles [2] = 2;
//		triangles [3] = 2;
//		triangles [4] = 3;
//		triangles [5] = 0;
//
	}


	void MakeContiguousProceduralGrid()
	{

		//set array size
		vertices = new Vector3[(gridSize + 1) * (gridSize + 1)];
		triangles = new int[gridSize * gridSize * 6];

		int v = 0;
		int t = 0;

		//set vertex offset
		float vertexOffset = cellSize * 0.5f;
		for (int x = 0; x <= gridSize; x++) {
			for (int y = 0; y <= gridSize; y++) {
				vertices [v] = new Vector3 ((x * cellSize) - vertexOffset, (x+y)*0.2f, (y * cellSize) - vertexOffset);
				v++;
			}
		}


		//reset vertex tracker
		v = 0;
		//setting each cell's triangles
		for(int x = 0; x < gridSize; x++){
			for (int y = 0; y < gridSize; y++) {
				triangles [t] = v;
				triangles [t + 1] = v + 1;
				triangles [t + 2] = v + gridSize + 1;
				triangles [t + 3] = v + 1;
				triangles [t + 4] = v + gridSize + 2;
				triangles [t + 5] = v + gridSize + 1;
				v++;
				t += 6; 
			}
			v++;
		}



	}

	// Update is called once per frame
		void Update () {
		
	}
}
