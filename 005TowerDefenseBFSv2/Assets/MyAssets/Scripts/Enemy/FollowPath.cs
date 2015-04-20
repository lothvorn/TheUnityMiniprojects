using UnityEngine;
using System.Collections;


public class FollowPath : MonoBehaviour {

	//publics (keep public)
	public float speed = 0.5f;
	public float waypointReachedDistance = 0.01f;

	//private (to hide)
	public ArrayList path = new ArrayList();
	public GameObject currentWaypoint = null;
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
		GetNextWaypoint();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (targetReached)
			return;
		MoveToCurrentWP();
		CheckWaypointReached();

	}



	private void GetNextWaypoint(){
		if (path.Count == 0){
			targetReached = true;
			return;
		}
		currentWaypoint = (GameObject) path[0];
		path.RemoveAt(0);
	}

	private void MoveToCurrentWP(){
		Vector3 heading = currentWaypoint.transform.position - transform.position;
		Vector3 direction = heading/heading.magnitude;

		transform.Translate (direction * speed * Time.deltaTime);

	}

	private void CheckWaypointReached(){
		Vector3 heading = transform.position - currentWaypoint.transform.position;

		//Debug.Log (heading.magnitude);

		if (heading.magnitude <= waypointReachedDistance){
			GetNextWaypoint();
		}
	
	}
}
