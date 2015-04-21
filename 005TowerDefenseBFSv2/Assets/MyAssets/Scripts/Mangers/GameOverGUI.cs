using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverGUI : MonoBehaviour {

	public Canvas canvas;
	public Image background;
	public Text text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WinCanvas(){
		background.color = Color.green;
		text.text = "<<GAME WON>>";
		canvas.enabled = true;
	}

	public void LoseCanvas(){
		background.color = Color.red;
		text.text = "<<GAME LOST>>";
		canvas.enabled = true;
	}
}
