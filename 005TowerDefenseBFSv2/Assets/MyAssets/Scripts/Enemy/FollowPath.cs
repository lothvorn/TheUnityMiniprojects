using UnityEngine;
using System.Collections;


public class FollowPath : MonoBehaviour {

	//publics (keep public)
	public float speed = 0.5f;
	public float waypointReachedDistance = 0.01f;

	//public references to other objects in the prefab (keep public)
	public Enemy enemy;

	//private (to hide)
	public ArrayList path; 

	public BoardCell currentWaypoint = null;
	public bool targetReached = false;
	// Use this for initialization
	void Start () {
		/*
		//for testing
		path.Add (GameObject.Find ("WP1"));
		path.Add (GameObject.Find ("WP2"));
		path.Add (GameObject.Find ("WP3"));
		//for testing end
		*/
		//GetNextWaypoint();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (targetReached)
			return;
		if (path == null)
			return;

		MoveToCurrentWP();
		CheckWaypointReached();

	}



	public void SetInitialPath (ArrayList initialPath){
		SetNewPath (initialPath);
		GetNextWaypoint ();
	}
	public void SetNewPath (ArrayList newPath){
		if (path != null)
			path.Clear ();
		path = newPath;
		GetNextWaypoint ();
//		GetNextWaypoint ();

	}


	public void GetNextWaypoint(){
		if (path == null)
			return;
		if (path.Count == 0){
			targetReached = true;
			return;
		}

		enemy.currentCell = currentWaypoint;
		currentWaypoint = (BoardCell) path[0];

		path.RemoveAt(0);
	}

	private void MoveToCurrentWP(){

		Vector3 heading = currentWaypoint.waypoint.transform.position - transform.position;
		Vector3 direction = heading/heading.magnitude;

		transform.Translate (direction * speed * Time.deltaTime);

	}

	private void CheckWaypointReached(){
		Vector3 heading = transform.position - currentWaypoint.waypoint.transform.position;

		if (heading.magnitude <= waypointReachedDistance){
			GetNextWaypoint();
		}
	
	}
}
