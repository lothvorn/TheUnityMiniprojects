using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//public parameters
	public int maxLife =10;
	public int currentDamage = 0;



	public void ReceiveDamage(int damage){
		currentDamage += damage;

		if (currentDamage >= maxLife)
			Destroy (gameObject);

	}
}
