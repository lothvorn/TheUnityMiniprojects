using UnityEngine;
using System.Collections;

public class BoardCellInteractor : MonoBehaviour {


	//references to objects in scene
	public BuildManager buildManager;


	public void Start(){
		buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();
		
	}
	
	
	
	public void OnMouseEnter(){

		buildManager.lastOverCell = transform.parent.gameObject;
	}
}
