﻿using UnityEngine;
using System.Collections;

public class CameraTest01 : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.transform);
	}
}