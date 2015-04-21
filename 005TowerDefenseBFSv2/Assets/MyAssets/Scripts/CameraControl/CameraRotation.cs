using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	NavigationManager navigationManager;
	/*
	public float speed=5;
	public float lerpSpeed = 100;


	float xDeg;
	float yDeg;
	Quaternion fromRotation;
	Quaternion toRotation;
	*/

	public float sensibility = 1;
	// Use this for initialization
	void Start () {
		navigationManager= GameObject.Find ("GameManager").GetComponent<NavigationManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!navigationManager.moving)
			return;

		transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X")*sensibility,0), Space.World);
		transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y")*sensibility,0,0));

		/*
		xDeg += Input.GetAxis ("Mouse X") * speed;
		yDeg -= Input.GetAxis ("Mouse Y") * speed;

		fromRotation = transform.rotation;
		toRotation = Quaternion.Euler (yDeg, xDeg,0);
		transform.rotation = Quaternion.Lerp (fromRotation, toRotation, Time.deltaTime * lerpSpeed);
*/
	}
}
