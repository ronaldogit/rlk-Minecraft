﻿using System.Collections;
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

//	public float topInsideAngle0 {
//		// get { return Mathf.Atan2 (heigth, 0.5f * width) * Mathf.Rad2Deg; } 
//		get{
//			//			Debug.Log (this.topAngle);
//			return Mathf.Atan2(0.2f * this.width, this.heigth);
//		}
//	}
//
//	public float topInsideAngle1 {
//		// get { return Mathf.Atan2 (heigth, 0.5f * width) * Mathf.Rad2Deg; } 
//		get{
//			//			Debug.Log (this.topAngle);
//			return Mathf.Atan2(0.1f * this.width, this.sideLens[5] );
//		}
//	}
//
//
//	public float topInsideAngle2 {
//		// get { return Mathf.Atan2 (heigth, 0.5f * width) * Mathf.Rad2Deg; } 
//		get{
//			//			Debug.Log (this.topAngle);
//			return Mathf.Atan2(0.1f * this.width, this.sideLens[6]);
//		}
//	}
//
//
//	public float topInsideAngle3 {
//		// get { return Mathf.Atan2 (heigth, 0.5f * width) * Mathf.Rad2Deg; } 
//		get{
//			//			Debug.Log (this.topAngle);
//			return Mathf.Atan2(0.1f * this.width, this.heigth);
//		}
//	}
//


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
//			Debug.Log ("-------------");
//			Debug.Log (Mathf.Tan (this.angle));
//			Debug.Log (this.angle);
//			Debug.Log ( this.width);
			float result = 0.5f * Mathf.Tan (this.angle) * this.width;
//			Debug.Log ("result "+ result);
			return result;}
	}

	//内边缘长
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


    //	各条边长度 纯长 不带延长的 顺序为左上斜边，右上斜边，底边，中间的边净高h，各个小边 从左侧开始，h1，h2，h3，h4
	//这个长度只有一半哟 因为构造立方体需要
    public float[] sideLens {
        get
        {
//			Debug.Log ("len=-=============");
//			Debug.Log (this.angle);
//			Debug.Log (Mathf.Tan(this.angle ));
//			Debug.Log (Mathf.Sin(this.angle));
//			Debug.Log ("heigth0" + this.heigth0);
//			Debug.Log ("leftH1" + this.leftH1);
            return new float[] {
                0.5f * (heigth0 / Mathf.Sin(this.angle)),
                0.5f * (heigth0 / Mathf.Sin(this.angle)),
                0.5f * this.width,
                0.5f * this.heigth,
                //左边的各个竖立边的长度
				0.5f * (this.heigth - this.heigth0),		                                        //4
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*1),    //5
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*2),    //6
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*3),    //7
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*4),    //8
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*4),    //9
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*3),    //10
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*2),    //11
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*1),    //12
				0.5f * (this.heigth - this.heigth0)                                             	//13
                //右边的各个竖立边长度

            };
        }
    }

	//计算各个内在斜边长度 左边9个 都需要再乘以0.5f
	public float[] sideInnerLens{
		get{ 
			return new float[] {
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[0]),
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[0]),

				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[1]),
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[1]),

				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[2]),
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[2]),

				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[3]),
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[3]),

				0.2f * 0.5f * this.width / Mathf.Cos(this.anglesInner[4]),
				0.2f * 0.5f * this.width / Mathf.Cos(this.anglesInner[4]),    //10
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[3]),    //11
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[3]),    //12
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[2]),    //13
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[2]),    //14

				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[1]),    //15
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[1]),    //16
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[0]),    //17
				0.1f * 0.5f * this.width / Mathf.Cos(this.anglesInner[0]),    //18

			};
		}
	}


	public Vector3[] sideInnerCenters{
		get{ 
			return new Vector3[]{
				new Vector3(-(0.95f * 0.5f * this.width),   0.5f * this.centerHs[0], 0f),
				new Vector3(-(0.85f * 0.5f * this.width),   0.5f * this.centerHs[0], 0f),
				new Vector3(-(0.75f * 0.5f * this.width),   0.5f * this.centerHs[1], 0f),
				new Vector3(-(0.65f * 0.5f * this.width),   0.5f * this.centerHs[1], 0f),
				new Vector3(-(0.55f * 0.5f * this.width),   0.5f * this.centerHs[2], 0f),
				new Vector3(-(0.45f * 0.5f * this.width),   0.5f * this.centerHs[2], 0f),
				new Vector3(-(0.35f * 0.5f * this.width),   0.5f * this.centerHs[3], 0f),
				new Vector3(-(0.25f * 0.5f * this.width),   0.5f * this.centerHs[3], 0f),
				new Vector3(-(0.10f * 0.5f * this.width),  0.5f * this.heigth, 0f),
				new Vector3((0.10f * 0.5f * this.width),   0.5f * this.heigth, 0f),
				new Vector3((0.25f * 0.5f * this.width),   0.5f * this.centerHs[3], 0f),
				new Vector3((0.35f * 0.5f * this.width),   0.5f * this.centerHs[3], 0f),
				new Vector3((0.45f * 0.5f * this.width),   0.5f * this.centerHs[2], 0f),
				new Vector3((0.55f * 0.5f * this.width),   0.5f * this.centerHs[2], 0f),
				new Vector3((0.65f * 0.5f * this.width),   0.5f * this.centerHs[1], 0f),
				new Vector3((0.75f * 0.5f * this.width),   0.5f * this.centerHs[1], 0f),
				new Vector3((0.85f * 0.5f * this.width),   0.5f * this.centerHs[0], 0f),
				new Vector3((0.95f * 0.5f * this.width),   0.5f * this.centerHs[0], 0f)

//				new Vector3{},
			};
		}
	}

	public float[] localInnerRotations{
		get { 
			return new float[]{
				this.anglesInner[0] * Mathf.Rad2Deg,                 //1
				360f - this.anglesInner[0] * Mathf.Rad2Deg ,         //2
				this.anglesInner[1] * Mathf.Rad2Deg,                 //3
				360f - this.anglesInner[1] * Mathf.Rad2Deg,          //4
				this.anglesInner[2] * Mathf.Rad2Deg,                 //5
				360f - this.anglesInner[2] * Mathf.Rad2Deg,          //6
				this.anglesInner[3] * Mathf.Rad2Deg,                 //7
				360f - this.anglesInner[3] * Mathf.Rad2Deg,          //8
				this.anglesInner[4] * Mathf.Rad2Deg,                 //9
				360f - this.anglesInner[4] * Mathf.Rad2Deg,          //10
				this.anglesInner[3] * Mathf.Rad2Deg,   //11
				360f - this.anglesInner[3] * Mathf.Rad2Deg,//12
				this.anglesInner[2] * Mathf.Rad2Deg,                 //13
				360f - this.anglesInner[2] * Mathf.Rad2Deg, //14
				this.anglesInner[1] * Mathf.Rad2Deg,  //15
				360f - this.anglesInner[1] * Mathf.Rad2Deg,//16
				this.anglesInner[0] * Mathf.Rad2Deg,       //17
				360f - this.anglesInner[0] * Mathf.Rad2Deg  //18
		
			};
		}
	}

	//四个边辅助线的位置

	public float[] centerHs{
		get { 
			return new float[] {
				this.heigth - this.heigth0  + 0.5f*this.width * 0.1f * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 0.5f*this.width * 0.3f * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 0.5f*this.width * 0.5f * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 0.5f*this.width * 0.7f * Mathf.Tan(this.angle)	
			};
	     }
	}




	//左边5个角度
	public float[] anglesInner{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.centerHs [0], 0.1f * 0.5f * this.width),
				Mathf.Atan2 (this.centerHs [1], 0.1f * 0.5f * this.width),
				Mathf.Atan2 (this.centerHs [2], 0.1f * 0.5f * this.width),
				Mathf.Atan2 (this.centerHs [3], 0.1f * 0.5f * this.width),
				Mathf.Atan2 (this.heigth, 0.2f * 0.5f * this.width)
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

	//中心坐标 计算平移值
	public Vector3[] centerSidePositions{
		get { 
			return new Vector3[] {
//				new Vector3 (-(0.25f * this.width + 1f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 1f* Mathf.Cos(this.angle), 0f),
				new Vector3 (-(this.sideLens[0] * Mathf.Cos(this.angle)  + CubeMeshData.yThickness * Mathf.Sin(this.angle)),  this.heigth - this.heigth0 + 0.5f * this.heigth0 + CubeMeshData.yThickness * Mathf.Cos(this.angle), 0f),
				new Vector3 ((this.sideLens[0] * Mathf.Cos(this.angle)  + CubeMeshData.yThickness * Mathf.Sin(this.angle)),  this.heigth - this.heigth0 + 0.5f * this.heigth0 + CubeMeshData.yThickness * Mathf.Cos(this.angle), 0f),

//				new Vector3 ((0.25f * this.width + 1f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 1f* Mathf.Cos(this.angle), 0f),
				new Vector3 (0f, 0f, 0f),
				new Vector3 (0f, this.heigth * 0.5f, 0f),
				new Vector3 (-0.5f* this.width,  this.sideLens[4], 0f),
				new Vector3 (-0.4f* this.width,  this.sideLens[5], 0f),
				new Vector3 (-0.3f* this.width,  this.sideLens[6], 0f),
				new Vector3 (-0.2f* this.width,  this.sideLens[7], 0f),
				new Vector3 (-0.1f* this.width,  this.sideLens[8], 0f),

				new Vector3 (0.1f* this.width,  this.sideLens[9] , 0f),
				new Vector3 (0.2f* this.width,  this.sideLens[10], 0f),
				new Vector3 (0.3f* this.width,  this.sideLens[11], 0f),
				new Vector3 (0.4f* this.width,  this.sideLens[12], 0f),
				new Vector3 (0.5f* this.width,  this.sideLens[13], 0f),

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
			return new float[]{
				this.angle * Mathf.Rad2Deg,
				360f- this.angle * Mathf.Rad2Deg,
				0f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
			};
		}
	} 

}
