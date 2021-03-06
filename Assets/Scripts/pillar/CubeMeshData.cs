﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubeMeshData {
	public static float xThickness = 1f;    //柱子
	public static float yThickness = 0.05f;
	public static float zThickness = 0.2f;

//	public static float xThickness = 1f;    //柱子
//	public static float yThickness = 0.5f;
//	public static float zThickness = 0.1f;

	// public static Vector3 [] vertices = {
	// 	new Vector3( 1, 1f*yThickness, 		1f*zThickness),
	// 	new Vector3( -1, 1f*yThickness, 	1f*zThickness),
	// 	new Vector3( -1, -1f*yThickness,	1f*zThickness),
	// 	new Vector3( 1, -1f*yThickness, 	1f*zThickness),
	// 	new Vector3(-1, 1f*yThickness,     -1f*zThickness),
	// 	new Vector3(1, 1f*yThickness,      -1f*zThickness),
	// 	new Vector3(1, -1f*yThickness, 	   -1f*zThickness),
	// 	new Vector3(-1, -1f*yThickness,    -1f*zThickness),

	// };

	public static Vector3[] vertices(){
		Vector3[] fv = new Vector3[8];
		fv[0]	= new Vector3 (1, 1f * yThickness, 1f * zThickness);
		fv[1]	=	new Vector3 (-1, 1f * yThickness, 1f * zThickness);
		fv[2]	=	new Vector3 (-1, -1f * yThickness,	1f * zThickness);
		fv[3]	=	new Vector3( 1, -1f*yThickness, 	1f*zThickness);
		fv[4]	=	new Vector3 (-1, 1f * yThickness, -1f * zThickness);
		fv[5]	=	new Vector3 (1, 1f * yThickness, -1f * zThickness);
		fv[6]	=	new Vector3 (1, -1f * yThickness, -1f * zThickness);
		fv[7]	=	new Vector3 (-1, -1f * yThickness, -1f * zThickness);
		return fv;
	}

	//can be seen
	public static int[][] faceTriangles = {
		new int[]{0,1,2,3},
		new int[]{5,0,3,6},
		new int[]{4,5,6,7},
		new int[]{1,4,7,2},
		new int[]{5,4,1,0},
		new int[]{3,2,7,6},
	};

	public static Vector3[] faceVertices(int dir, float scale, Vector3 pos){
//		Debug.Log ("scale," + scale + "===========pos:" + pos);
		Vector3[] fv = new Vector3[4];
		for (int i = 0; i < fv.Length; i++) {
			fv [i] = (CubeMeshData.vertices()[faceTriangles[dir][i]] * scale) + pos;
		}
		return fv;
	}


    public static Vector3[] faceVertices3(int dir, float scale, Vector3 pos)
    {
//        Debug.Log("scale," + scale + "===========pos:" + pos);
        Vector3[] fv = new Vector3[4];
        for (int i = 0; i < fv.Length; i++)
        {
            //fv[i] = (vertices[faceTriangles[dir][i]] * scale) + pos;
			fv[i].x = (CubeMeshData.vertices()[faceTriangles[dir][i]].x * scale) + pos.x;
			fv[i].y = (CubeMeshData.vertices()[faceTriangles[dir][i]].y * 1f) + pos.y;
			fv[i].z = (CubeMeshData.vertices()[faceTriangles[dir][i]].z * 1f) + pos.z;
        }
        return fv;
    }


	public static Vector3[] faceVerticesWithOffset(int dir, float lenScale, Vector3 pos, int[] offsetIndex =null, float[] offsets  = null )
    {
////        Debug.Log("scale," + scale + "===========pos:" + pos);
//        Vector3[] fv = new Vector3[4];
//        for (int i = 0; i < fv.Length; i++)
//        {
//        	if(faceTriangles[dir][i] == 0 || faceTriangles[dir][i] ==5){
//        		fv[i].x = (CubeMeshData.vertices()[faceTriangles[dir][i]].x * scale) + pos.x +  ;
//						fv[i].y = (CubeMeshData.vertices()[faceTriangles[dir][i]].y * 1f) + pos.y;
//						fv[i].z = (CubeMeshData.vertices()[faceTriangles[dir][i]].z * 1f) + pos.z;
//        	}else{
//        		fv[i].x = (CubeMeshData.vertices()[faceTriangles[dir][i]].x * scale) + pos.x;
//						fv[i].y = (CubeMeshData.vertices()[faceTriangles[dir][i]].y * 1f) + pos.y;
//						fv[i].z = (CubeMeshData.vertices()[faceTriangles[dir][i]].z * 1f) + pos.z;
//        	}
//        }
//
		//        Debug.Log("scale," + scale + "===========pos:" + pos);
		Vector3[] fv = new Vector3[4];
		for (int i = 0; i < fv.Length; i++)
		{
			//fv[i] = (vertices[faceTriangles[dir][i]] * scale) + pos;
			fv[i].x = (CubeMeshData.vertices()[faceTriangles[dir][i]].x * lenScale) + pos.x;
			fv[i].y = (CubeMeshData.vertices()[faceTriangles[dir][i]].y * 1f) + pos.y;
			fv[i].z = (CubeMeshData.vertices()[faceTriangles[dir][i]].z * 1f) + pos.z;

			if (offsets != null && offsets.Length > 0) {
				for (int j = 0; j < offsets.Length; j++) {
					//				fv [i].x += offsets[i]; 
					if(faceTriangles[dir][i] == offsetIndex[j]){
//						Debug.Log( offsetIndex[j]);
						fv [i].x += offsets [j];
					}
				}
			}

		}
//		if (offsets != null && offsets.Length > 0) {
//			for (int i = 0; i < offsets.Length; i++) {
////				fv [i].x += offsets[i]; 
//			}
//		}
        return fv;
    }


    public static Vector3[] faceVertices(Direction dir, float scale, Vector3 pos){
		return faceVertices((int)dir, scale, pos);
	}
}