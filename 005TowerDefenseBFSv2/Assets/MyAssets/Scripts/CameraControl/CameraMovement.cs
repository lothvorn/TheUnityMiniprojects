using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed;




	NavigationManager navigationManager;
	// Use this for initialization
	void Start () {
		navigationManager = GameObject.Find("GameManager").GetComponent<NavigationManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!navigationManager.moving){

			return;
		}


		Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Vector3 posicionLocal = transform.localPosition;
		
		if (Input.GetAxis("Vertical") > 0)
			transform.Translate (Vector3.forward*speed*Time.deltaTime);
		
		if (Input.GetAxis("Vertical") < 0)
			transform.Translate( Vector3.back*speed*Time.deltaTime);
		
		if (Input.GetAxis("Horizontal") >0)
			transform.Translate (Vector3.right *speed*Time.deltaTime);
		
		if (Input.GetAxis("Horizontal") < 0)
			transform.Translate (Vector3.left *speed*Time.deltaTime);


	}
}
