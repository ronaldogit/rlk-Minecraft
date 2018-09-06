using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcedualPillar : MonoBehaviour 
{
	public GameObject Panel_Pillar;
	public InputField Pillar_InputField_w;
	public InputField Pillar_InputField_h1;
	public InputField Pillar_InputField_h2;
	public InputField Pillar_InputField_jw;
	public InputField Pillar_InputField_jh;
	public InputField Pillar_InputField_slnum;
	public InputField Pillar_InputField_gjposition;
	public InputField Pillar_InputField_gjnum;
	private float Pillar_w;
	private float Pillar_h1;
	private float Pillar_h2;
	private float Pillar_jw;
	private float Pillar_jh;
	private int Pillar_slnum;
	private Vector3 Pillar_gjposition;
	private int Pillar_gjnum;

	// Use this for initialization
	void Start() 
	{
		print("------ProcedualPillar-------");

		RLKUtility.Room_pillar = new GameObject("room_pillar");

		Pillar_InputField_w.text = RLKUtility.Pillar_init_w.ToString();
		Pillar_InputField_h1.text = RLKUtility.Pillar_init_h1.ToString();
		Pillar_InputField_h2.text = RLKUtility.Pillar_init_h2.ToString();
		Pillar_InputField_jw.text = RLKUtility.Pillar_init_jw.ToString();
		Pillar_InputField_jh.text = RLKUtility.Pillar_init_jh.ToString();
		Pillar_InputField_slnum.text = RLKUtility.Pillar_init_slnum.ToString();
		Pillar_InputField_gjposition.text = RLKUtility.Pillar_init_gjposition;
		Pillar_InputField_gjnum.text = RLKUtility.Pillar_init_gjnum.ToString();

		Pillar_w = float.Parse(Pillar_InputField_w.text);
		Pillar_h1 = float.Parse(Pillar_InputField_h1.text);
		Pillar_h2 = float.Parse(Pillar_InputField_h2.text);
		Pillar_jw = float.Parse(Pillar_InputField_jw.text);
		Pillar_jh = float.Parse(Pillar_InputField_jh.text);
		Pillar_slnum = int.Parse(Pillar_InputField_slnum.text);
		Pillar_gjposition = ConvertStrToVector3(Pillar_InputField_gjposition.text);
		Pillar_gjnum = int.Parse(Pillar_InputField_gjnum.text);
    }
		
	private Vector3 ConvertStrToVector3(string strVector3)
	{
		strVector3 = strVector3.Substring(1,strVector3.Length-2);
		string[] sArray = strVector3.Split (',');
		Vector3 v = new Vector3(float.Parse(sArray[0]), float.Parse(sArray[1]), float.Parse(sArray[2]));
		return v;	
	}

	public void ShowPillarPanel()
	{
		if(Panel_Pillar.activeSelf)
		{
			Panel_Pillar.SetActive(false);
		}
		else
		{
			Pillar_InputField_w.text = Pillar_w.ToString();
			Pillar_InputField_h1.text = Pillar_h1.ToString();
			Pillar_InputField_h2.text = Pillar_h2.ToString();
			Pillar_InputField_jw.text = Pillar_jw.ToString();
			Pillar_InputField_jh.text = Pillar_jh.ToString();
			Pillar_InputField_slnum.text = Pillar_slnum.ToString();
			Pillar_InputField_gjposition.text = Pillar_gjposition.ToString();
			Pillar_InputField_gjnum.text = Pillar_gjnum.ToString();


			Panel_Pillar.SetActive(true);
		}
	}

	public void HidePillarPanel () {
		Panel_Pillar.SetActive(false);
	}

	public void DrawPillar()
	{
		Pillar_w = float.Parse(Pillar_InputField_w.text);
		Pillar_h1 = float.Parse(Pillar_InputField_h1.text);
		Pillar_h2 = float.Parse(Pillar_InputField_h2.text);
		Pillar_jw = float.Parse(Pillar_InputField_jw.text);
		Pillar_jh = float.Parse(Pillar_InputField_jh.text);
		Pillar_slnum = int.Parse(Pillar_InputField_slnum.text);
		Pillar_gjposition = ConvertStrToVector3(Pillar_InputField_gjposition.text);
		Pillar_gjnum = int.Parse(Pillar_InputField_gjnum.text);

		CubeMeshData.yThickness = 0.5f * Pillar_jh;
		CubeMeshData.zThickness = 0.5f * Pillar_jw;
		foreach(Transform child in RLKUtility.Room_pillar.transform)
		{
			Destroy(child.gameObject);
		}
		Resources.UnloadUnusedAssets();

//		PillarData p = new PillarData (12f,1f,2f);
		PillarData p = new PillarData (Pillar_w,Pillar_h1,Pillar_h2);

		p.draw ();		
	}


    void Update () {
    
	}
		
	public GameObject MakeCube(float scale, Vector3 localPos){
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