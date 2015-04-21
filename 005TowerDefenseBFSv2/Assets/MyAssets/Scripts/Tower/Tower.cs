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
	public GameObject projectile;


	//internal vars (to hide)
	public bool readyToFire = false;
	public int enemiesInside = 0;

	//internal vars (to private)
	public float fireTimer = 0;
	public GameObject target = null;




	public void Update (){
		if (target == null || DistanceToTarget() > range ){ //|| targetOutOfRange
			FindClosestTarget();
		}


		AimTarget ();

		TryToAttack ();

	}




	private float DistanceToTarget() {
		//Debug.Log ("DIST:" +(transform.position - target.transform.position).magnitude);
		return (transform.position - target.transform.position).magnitude;
	}



	private void FindClosestTarget(){
		GameObject [] enemies;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float closestDistance = Mathf.Infinity;
		//Vector3 position = transform.position;

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

	private void TryToAttack (){
		if (!readyToFire)
			return;

		if (target == null){
			fireTimer = 0;
			return;
		}
		if (DistanceToTarget() > range)
			return;

		if (target != null)
			fireTimer += Time.deltaTime;

		if (fireTimer >= fireDelay && target!= null){
			fireTimer = 0;
			LaunchAttack ();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Enemy")
			enemiesInside++;
	}
	
	void OnTriggerExit(Collider other) {
		if (other.transform.tag == "Enemy")
			enemiesInside--;
	}

	public virtual void LaunchAttack (){
		//Debug.Log ("attack launched");
	}
}
