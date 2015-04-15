using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	//keep visible
	public int cost = 10;
	public float fireDelay = 10;
	public int damage = 5;
	public int range = 5;
	
	public GameObject turretHead;
	public GameObject cannonMuzzle;

	//internal vars (to hide)
	float fireTimer = 0;
	public GameObject target = null;



	public void Update (){
		if (target == null){ //|| targetOutOfRange
			FindNearestTarget();
		}

		AimTarget ();
	}



	private void FindNearestTarget(){
		GameObject [] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject nearest = null;
	}

	private void AimTarget(){
		if (target != null){
			turretHead.transform.LookAt (target.transform);
		}
	}

}
