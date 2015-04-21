using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
	//references to prefabs (keep public)
	public GameObject [] availableTowers ;
	public GameObject towersHolder;

	//references to external objects (keep public)
	public GameManager gameManager;

	//references to objects in scene (to hide)
	public GameObject lastOverCell = null;
	

	//to hide
	public GameObject towerInCreation = null;
	public bool towerReadyToBuild = false;
	public int cash = 100;


	public void Update (){

		//if building-tower then move the proper tower to the last selected cell if valid
		if (towerReadyToBuild && lastOverCell != null && towerInCreation != null){
//			Debug.Log ("++"+lastOverCell.name);

			Vector3 lastOveredMarker = lastOverCell.GetComponent<BoardCell>().pathCenter.transform.position;
			if (towerInCreation.transform.position != lastOveredMarker)
				towerInCreation.transform.position = lastOveredMarker;


		}


		//finish tower building (just reset pointers)
		if (Input.GetMouseButtonDown(0)){		
			PutTowerInPlace();
		}

		//cancel current build
		if (Input.GetMouseButton(1)){
			CancelTower ();
		}


	}


	private void CancelTower(){
		if (towerReadyToBuild){
			Destroy (towerInCreation);
			towerReadyToBuild = false;
			lastOverCell = null;
			towerInCreation = null;

		}


	}

	private void PutTowerInPlace(){
		//if there is no tower ready to build then do nothing and return
		if (!towerReadyToBuild)
			return;

		//update available cash
		gameManager.SetCash (gameManager.cash - towerInCreation.GetComponent<Tower>().cost);

		towerInCreation.GetComponentInParent<Tower>().readyToFire = true;
		lastOverCell.GetComponent<BoardCell>().blocked = true;
		lastOverCell.GetComponent<BoardCell>().collider.enabled = false;

		//reset building vars
		towerInCreation.transform.parent = towersHolder.transform;
		towerReadyToBuild = false;
		towerInCreation = null;
		lastOverCell = null;


		//and finally make all enemies recalculate their path to current targets (performed by the game manager)
		gameManager.RecaltulateAllEnemiesPath();
	}

	//invoked from GUI buttons
	public void CreateTower (int index){
		//if already creating tower then do nothing
		if (towerInCreation)
			return;
		//if not enought cash then do nothing
		if (availableTowers[index].GetComponent<Tower>().cost > gameManager.cash)
			return;

		towerInCreation = (GameObject) Instantiate (availableTowers[index],Vector3.zero,Quaternion.identity);

		//if not enought cash then do nothing
		/*
		if (towerInCreation.GetComponent<Tower>().cost >gameManager.cash){
			Destroy (towerInCreation);
			return;
		}
		*/
		towerReadyToBuild = true;
	}


	//recalculate path for all enemyes

}
