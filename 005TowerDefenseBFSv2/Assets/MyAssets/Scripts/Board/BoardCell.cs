using UnityEngine;
using System.Collections;

public class BoardCell : MonoBehaviour {
	//for pathfinding algorithims (to hide)
	public bool verified = false;
	public BoardCell parent = null;
	public GameObject waypoint;
	public bool blocked = false;

	//cell neighbours
	public BoardCell [] children;
 
	/*
	public GameObject northN;
	public GameObject eastN;
	public GameObject southN;
	public GameObject westN;
	*/


	public GameObject pathCenter;

	
}
