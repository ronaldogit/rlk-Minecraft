﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarData {
	public Vector3 position;
	public float width;  //宽度
	public float heigth;  //高度
	public float topAngle; //顶角
	//左上底部斜角
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
	//w:钢架宽； h:钢架高； topAngle:顶角
//	public PillarData(float w, float h, float topAngle){
//		this.width = w;
//		this.heigth = h;
//		this.topAngle = topAngle;
//	}

	//w:钢架宽； h1:钢架边高1； h2:钢架边高2 h1下面 h2上面
	public PillarData(float w, float h1, float h2){
		this.width = w;
		this.heigth = h1+h2;
		this.topAngle = 2f * Mathf.Atan((0.5f*w)/h2) * Mathf.Rad2Deg;
	}


	//三个顶点坐标 左下 最上 右下
	public Vector3[] vertices{
		get { return new Vector3[] {
				new Vector3(-0.5f*width, 0f + leftH1, 0f), //左下
				new Vector3(0, this.heigth, 0f), //顶上
				new Vector3(0.5f*width, 0f + leftH1, 0f)     //右下
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
				//右边的各个竖立边长度
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*4),    //9
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*3),    //10
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*2),    //11
				0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*1),    //12
				0.5f * (this.heigth - this.heigth0)                                             	//13
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
				// new Vector3(-(0.95f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[0], 0f),
				// new Vector3(-(0.85f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[0], 0f),
				// new Vector3(-(0.75f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[1], 0f),
				// new Vector3(-(0.65f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[1], 0f),
				// new Vector3(-(0.55f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[2], 0f),
				// new Vector3(-(0.45f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[2], 0f),
				// new Vector3(-(0.35f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[3], 0f),
				// new Vector3(-(0.25f * 0.5f * this.width) + CubeMeshData.yThickness,   0.5f * this.centerHs[3], 0f),
				// new Vector3(-(0.10f * 0.5f * this.width) + CubeMeshData.yThickness,  0.5f * this.heigth, 0f),
				// new Vector3((0.10f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.heigth, 0f),
				// new Vector3((0.25f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[3], 0f),
				// new Vector3((0.35f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[3], 0f),
				// new Vector3((0.45f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[2], 0f),
				// new Vector3((0.55f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[2], 0f),
				// new Vector3((0.65f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[1], 0f),
				// new Vector3((0.75f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[1], 0f),
				// new Vector3((0.85f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[0], 0f),
				// new Vector3((0.95f * 0.5f * this.width) - CubeMeshData.yThickness,   0.5f * this.centerHs[0], 0f)
				new Vector3(-(0.95f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[0], 0f),
				new Vector3(-(0.85f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[0], 0f),
				new Vector3(-(0.75f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[1], 0f),
				new Vector3(-(0.65f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[1], 0f),
				new Vector3(-(0.55f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[2], 0f),
				new Vector3(-(0.45f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[2], 0f),
				new Vector3(-(0.35f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[3], 0f),
				new Vector3(-(0.25f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[3], 0f),
				new Vector3(-(0.10f * 0.5f * this.width),  0.5f * this.heigth, 0f),
				new Vector3((0.10f * 0.5f * this.width),   0.5f * this.heigth, 0f),
				new Vector3((0.25f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[3], 0f),
				new Vector3((0.35f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[3], 0f),
				new Vector3((0.45f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[2], 0f),
				new Vector3((0.55f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[2], 0f),
				new Vector3((0.65f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[1], 0f),
				new Vector3((0.75f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[1], 0f),
				new Vector3((0.85f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[0], 0f),
				new Vector3((0.95f * 0.5f * this.width - CubeMeshData.yThickness),   0.5f * this.centerHs[0], 0f)

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

	//四个边辅助线的位置 ceterHs为辅助线的高度也是x轴向的长度
	//十一柱子时候(除去两端的剩余9个柱子)
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


	public float[] centerHs1{
		get { 
			return new float[] {
				this.heigth		
			};
	  }
	}

	public float[] centerHs3{
		get { 
			return new float[] {
				this.heigth - this.heigth0  + 0.5f * 0.5f * this.width / 2f * Mathf.Tan(this.angle),
				this.heigth
			};
	  }
	}


	public float[] centerHs5{
		get { 
			return new float[] {
				this.heigth - this.heigth0  + 0.5f * 0.5f * this.width / 3f * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 3 * (0.5f * 0.5f * this.width / 3f)  * Mathf.Tan(this.angle),	
				this.heigth
			};
	  }
	}


	public float[] centerHs7{
		get { 
			return new float[] {
				this.heigth - this.heigth0  + 0.5f * 0.5f * this.width / 4f * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 3 * (0.5f * 0.5f * this.width / 4f)  * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 5 * (0.5f * 0.5f * this.width / 4f)  * Mathf.Tan(this.angle),	
				this.heigth
			};
	  }
	}

	public float[] centerHs9{
		get { 
			return new float[] {
				this.heigth - this.heigth0  + 1 * (0.5f * 0.5f * this.width / 5f) * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 3 * (0.5f * 0.5f * this.width / 5f) * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 5 * (0.5f * 0.5f * this.width / 5f) * Mathf.Tan(this.angle),
				this.heigth - this.heigth0  + 7 * (0.5f * 0.5f * this.width / 5f) * Mathf.Tan(this.angle),	
				this.heigth
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
				new Vector3 (-0.5f* this.width + CubeMeshData.yThickness,  this.sideLens[4], 0f),
				new Vector3 (-0.4f* this.width + CubeMeshData.yThickness,  this.sideLens[5], 0f),
				new Vector3 (-0.3f* this.width + CubeMeshData.yThickness,  this.sideLens[6], 0f),
				new Vector3 (-0.2f* this.width + CubeMeshData.yThickness,  this.sideLens[7], 0f),
				new Vector3 (-0.1f* this.width + CubeMeshData.yThickness,  this.sideLens[8], 0f),

				new Vector3 (0.1f* this.width - CubeMeshData.yThickness,  this.sideLens[9] , 0f),
				new Vector3 (0.2f* this.width - CubeMeshData.yThickness,  this.sideLens[10], 0f),
				new Vector3 (0.3f* this.width - CubeMeshData.yThickness,  this.sideLens[11], 0f),
				new Vector3 (0.4f* this.width - CubeMeshData.yThickness,  this.sideLens[12], 0f),
				new Vector3 (0.5f* this.width - CubeMeshData.yThickness,  this.sideLens[13], 0f),
				};
		}
	}


	//中心坐标 计算平移值
	public Vector3[] centerSidePositionsByNum{
		get { 
			return new Vector3[] {
				//new Vector3 (-(0.25f * this.width + 1f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 1f* Mathf.Cos(this.angle), 0f),
				new Vector3 (-(this.sideLens[0] * Mathf.Cos(this.angle)  + CubeMeshData.yThickness * Mathf.Sin(this.angle)),  this.heigth - this.heigth0 + 0.5f * this.heigth0 + CubeMeshData.yThickness * Mathf.Cos(this.angle), 0f),
				new Vector3 ((this.sideLens[0] * Mathf.Cos(this.angle)  + CubeMeshData.yThickness * Mathf.Sin(this.angle)),  this.heigth - this.heigth0 + 0.5f * this.heigth0 + CubeMeshData.yThickness * Mathf.Cos(this.angle), 0f),

				//new Vector3 ((0.25f * this.width + 1f* Mathf.Sin(this.angle)), 0.5f * this.heigth + 1f* Mathf.Cos(this.angle), 0f),
				new Vector3 (0f, 0f, 0f),
//				new Vector3 (0f, this.heigth * 0.5f, 0f),
				new Vector3 (-0.5f* this.width + CubeMeshData.yThickness,  this.sideLens[4], 0f),
//				new Vector3 (-0.4f* this.width + CubeMeshData.yThickness,  this.sideLens[5], 0f),
//				new Vector3 (-0.3f* this.width + CubeMeshData.yThickness,  this.sideLens[6], 0f),
//				new Vector3 (-0.2f* this.width + CubeMeshData.yThickness,  this.sideLens[7], 0f),
//				new Vector3 (-0.1f* this.width + CubeMeshData.yThickness,  this.sideLens[8], 0f),
//
//				new Vector3 (0.1f* this.width - CubeMeshData.yThickness,  this.sideLens[9] , 0f),
//				new Vector3 (0.2f* this.width - CubeMeshData.yThickness,  this.sideLens[10], 0f),
//				new Vector3 (0.3f* this.width - CubeMeshData.yThickness,  this.sideLens[11], 0f),
//				new Vector3 (0.4f* this.width - CubeMeshData.yThickness,  this.sideLens[12], 0f),
				new Vector3 (0.5f* this.width - CubeMeshData.yThickness,  this.sideLens[13], 0f),

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

	public int[] leftOffsetVertices{
		get{
			return new int[] {
				0,
				5
			};
		}
	}

	public int[] rightOffsetVertices{
		get{
			return new int[] {
				1,
				4
			};
		}
	}


	public int[] leftOffsetYVertices{
		get{
			return new int[] {
				3,
				6
			};
		}
	}

	public int[] rightOffsetYVertices{
		get{
			return new int[] {
				0,
				5
			};
		}
	}


	public float[] yOffsets{
		get{
			return new float[] {
				2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f,
				2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f
				// 2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad),
				// 2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad)
			};
		}
	}

	public float[] leftOffsets{
		get{
			return new float[] {
				2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f,
				2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f
				// 2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad),
				// 2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad)
			};
		}
	}

	public float[] rightOffsets{
		get{
			return new float[] {
				-(2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f),
				-(2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f)
				// (2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad)),
				// (2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad))
			};
		}
	}


	public int[] verticalOffsetVertices{
		get{
			return new int[] {
				3,
				6
			};
		}
	}

	public int[] verticalLeanOffsetVertices{
		get{
			return new int[] {
				2,
				7
			};
		}
	}

	public float[] verticalOffsets{
		get{
			return new float[] {
				2f * CubeMeshData.yThickness * Mathf.Tan(this.angle) + 0.001f,
				2f * CubeMeshData.yThickness * Mathf.Tan(this.angle) + 0.001f
			};
		}
	}

	public float[] leanVerticalOffsets{
		get{
			return new float[] {
				2f * CubeMeshData.yThickness * Mathf.Tan(this.angle) + 0.1f,
				2f * CubeMeshData.yThickness * Mathf.Tan(this.angle) + 0.1f
			};
		}
	}

	public float[] minusLeanVerticalOffsets{
		get{
			return new float[] {
				-2f * CubeMeshData.yThickness,
				-2f * CubeMeshData.yThickness

			};
		}
	}



	public void  draw()
	{
		//左斜边
		for (int i = 0; i < 1; i++)
		{
			float len = (float)this.sideLens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.leftOffsetVertices, this.leftOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

		//右斜边
		for (int i = 1; i < 2; i++)
		{
			float len = (float)this.sideLens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.rightOffsetVertices, this.rightOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}
		//底边
		for (int i = 2; i < 3; i++)
		{
			float len = (float)this.sideLens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCube(len, Vector3.zero);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

		//最左竖边
		for (int i = 3; i < 4; i++)
		{
			float len = (float)this.sideLens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
//			GameObject go =MakeCube(len, Vector3.zero);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.leftOffsetVertices, this.leftOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}


		//最右竖边
		for (int i = 4; i < this.sideLens.Length; i++)
		{
			float len = (float)this.sideLens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			//			GameObject go =MakeCube(len, Vector3.zero);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.rightOffsetVertices, this.rightOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

		//构造内部斜边
		for (int i = 0; i < this.sideInnerLens.Length; i++)
		{
			float len = (float)this.sideInnerLens[i];
//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCube(0.5f*len, Vector3.zero);
			go.name = go.name + i + "...";
			go.transform.position = go.transform.position + this.sideInnerCenters[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localInnerRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}
	}

	public GameObject MakeCube(float scale, Vector3 localPos){
		//        Debug.Log(localPos);
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

	public GameObject MakeCubeWithSideOffset(float scale, Vector3 localPos, int[] leftOffsetVertices =null, float[] offsets = null){
		//        Debug.Log(localPos);
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
			vertices.AddRange(CubeMeshData.faceVerticesWithOffset(i, scale, localPos, leftOffsetVertices, offsets));
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


	public void  drawByNum( int num)
	{
		Debug.Log ("=====drawByNum=====" + num);
		//绘制左边
		for (int i = 0; i < 1; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.leftOffsetVertices, this.leftOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositionsByNum[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

		//绘制右边
		for (int i = 1; i < 2; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.rightOffsetVertices, this.rightOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositionsByNum[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}
		//绘制底边
		for (int i = 2; i < 3; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCube(len, Vector3.zero);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositionsByNum[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

		//绘制左第一竖边
		for (int i = 3; i < 4; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.leftOffsetYVertices, this.yOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositionsByNum[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}


		//绘制右第一竖边
		for (int i = 4; i < this.sideLensByNum.Length; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			// GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.rightOffsetVertices, this.rightOffsets);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.rightOffsetYVertices, this.yOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositionsByNum[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

			
//		for (int i = 0; i < this.sideInnerLens.Length; i++)
//		{
//			float len = (float)this.sideInnerLens[i];
//			//			Debug.Log ("len " + len + " i=  " + i);
//			GameObject go =MakeCube(0.5f*len, Vector3.zero);
//			go.name = go.name + i + "...";
//			go.transform.position = go.transform.position + this.sideInnerCenters[i];
//			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localInnerRotations[i]);
//
//			go.transform.parent = RLKUtility.Room_pillar.transform;
//		}

		//构造内部斜边

		float[] lens = this.heighsByNum(num);
		Vector3[] centers = this.centerHsByNum(num);
		float[] rotations = this.localRotationsByNum(num);

		for (int i = 0; i < lens.Length - num/2; i++)
		{
			float len = (float)lens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go;

			//左边第一斜边 别出头
			if (i == 0) {
				go = MakeCubeWithSideOffset(0.5f * len, Vector3.zero, this.rightOffsetVertices, this.leanVerticalOffsets);
			} else if (i == num * 2 - 1) {
				//最右边一个斜边 别出头
				go = MakeCubeWithSideOffset(0.5f * len, Vector3.zero, this.leftOffsetVertices, this.minusLeanVerticalOffsets);
			}else if(i < (num * 2 + 1)){
				go = MakeCube(0.5f*len, Vector3.zero);
			}else{
				go = MakeCubeWithSideOffset(0.5f * len, Vector3.zero, this.verticalOffsetVertices, this.verticalOffsets);
			}
			go.name = go.name + "." +i ;
			go.transform.position = go.transform.position + centers[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, rotations[i]);
			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

		//右边竖着的柱子

		for (int i = lens.Length - num/2; i < lens.Length; i++)
		{
			float len = (float)lens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go = MakeCubeWithSideOffset(0.5f * len, Vector3.zero, this.rightOffsetYVertices, this.yOffsets);
			go.name = go.name + "." +i ;
			go.transform.position = go.transform.position + centers[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, rotations[i]);
			go.transform.parent = RLKUtility.Room_pillar.transform;
		}
	}




	//共用的边长 + 中间 高  + 最外侧的两个竖边
public float[] sideLensByNum{
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
          // 0.5f * (this.width + CubeMeshData.yThickness),
          0.5f * (this.width),
//          0.5f * this.heigth,
          //左边的各个竖立边的长度
					0.5f * (this.heigth - this.heigth0),		                                        //4
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*1),    //5
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*2),    //6
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*3),    //7
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*4),    //8
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*4),    //9
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*3),    //10
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*2),    //11
					// 0.5f * (this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*1),    //12
					0.5f * (this.heigth - this.heigth0)                                             	//13
            //右边的各个竖立边长度
			};
    }
  }

  //除了共用的竖边 包括竖的跟斜着的
	public float[] heighsByNum(int num){
		switch(num)
		{
			case 1:
				return this.heighsByNum1;
			case 3:
				return this.heighsByNum3;
			case 5:
				return this.heighsByNum5;
			case 7:
				return this.heighsByNum7;
			case 9:
				return this.heighsByNum9;
			default:
				return this.heighsByNum1;
		}
  	}

	//各个斜边
	public float[] localRotationsByNum(int num){
		switch(num)
		{
		case 1:
			return this.localRotationsByNum1;
		case 3:
			return this.localRotationsByNum3;
		case 5:
			return this.localRotationsByNum5;
		case 7:
			return this.localRotationsByNum7;
		case 9:
			return this.localRotationsByNum9;
		default:
			return this.localRotationsByNum1;
		}
	}

	//各个斜边位置
	public Vector3[] centerHsByNum(int num){
		switch(num)
		{
		case 1:
			return this.centerHsByNum1;
		case 3:
			return this.centerHsByNum3;
		case 5:
			return this.centerHsByNum5;
		case 7:
			return this.centerHsByNum7;
		case 9:
			return this.centerHsByNum9;
		default:
			return this.centerHsByNum1;
		}
	}

  //左边斜边1个角角度（不算两侧的一个柱子）
	public float[] anglesInner1{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.heigth, 0.5f * this.width)
			};
		}
	}


	//左边2个角角度（不算两侧的3个柱子）
	public float[] anglesInner3{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.centerHs3[0], 0.5f * 0.5f / 2f * this.width),
				Mathf.Atan2 (this.heigth, 0.5f * this.width / 2f)
			};
		}
	}

	//左边3个角角度（不算两侧的5个柱子）
	public float[] anglesInner5{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.centerHs5[0], 0.5f * 0.5f / 3f * this.width),
				Mathf.Atan2 (this.centerHs5[1], 0.5f * 0.5f / 3f * this.width),
				Mathf.Atan2 (this.heigth,   0.5f * this.width / 3f)
			};
		}
	}


	//左边4个角角度 （不算两侧的7个柱子）
	public float[] anglesInner7{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.centerHs7 [0], 0.5f * 0.5f / 4f * this.width),
				Mathf.Atan2 (this.centerHs7 [1], 0.5f * 0.5f / 4f * this.width),
				Mathf.Atan2 (this.centerHs7 [2], 0.5f * 0.5f / 4f * this.width),
				Mathf.Atan2 (this.heigth,   0.5f * this.width / 4f)
			};
		}
	}


	//左边5个角角度（不算两侧的9个柱子）
	public float[] anglesInner9{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.centerHs9 [0], 0.5f * 0.5f / 5f * this.width),
				Mathf.Atan2 (this.centerHs9 [1], 0.5f * 0.5f / 5f * this.width),
				Mathf.Atan2 (this.centerHs9 [2], 0.5f * 0.5f / 5f * this.width),
				Mathf.Atan2 (this.centerHs9 [3], 0.5f * 0.5f / 5f * this.width),
				Mathf.Atan2 (this.heigth,   0.5f * this.width / 5f)
			};
		}
	}
		

  public float[] heighsByNum1{
    get{
      return new float[] {
        0.5f * this.width / Mathf.Cos(this.anglesInner1[0]),
        0.5f * this.width / Mathf.Cos(this.anglesInner1[0]),
        //竖着的中间那个
        this.heigth
	  	};
    }
  }

  public float[] heighsByNum3{
    get{
      return new float[] {
	      0.5f * this.width / 2f * 0.5f / Mathf.Cos(this.anglesInner3[0]),
	      0.5f * this.width / 2f * 0.5f / Mathf.Cos(this.anglesInner3[0]),

	      0.5f * this.width / 2f / Mathf.Cos(this.anglesInner3[1]),
	      0.5f * this.width / 2f / Mathf.Cos(this.anglesInner3[1]),

	      0.5f * this.width / 2f * 0.5f / Mathf.Cos(this.anglesInner3[0]),
	      0.5f * this.width / 2f * 0.5f / Mathf.Cos(this.anglesInner3[0]),

	      //三个竖着的柱子
	      this.heigth,
	      this.heigth - this.heigth0 + 0.5f*this.width / 2f * Mathf.Tan(this.angle),
	      this.heigth - this.heigth0 + 0.5f*this.width / 2f * Mathf.Tan(this.angle),

			};
    }
  }

  public float[] heighsByNum5{
    get{
      return new float[] {
        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[0]),
        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[0]),

        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[1]),
        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[1]),

        0.5f * this.width / 3f / Mathf.Cos(this.anglesInner5[2]),
        0.5f * this.width / 3f / Mathf.Cos(this.anglesInner5[2]),

        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[1]),
        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[1]),

        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[0]),
        0.5f * this.width / 3f * 0.5f / Mathf.Cos(this.anglesInner5[0]),

        //五个竖着的柱子
	      this.heigth,
	      this.heigth - this.heigth0 + 0.5f*this.width / 3f * 1f * Mathf.Tan(this.angle),
	      this.heigth - this.heigth0 + 0.5f*this.width / 3f * 2f * Mathf.Tan(this.angle),
	      this.heigth - this.heigth0 + 0.5f*this.width / 3f * 2f * Mathf.Tan(this.angle),
	      this.heigth - this.heigth0 + 0.5f*this.width / 3f * 1f * Mathf.Tan(this.angle),
			};
    }
  }

	public float[] heighsByNum7{
		get{
			return new float[] {
				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[0]),
				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[0]),

				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[1]),
				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[1]),

				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[2]),
				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[2]),

				0.5f * this.width / 4f / Mathf.Cos(this.anglesInner7[3]),
				0.5f * this.width / 4f / Mathf.Cos(this.anglesInner7[3]),

				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[2]),
				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[2]),

				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[1]),
				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[1]),

				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[0]),
				0.5f * this.width / 4f * 0.5f / Mathf.Cos(this.anglesInner7[0]),

				//七个竖着的柱子
		      this.heigth,
		      this.heigth - this.heigth0 + 0.5f*this.width / 4f * 1f * Mathf.Tan(this.angle),
		      this.heigth - this.heigth0 + 0.5f*this.width / 4f * 2f * Mathf.Tan(this.angle),
		      this.heigth - this.heigth0 + 0.5f*this.width / 4f * 3f * Mathf.Tan(this.angle),
		      this.heigth - this.heigth0 + 0.5f*this.width / 4f * 3f * Mathf.Tan(this.angle),
		      this.heigth - this.heigth0 + 0.5f*this.width / 4f * 2f * Mathf.Tan(this.angle),
		      this.heigth - this.heigth0 + 0.5f*this.width / 4f * 1f * Mathf.Tan(this.angle),
			};
		}
	}


	public float[] heighsByNum9{
		get{
			return new float[] {
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[0]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[0]),

				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[1]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[1]),

				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[2]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[2]),

				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[3]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[3]),

				0.5f * this.width / 5f / Mathf.Cos(this.anglesInner9[4]),
				0.5f * this.width / 5f / Mathf.Cos(this.anglesInner9[4]),

				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[3]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[3]),

				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[2]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[2]),

				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[1]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[1]),

				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[0]),
				0.5f * this.width / 5f * 0.5f / Mathf.Cos(this.anglesInner9[0]),

				//九个竖着的柱子
	            this.heigth,
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*1,   //5
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*2,    //6
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*3,    //7
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*4,    //8
				//右边的各个竖立边长度
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*4,    //9
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*3,    //10
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*2,    //11
				this.heigth - this.heigth0 + 0.5f*this.width/5*Mathf.Tan(this.angle)*1,    //12 
			};
		}
	}



	public Vector3[] centerHsByNum1{
		get{ 
			return new Vector3[]{
				new Vector3(-( 0.5f * this.width) * 0.5f,  0.5f * this.centerHs1[0], 0f),
				new Vector3( ( 0.5f * this.width) * 0.5f,  0.5f * this.centerHs1[0], 0f),
				
				new Vector3( 0f, 0.5f * this.heighsByNum1[2], 0f)
			};
		}
	}

	public Vector3[] centerHsByNum3{
		get{ 
			return new Vector3[]{
				new Vector3(-(0.5f * this.width)/2f /4f *(4f+3f), 0.5f * this.centerHs3[0], 0f),
				new Vector3(-(0.5f * this.width)/2f /4f *(4f+1f), 0.5f * this.centerHs3[0], 0f),

				new Vector3(-(0.5f * this.width)/2f /4f *2f, 0.5f * this.centerHs3[1], 0f),
				new Vector3( (0.5f * this.width)/2f /4f *2f, 0.5f * this.centerHs3[1], 0f),

				new Vector3( (0.5f * this.width)/2f /4f *(4f+1f), 0.5f * this.centerHs3[0], 0f),
				new Vector3( (0.5f * this.width)/2f /4f *(4f+3f), 0.5f * this.centerHs3[0], 0f),

				//三个竖边的中心点
				new Vector3( 0f, 0.5f * this.heighsByNum3[6], 0f),
				new Vector3(-(0.5f * this.width / 2f), 0.5f * this.heighsByNum3[7], 0f),
				new Vector3( (0.5f * this.width / 2f), 0.5f * this.heighsByNum3[8], 0f),
			};
		}
	}

	public Vector3[] centerHsByNum5{
		get{ 
			return new Vector3[]{
				new Vector3(-(0.5f * this.width)/3f /4f *(4f+4f + 3f), 0.5f * this.centerHs5[0], 0f),
				new Vector3(-(0.5f * this.width)/3f /4f *(4f+4f + 1f), 0.5f * this.centerHs5[0], 0f),
				new Vector3(-(0.5f * this.width)/3f /4f *(4f+3f), 0.5f * this.centerHs5[1], 0f),
				new Vector3(-(0.5f * this.width)/3f /4f *(4f+1f), 0.5f * this.centerHs5[1], 0f),

				new Vector3(-(0.5f * this.width)/3f /4f * 2f, 0.5f * this.centerHs5[2], 0f),
				new Vector3( (0.5f * this.width)/3f /4f * 2f, 0.5f * this.centerHs5[2], 0f),

				new Vector3( (0.5f * this.width)/3f /4f *(4f+1f), 0.5f * this.centerHs5[1], 0f),
				new Vector3( (0.5f * this.width)/3f /4f *(4f+3f), 0.5f * this.centerHs5[1], 0f),
				new Vector3( (0.5f * this.width)/3f /4f *(4f+4f+1f), 0.5f * this.centerHs5[0], 0f),
				new Vector3( (0.5f * this.width)/3f /4f *(4f+4f+3f), 0.5f * this.centerHs5[0], 0f),

				//五个竖边的中心点
				new Vector3( 0f, 0.5f * this.heighsByNum5[10], 0f),
				new Vector3(-(0.5f * this.width/3f) * 2f, 0.5f * this.heighsByNum5[11], 0f),
				new Vector3(-(0.5f * this.width/3f) * 1f, 0.5f * this.heighsByNum5[12], 0f),
				new Vector3( (0.5f * this.width/3f) * 1f, 0.5f * this.heighsByNum5[13], 0f),
				new Vector3( (0.5f * this.width/3f) * 2f, 0.5f * this.heighsByNum5[14], 0f),
				
			};
		}
	}


	public Vector3[] centerHsByNum7{
		get{ 
			return new Vector3[]{
				new Vector3(-(0.5f * this.width)/4f /4f *(4f + 4f+ 4f + 3f), 0.5f * this.centerHs7[0], 0f),
				new Vector3(-(0.5f * this.width)/4f /4f *(4f + 4f+ 4f + 1f), 0.5f * this.centerHs7[0], 0f),

				new Vector3(-(0.5f * this.width)/4f /4f *(4f+ 4f + 3f), 0.5f * this.centerHs7[1], 0f),
				new Vector3(-(0.5f * this.width)/4f /4f *(4f+ 4f + 1f), 0.5f * this.centerHs7[1], 0f),

				new Vector3(-(0.5f * this.width)/4f /4f *(4f+3f), 0.5f * this.centerHs7[2], 0f),
				new Vector3(-(0.5f * this.width)/4f /4f *(4f+1f), 0.5f * this.centerHs7[2], 0f),

				new Vector3(-(0.5f * this.width)/4f /4f * 2f, 0.5f * this.centerHs7[3], 0f),
				new Vector3( (0.5f * this.width)/4f /4f * 2f, 0.5f * this.centerHs7[3], 0f),

				new Vector3( (0.5f * this.width)/4f /4f *(4f+1f), 0.5f * this.centerHs7[2], 0f),
				new Vector3( (0.5f * this.width)/4f /4f *(4f+3f), 0.5f * this.centerHs7[2], 0f),
				
				new Vector3( (0.5f * this.width)/4f /4f *(4f+ 4f + 1f), 0.5f * this.centerHs7[1], 0f),
				new Vector3( (0.5f * this.width)/4f /4f *(4f+ 4f + 3f), 0.5f * this.centerHs7[1], 0f),
				
				new Vector3( (0.5f * this.width)/4f /4f *(4f + 4f+ 4f + 1f), 0.5f * this.centerHs7[0], 0f),
				new Vector3( (0.5f * this.width)/4f /4f *(4f + 4f+ 4f + 3f), 0.5f * this.centerHs7[0], 0f),

				//七个个竖边的中心点
				new Vector3( 0f, 0.5f * this.heighsByNum7[14], 0f),
				new Vector3(-(0.5f * this.width/4f) * 3f, 0.5f * this.heighsByNum7[15], 0f),
				new Vector3(-(0.5f * this.width/4f) * 2f, 0.5f * this.heighsByNum7[16], 0f),
				new Vector3(-(0.5f * this.width/4f) * 1f, 0.5f * this.heighsByNum7[17], 0f),
				new Vector3( (0.5f * this.width/4f) * 1f, 0.5f * this.heighsByNum7[18], 0f),
				new Vector3( (0.5f * this.width/4f) * 2f, 0.5f * this.heighsByNum7[19], 0f),
				new Vector3( (0.5f * this.width/4f) * 3f, 0.5f * this.heighsByNum7[20], 0f),
			};
		}
	}


		public Vector3[] centerHsByNum9{
		get{ 
			return new Vector3[]{
				new Vector3(-(0.5f * this.width)/5f/4f *(4f + 4f + 4f+ 4f + 3f), 0.5f * this.centerHs9[0], 0f),
				new Vector3(-(0.5f * this.width)/5f/4f *(4f + 4f + 4f+ 4f + 1f), 0.5f * this.centerHs9[0], 0f),

				new Vector3(-(0.5f * this.width)/5f/4f *(4f + 4f + 4f + 3f), 0.5f * this.centerHs9[1], 0f),
				new Vector3(-(0.5f * this.width)/5f/4f *(4f + 4f + 4f + 1f), 0.5f * this.centerHs9[1], 0f),

				new Vector3(-(0.5f * this.width)/5f/4f*(4f + 4f+3f), 0.5f * this.centerHs9[2], 0f),
				new Vector3(-(0.5f * this.width)/5f/4f*(4f + 4f+1f), 0.5f * this.centerHs9[2], 0f),

				new Vector3(-(0.5f * this.width)/5f/4f *(4f+3f), 0.5f * this.centerHs9[3], 0f),
				new Vector3(-(0.5f * this.width)/5f/4f *(4f+1f), 0.5f * this.centerHs9[3], 0f),

				new Vector3(-(0.5f * this.width)/5f/4f * 2f, 0.5f * this.centerHs9[4], 0f),
				new Vector3( (0.5f * this.width)/5f/4f * 2f, 0.5f * this.centerHs9[4], 0f),

				new Vector3( (0.5f * this.width)/5f/4f *(4f+1f), 0.5f * this.centerHs9[3], 0f),
				new Vector3( (0.5f * this.width)/5f/4f *(4f+3f), 0.5f * this.centerHs9[3], 0f),
				
				new Vector3( (0.5f * this.width)/5f /4f *(4f+ 4f + 1f), 0.5f * this.centerHs9[2], 0f),
				new Vector3( (0.5f * this.width)/5f /4f *(4f+ 4f + 3f), 0.5f * this.centerHs9[2], 0f),
				
				new Vector3( (0.5f * this.width)/5f /4f *(4f + 4f+ 4f + 1f), 0.5f * this.centerHs9[1], 0f),
				new Vector3( (0.5f * this.width)/5f /4f *(4f + 4f+ 4f + 3f), 0.5f * this.centerHs9[1], 0f),

				new Vector3( (0.5f * this.width)/5f /4f *(4f + 4f + 4f+ 4f + 1f), 0.5f * this.centerHs9[0], 0f),
				new Vector3( (0.5f * this.width)/5f /4f *(4f + 4f + 4f+ 4f + 3f), 0.5f * this.centerHs9[0], 0f),

				//七个个竖边的中心点
				new Vector3( 0f, 0.5f * this.heighsByNum9[18], 0f),
				new Vector3(-(0.5f * this.width/5f) * 4f, 0.5f * this.heighsByNum9[19], 0f),
				new Vector3(-(0.5f * this.width/5f) * 3f, 0.5f * this.heighsByNum9[20], 0f),
				new Vector3(-(0.5f * this.width/5f) * 2f, 0.5f * this.heighsByNum9[21], 0f),
				new Vector3(-(0.5f * this.width/5f) * 1f, 0.5f * this.heighsByNum9[22], 0f),
				new Vector3( (0.5f * this.width/5f) * 1f, 0.5f * this.heighsByNum9[23], 0f),
				new Vector3( (0.5f * this.width/5f) * 2f, 0.5f * this.heighsByNum9[24], 0f),
				new Vector3( (0.5f * this.width/5f) * 3f, 0.5f * this.heighsByNum9[25], 0f),
				new Vector3( (0.5f * this.width/5f) * 4f, 0.5f * this.heighsByNum9[26], 0f)
			};
		}
	}

	public float[] localRotationsByNum1{
		get { 
			return new float[]{
				this.anglesInner1[0] * Mathf.Rad2Deg,                 //1
				360f - this.anglesInner1[0] * Mathf.Rad2Deg ,         //2
				//竖着的角度
				90f
			};
		}
	}

		public float[] localRotationsByNum3{
		get { 
			return new float[]{
				this.anglesInner3[0] * Mathf.Rad2Deg,                 //1
				360f - this.anglesInner3[0] * Mathf.Rad2Deg ,         //2
				this.anglesInner3[1] * Mathf.Rad2Deg,                 //3
				360f - this.anglesInner3[1] * Mathf.Rad2Deg,          //4
				this.anglesInner3[0] * Mathf.Rad2Deg,                 //5
				360f - this.anglesInner3[0] * Mathf.Rad2Deg,          //6
				//竖着的角度
				90f,
				90f,
				90f
			};
		}
	}

		public float[] localRotationsByNum5{
		get { 
			return new float[]{
				this.anglesInner5[0] * Mathf.Rad2Deg,      
				360f - this.anglesInner5[0] * Mathf.Rad2Deg, 
				this.anglesInner5[1] * Mathf.Rad2Deg,
				360f - this.anglesInner5[1] * Mathf.Rad2Deg,          
				this.anglesInner5[2] * Mathf.Rad2Deg,
				360f - this.anglesInner5[2] * Mathf.Rad2Deg,
				this.anglesInner5[1] * Mathf.Rad2Deg,
				360f - this.anglesInner5[1] * Mathf.Rad2Deg,
				this.anglesInner5[0] * Mathf.Rad2Deg,
				360f - this.anglesInner5[0] * Mathf.Rad2Deg,

				//五个竖着的角度
				90f,
				90f,
				90f,
				90f,
				90f
			};
		}
	}

	public float[] localRotationsByNum7{
		get { 
			return new float[]{
				this.anglesInner7[0] * Mathf.Rad2Deg,
				360f - this.anglesInner7[0] * Mathf.Rad2Deg,
				this.anglesInner7[1] * Mathf.Rad2Deg,
				360f - this.anglesInner7[1] * Mathf.Rad2Deg,
				this.anglesInner7[2] * Mathf.Rad2Deg,
				360f - this.anglesInner7[2] * Mathf.Rad2Deg,

				this.anglesInner7[3] * Mathf.Rad2Deg,
				360f - this.anglesInner7[3] * Mathf.Rad2Deg,

				this.anglesInner7[2] * Mathf.Rad2Deg,
				360f - this.anglesInner7[2] * Mathf.Rad2Deg,
				this.anglesInner7[1] * Mathf.Rad2Deg,
				360f - this.anglesInner7[1] * Mathf.Rad2Deg,
				this.anglesInner7[0] * Mathf.Rad2Deg,
				360f - this.anglesInner7[0] * Mathf.Rad2Deg,

				//七个竖着的角度
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f
			};
		}
	}

	public float[] localRotationsByNum9{
		get { 
			return new float[]{
				this.anglesInner9[0] * Mathf.Rad2Deg,
				360f - this.anglesInner9[0] * Mathf.Rad2Deg,
				this.anglesInner9[1] * Mathf.Rad2Deg,
				360f - this.anglesInner9[1] * Mathf.Rad2Deg,
				this.anglesInner9[2] * Mathf.Rad2Deg,
				360f - this.anglesInner9[2] * Mathf.Rad2Deg,
				this.anglesInner9[3] * Mathf.Rad2Deg,
				360f - this.anglesInner9[3] * Mathf.Rad2Deg,
				this.anglesInner9[4] * Mathf.Rad2Deg,
				360f - this.anglesInner9[4] * Mathf.Rad2Deg,
				this.anglesInner9[3] * Mathf.Rad2Deg,
				360f - this.anglesInner9[3] * Mathf.Rad2Deg,
				this.anglesInner9[2] * Mathf.Rad2Deg,
				360f - this.anglesInner9[2] * Mathf.Rad2Deg,
				this.anglesInner9[1] * Mathf.Rad2Deg,
				360f - this.anglesInner9[1] * Mathf.Rad2Deg,
				this.anglesInner9[0] * Mathf.Rad2Deg,
				360f - this.anglesInner9[0] * Mathf.Rad2Deg,

				//9个竖着的角度
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f,
				90f
			};
		}
	}

}