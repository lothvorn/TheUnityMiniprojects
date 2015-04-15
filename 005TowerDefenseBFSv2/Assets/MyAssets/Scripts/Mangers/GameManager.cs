using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//to hide
	public int score;
	public int cash;

	//references to external
	public GUIManager guiManager;

	public void Start (){
		guiManager.SetCash (cash);
		guiManager.SetScore (score);
	}

	public void SetCash(int _cash){
		cash = _cash;
		guiManager.SetCash (cash);
	}

	public void SetScore (int _score){
		score = _score;
		guiManager.SetScore (_score);
	}
}
