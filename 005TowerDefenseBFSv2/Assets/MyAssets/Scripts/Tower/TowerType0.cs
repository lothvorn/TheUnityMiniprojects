using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerType0 : Tower {


	public override void LaunchAttack (){
		GameObject newMissile = (GameObject) Instantiate (projectile, cannonMuzzle.transform.position, Quaternion.identity);
		newMissile.GetComponent<Missile>().target = target;
		newMissile.GetComponent<Missile>().damage = damage;
	}

}
