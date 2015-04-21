using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//public parameters
	public int maxLife =10;
	public int currentDamage = 0;

	//references to other objecs in prefab (keep public)
	public Lifebar lifebar;


	//references to others (hide in inspector)
	public GameObject currentTarget; //this is a crystal prefab
	//public BoardCell currentTarget;
	public BoardCell currentCell;



	//references to other (set private)
	GameManager gameManager;
	BFSPathFinding bfs;
	FollowPath followPath;

	void Start (){
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		bfs = GameObject.Find ("GameManager").GetComponent<BFSPathFinding>();
		followPath = GetComponent<FollowPath>();

		currentTarget = FindClosestTarget();


		ArrayList newPath = bfs.BFSMethod(currentCell,currentTarget.GetComponent<Crystal>().cell);

		followPath.SetNewPath (newPath);
		//followPath.GetNextWaypoint();
		Debug.Log ("path ready");
	}




	public void ReceiveDamage(int damage){
		currentDamage += damage;

		float normalized = (float) 1 - (float)currentDamage/maxLife;

		lifebar.UpdateValue( normalized );

		if (currentDamage >= maxLife)
			Destroy (gameObject);
	}


	private GameObject FindClosestTarget (){
		GameObject [] crystals = GameObject.FindGameObjectsWithTag("Crystal");
		GameObject closest = null;
		float closestDistance = Mathf.Infinity;
		//Vector3 position = transform.position;
		
		foreach (GameObject cry in crystals){
			Vector3 distanceVector = cry.transform.position - transform.position;
			float thisDistance = distanceVector.magnitude;
			if (thisDistance < closestDistance){
				closest = cry;
				closestDistance = thisDistance;
			}
		}

		return closest;
	}


}
