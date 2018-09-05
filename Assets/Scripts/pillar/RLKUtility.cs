using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class RLKUtility : MonoBehaviour
{	
	public static GameObject Room_pillar;             //钢架的父物体（用于存放钢架）	

	//钢架初始参数
	public static float Pillar_init_w = 12f;            //钢架宽度
	public static float Pillar_init_h1 = 1f;            //钢架高度1
	public static float Pillar_init_h2 = 2f;            //钢架高度2
	public static float Pillar_init_jw = 1f;         //梁截面宽度
	public static float Pillar_init_jh = 0.05f;         //梁截面高度
	public static int Pillar_init_slnum = 9;            //竖梁根数
	public static string Pillar_init_gjposition = "(8.63,13.11426,-8.76)";     //钢架位置
	public static int Pillar_init_gjnum = 1;            //钢架数量

    void Start()
    {
	}
    
    // Update is called once per frame
    void Update()
    {
    }
}
