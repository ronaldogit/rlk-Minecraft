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

	//w:钢架宽； h1:钢架边高1； h2:钢架边高2
	public PillarData(float w, float h1, float h2){
		this.width = w;
		this.heigth = h1+h2;
		this.topAngle = 2f * Mathf.Atan((0.5f*w)/h2) * Mathf.Rad2Deg;
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


	public float[] centerHs5{
		get { 
			return new float[] {
				this.heigth - this.heigth0  + 0.5f * 0.5f * this.width / 2f * Mathf.Tan(this.angle),		
			};
	  }
	}


	public float[] centerHs7{
		get { 
			return new float[] {
				this.heigth - this.heigth0  + 0.5f * 0.5f * this.width / 3f * Mathf.Tan(this.angle),	
				this.heigth - this.heigth0  + 3 * (0.5f * 0.5f * this.width / 3f)  * Mathf.Tan(this.angle),	
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

	public float[] leftOffsets{
		get{
			return new float[] {
				2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f,
				2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f
			};
		}
	}

	public float[] rightOffsets{
		get{
			return new float[] {
				-(2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f),
				-(2f * CubeMeshData.yThickness/Mathf.Tan(this.topAngle/2 * Mathf.Deg2Rad) + 0.001f)
			};
		}
	}

	public void  draw()
	{
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

		for (int i = 2; i < this.sideLens.Length; i++)
		{
			float len = (float)this.sideLens[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCube(len, Vector3.zero);
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
		for (int i = 0; i < 1; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.leftOffsetVertices, this.leftOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}


		for (int i = 1; i < 2; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCubeWithSideOffset(len, Vector3.zero, this.rightOffsetVertices, this.rightOffsets);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

		for (int i = 2; i < this.sideLensByNum.Length; i++)
		{
			float len = (float)this.sideLensByNum[i];
			//			Debug.Log ("len " + len + " i=  " + i);
			GameObject go =MakeCube(len, Vector3.zero);
			go.name = go.name + i + "..";
			go.transform.position = go.transform.position + this.centerSidePositions[i];
			go.transform.rotation = Quaternion.Euler(0f, 0f, this.localRotations[i]);

			go.transform.parent = RLKUtility.Room_pillar.transform;
		}

//s		//构造内部斜边
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
	}

	//共用的边长 两个竖边
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
          0.5f * this.width,
          0.5f * this.heigth,
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

  //除了共用的竖边
	public float[] heighsByNum(int num){
		switch(num)
		{
			case 1:
				return this.heighsByNum1;
				break;
			case 3:
				break;
			case 5:
				break;
			case 7:
				break;
			default:
				Debug.log("==arg invalid======")
				break;
		}
  }

  //左边1个角角度
	public float[] anglesInner3{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.heigth, 0.5f * this.width)
			};
		}
	}


	//左边2个角角度
	public float[] anglesInner5{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.centerHs5 [0], 0.5f * 0.5f / 2f * this.width),
				Mathf.Atan2 (this.heigth, 0.5f * 0.5f * this.width)
			};
		}
	}

	//左边3个角角度
	public float[] anglesInner7{
		get{ 
			return new float[] {
				Mathf.Atan2 (this.centerHs7 [0], 0.5f * 0.5f / 3f * this.width),
				Mathf.Atan2 (this.centerHs7 [1], 0.5f * 0.5f / 3f * this.width),
				Mathf.Atan2 (this.heigth,   0.5f / 3f * this.width)
			};
		}
	}

  	public float[] heighsByNum1{
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

}
