using UnityEngine;
using System.Collections;

public class Instantiator : BoardElement {

	//references to external (keep public)
	public GameObject enemyToInstantiate;
	public float spawnDelayMin = 2.5f;
	public float spawnDelayMax = 15f;
	public float delay = 2.5f;

	//refeernces to external (hide in inspector)
	//public BoardCell boardCell;

	//to set private
	float delayTimer = 0f;
	GameManager gameManager;
	GameObject enemiesHolder;



	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		enemiesHolder = GameObject.Find ("EnemiesHolder");
		boardCell.blocked = true;
		delay = Random.Range (spawnDelayMin, spawnDelayMax);


	}
	
	// Update is called once per frame
	void Update () {

		if (gameManager.enemiesToInstantiate <=0)
			return;

		delayTimer += Time.deltaTime;

		if (delayTimer >= delay){
			delayTimer = 0;
			InstantiateEnemy ();
			gameManager.enemiesToInstantiate--;

		}
	}

	private void  InstantiateEnemy(){
		//Vector3 initialPos = new Vector3 (boardCell.pathCenter.transform.position.x,boardCell.pathCenter.transform.position.y, boardCell.pathCenter.transform.position.z);
		Vector3 initialPos = boardCell.waypoint.transform.position;
		GameObject newEnemy = (GameObject)Instantiate   (enemyToInstantiate,initialPos,Quaternion.identity);
		//GameObject newEnemy = (GameObject)Instantiate (enemyToInstantiate,boardCell.pathCenter.transform.position,Quaternion.identity);

		newEnemy.transform.parent =enemiesHolder.transform;
		newEnemy.GetComponent<Enemy>().currentCell = boardCell;
	}
}
