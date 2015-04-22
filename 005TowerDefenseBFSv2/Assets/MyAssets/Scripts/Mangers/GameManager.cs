using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//game parameters (keep public)
	public int maxEnemies = 5;

	public int enemiesToInstantiate;
	public int destroyedCrystals;



	//to hide
	public int score;
	public int cash;
	public int maxCrystals;





	//references to external
	public GUIManager guiManager;
	public GameOverGUI guiGameOver;

	public void Start (){
		guiManager.SetCash (cash);
		guiManager.SetScore (score);
		enemiesToInstantiate = maxEnemies;
		maxCrystals = GameObject.FindGameObjectsWithTag("Crystal").Length;

	}

	public void Update (){
		if (score + destroyedCrystals >= maxEnemies)
			GameWon();
		if (destroyedCrystals >= maxCrystals)
			GameLost();


	}

	public void SetCash(int _cash){
		cash = _cash;
		guiManager.SetCash (cash);
	}

	public void SetScore (int _score){
		score += _score;
		guiManager.SetScore (score);
	}


	public void RecaltulateAllEnemiesPath(){
		GameObject [] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject en in enemies){
			en.GetComponent<Enemy>().ResetPath();
		}

	}


	private void GameWon (){

		guiGameOver.WinCanvas();
	}

	private void GameLost(){
		guiGameOver.LoseCanvas ();
	}
}
