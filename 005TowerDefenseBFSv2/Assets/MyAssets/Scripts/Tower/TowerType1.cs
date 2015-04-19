using UnityEngine;
using System.Collections;


[System.Serializable]
public class TowerType1 : Tower {
	

	public override void LaunchAttack(){
		GameObject lasRay = (GameObject) Instantiate (projectile, transform.position, Quaternion.identity);
		lasRay.GetComponent<LasRay>().origin = cannonMuzzle;
		lasRay.GetComponent<LasRay>().target = target;

	}

}
