using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarData {
	public Vector3 position;
	public float width;
	public float heigth;
	public float topAngle;
	public float angle {
		// get { return Mathf.Atan2 (heigth, 0.5f * width) * Mathf.Rad2Deg; } 
		get{
//			Debug.Log (this.topAngle);
			return (90f - 0.5f* this.topAngle) * Mathf.Deg2Rad ;
		}
	}

	//左边那个最矮的高度
	public float leftH1 
	{
		get{ return this.heigth - 0.5f* Mathf.Tan(this.angle) * this.width;
		}
	}

	//中间那个净高
	public float heigth0 
	{
		get{	
			Debug.Log ("-------------");
			Debug.Log (Mathf.Tan (this.angle));
			Debug.Log (this.angle);
			Debug.Log ( this.width);
			float result = 0.5f * Mathf.Tan (this.angle) * this.width;
			Debug.Log ("result "+ result);
			return result;}
	}

	//内长
	public PillarData(float w, float h, float topAngle){
		this.width = w;
		this.heigth = h;
		this.topAngle = topAngle;
	}
	//三个顶点坐标 左下 最上 右下
	public Vector3[] vertices{
		get { return new Vector3[] {
				new Vector3(-0.5f*width,0f + leftH1 ,0f), //左下
				new Vector3(0, this.heigth, 0f), //顶上
				new Vector3(0.5f*width,0f + leftH1, 0f)     //右下
			};
		}
	}

// //	三条边半长
//     public float[] sideLens {
//         get
//         {
// 			Debug.Log (this.angle);
// //			Debug.Log (Mathf.Sin(this.angle));
// 			Debug.Log (Mathf.Sin(this.angle));
// 			return new float[] {
// 				0.5f * (heigth0 / Mathf.Sin(this.angle) + 1f / Mathf.Tan(this.angle) + Mathf.Tan(this.angle)) ,
// 				0.5f * (heigth0 / Mathf.Sin(this.angle) + 1f / Mathf.Tan(this.angle) + Mathf.Tan(this.angle)),
// 				0.5f * width,
//             };
//         }
//     }


	//	三条边半长 纯长 不带延长的
    public float[] sideLens {
        get
        {
			Debug.Log ("len=-=============");
			Debug.Log (this.angle);
			Debug.Log (Mathf.Tan(this.angle ));
			Debug.Log (Mathf.Sin(this.angle));
			Debug.Log ("heigth0" + this.heigth0);
			Debug.Log ("leftH1" + this.leftH1);
			return new float[] {
				0.5f * (heigth0 / Mathf.Sin(this.angle)) ,
				0.5f * (heigth0 / Mathf.Sin(this.angle)),
				0.5f * this.width,
				0.5f * this.heigth,
            };
        }
    }

	public float widthOutSide{
		get { 
			return this.width + 2 * (1 / Mathf.Sin (this.angle));
			}
	}

	public float heigthOutSide{
		get { 
			return this.heigth + (1 / Mathf.Cos(this.angle));
		}
	}


//	public Vector3[] centerSidePositions{
//		get { 
//			return new Vector3[] {
//				new Vector3 (-(0.25f * this.width + 0.5f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 0.5f* Mathf.Cos(this.angle), 0f),
//				new Vector3 ((0.25f * this.width + 0.5f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 0.5f* Mathf.Cos(this.angle), 0f),
//				new Vector3 (0f, 0f, 0f)
//			};
//		}
//	}


	public Vector3[] centerSidePositions{
		get { 
			return new Vector3[] {
				new Vector3 (-(0.25f * this.width + 1f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 1f* Mathf.Cos(this.angle), 0f),
				new Vector3 ((0.25f * this.width + 1f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 1f* Mathf.Cos(this.angle), 0f),
				new Vector3 (0f, 0f, 0f),
				new Vector3 (0f,  this.heigth * 0.5f, 0f)
			};
		}
	}



//	public Vector3[] centerSidePositions{
//		get { 
//			float x = (sideLens[0] - 0.5f * Mathf.Tan (angle)) * Mathf.Cos (angle);
//			return new Vector3[] {
//				new Vector3 (-x, this.heigthOut - x * Mathf.Tan(angle) - 0.5f/Mathf.Cos(angle) , 0f),
//				new Vector3 ( x, this.heigthOut - x * Mathf.Tan(angle) - 0.5f/Mathf.Cos(angle) , 0f),
//				new Vector3 (0f, 0f, 0f)
//			};
//		}
//	}

	// public Vector3[] centerSidePositions{
	// 	get { 
	// 		float x = (sideLens[0] - 0.5f * Mathf.Tan (angle)) * Mathf.Cos (angle);
	// 		return new Vector3[] {
	// 			new Vector3 (- (0.25f * width + 0.5f*Mathf.Sin(angle)) , 0.5f * heigth + 0.5f * Mathf.Cos(angle) , 0f),
	// 			new Vector3 ( (0.25f * width + 0.5f*Mathf.Sin(angle)) , 0.5f * heigth + 0.5f * Mathf.Cos(angle) , 0f),
	// 			new Vector3 (0f, 0f, 0f)
	// 		};
	// 	}
	// }


	public Vector3 localCenterPosition{
		get{ return Vector3.zero;}
	}
		

	public float[] localRotations {
		get{ 
			return new float[]{this.angle * Mathf.Rad2Deg, 360f- this.angle * Mathf.Rad2Deg, 0f, 90f};
		}
	} 

}
