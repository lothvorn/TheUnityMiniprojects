using UnityEngine;
using System.Collections;

public class CrystalReactor : MonoBehaviour {
	//public references to other objects in prefab (keep public)
	public GameObject crystal;


	//set private
	public GameManager gameManager;

	void Start (){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}


	public void OnTriggerEnter (Collider col){
				if (col.transform.tag == "Enemy"){
				gameManager.destroyedCrystals++;
				crystal.GetComponent<BoardElement>().boardCell.blocked = false;
				Destroy (col.transform.gameObject);
				Destroy (crystal);
		}

	}
}
