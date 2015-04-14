using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {
	//references to prefabs (keep public)
	public GameObject [] availableTowers ;
	public GameObject towersHolder;

	//references to objects in scene (to hide)
	public GameObject lastOverCell = null;
	

	//to hide
	public GameObject towerInCreation = null;



	public void Update (){
		if (lastOverCell != null && towerInCreation != null){
			Debug.Log ("++"+lastOverCell.name);

			Vector3 lastOveredMarker = lastOverCell.GetComponent<BoardCell>().pathCenter.transform.position;
			if (towerInCreation.transform.position != lastOveredMarker)
				towerInCreation.transform.position = lastOveredMarker;


		}
	}

	public void CreateTower (int index){
		towerInCreation = (GameObject) Instantiate (availableTowers[index],Vector3.zero,Quaternion.identity);
	}
}
