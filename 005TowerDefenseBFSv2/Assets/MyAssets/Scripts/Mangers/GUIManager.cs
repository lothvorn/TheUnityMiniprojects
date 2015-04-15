using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

	//references to external (GUI elements)
	public Text cashText;
	public Text scoreText;


	public void SetCash (int newCash){
		cashText.text = newCash.ToString();	
	}

	public void SetScore (int newScore){
		scoreText.text = newScore.ToString();
	}


}
