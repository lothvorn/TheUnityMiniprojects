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
		if (target == null || DistanceToTarget() > range ){ //|| targetOutOfRange
			FindNearestTarget();
		}

		AimTarget ();


	}




	private float DistanceToTarget() {
		return (transform.position - target.transform.position).magnitude;
	}
	private void FindNearestTarget(){
		GameObject [] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float closestDistance = Mathf.Infinity;
		Vector3 position = transform.position;

		foreach (GameObject en in enemies){
			Vector3 distanceVector = en.transform.position - transform.position;
			float thisDistance = distanceVector.magnitude;
			if (thisDistance < closestDistance){
				closest = en;
				closestDistance = thisDistance;
			}
		}

		target = closest;
	}

	private void AimTarget(){
		if (target != null){
			turretHead.transform.LookAt (target.transform);
		}
	}

}
