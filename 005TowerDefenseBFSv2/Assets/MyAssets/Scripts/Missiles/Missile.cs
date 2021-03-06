﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Missile : DamageDealer {
	public float speed = 5;


	private float step;
	public void Update (){
		if (target == null){

			Destroy (gameObject);
		}
		MoveMissile ();

	}



	public void OnTriggerEnter (Collider col){

	//	Debug.Log (col.transform.name);
	//	Debug.Log (col.transform.tag);
		if (col.transform.tag == "Enemy"){
			DamageDeal (col.transform.gameObject);
			Destroy (gameObject);
		}
	}


	public void MoveMissile(){
		if (target == null)
			return;

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

	}
}
