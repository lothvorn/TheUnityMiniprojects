using UnityEngine;
using System.Collections;

public class CrystalReactor : MonoBehaviour {
	//public references to other objects in prefab (keep public)
	public GameObject crystal;

	public void OnTriggerEnter (Collider col){
			if (col.transform.tag == "Enemy"){
			crystal.GetComponent<Crystal>().cell.blocked = false;
			Destroy (col.transform.gameObject);
			Destroy (crystal);
		}

	}
}
