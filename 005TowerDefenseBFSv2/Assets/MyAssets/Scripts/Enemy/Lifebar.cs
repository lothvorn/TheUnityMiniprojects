using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour {

	//references to external (keep public)
	GameObject mainCamera;

	//references to external objects (in enemy) (keep public)
	public RectTransform canvas;
	public Slider slider;

	void Start (){
		mainCamera = GameObject.Find ("Main Camera");
	}

	// Update is called once per frame
	void Update () {
		canvas.LookAt (mainCamera.transform);
		canvas.eulerAngles = new Vector3 (-mainCamera.transform.eulerAngles.x, mainCamera.transform.eulerAngles.y-180);


	}

	public void UpdateValue (float newValue){
		slider.value = newValue;

	}

}
