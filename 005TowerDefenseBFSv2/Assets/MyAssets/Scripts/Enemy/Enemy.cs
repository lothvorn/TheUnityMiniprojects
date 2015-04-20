using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//public parameters
	public int maxLife =10;
	public int currentDamage = 0;

	//references to other objecs in prefab (keep public)
	public Lifebar lifebar;



	public void ReceiveDamage(int damage){
		currentDamage += damage;

		float normalized = (float) 1 - (float)currentDamage/maxLife;

		lifebar.UpdateValue( normalized );

		if (currentDamage >= maxLife)
			Destroy (gameObject);
	}


}
