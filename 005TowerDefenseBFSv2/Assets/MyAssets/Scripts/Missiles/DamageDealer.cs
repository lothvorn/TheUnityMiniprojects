using UnityEngine;
using System.Collections;

public class DamageDealer : MonoBehaviour {

	//references to external objects (keep public)
	public GameObject target;
	public int damage= 5;
	public GameObject damagersHolder;

	public void Start (){
		damagersHolder=GameObject.Find ("DamagersHolder");

		transform.parent = damagersHolder.transform;

	}
	public void DamageDeal (GameObject victim){
		victim.transform.GetComponent<Enemy>().ReceiveDamage(damage);


	}
}
