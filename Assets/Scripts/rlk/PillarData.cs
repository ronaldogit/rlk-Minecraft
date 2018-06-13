using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarData {
	public Vector3 position;
	public float width;
	public float heigth;
	public float angle {
		get { return Mathf.Atan2 (heigth, 0.5f * width) * Mathf.Rad2Deg; } 
	}

	public PillarData(float w, float h){
		width = w;
		heigth = h;
	}
	public Vector3[] vertices{
		get { return new Vector3[] {
				new Vector3(-0.5f*width,0f,0f), //左下
				new Vector3(0, 0.5f*heigth, 0f), //顶上
				new Vector3(0.5f*width,0f,0f)     //右下
			};
		}
	}

    public float[] sideLens {
        get
        {
            return new float[] {
                0.5f * width,
                0.5f * heigth,
                0.5f * heigth
            };
        }
    }


	public Vector3[] centerSidePositions{
		get { 
			return new Vector3[] {
				new Vector3 (-0.25f * width, 0.5f * heigth, 0f),
				new Vector3 (0.25f * width, 0.5f * heigth, 0f),
				new Vector3 (0f, 0f, 0f)
			};
		}
	}


	public Vector3 localCenterPosition{
		get{ return Vector3.zero;}
	}


}
