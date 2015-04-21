using UnityEngine;
using System.Collections;

public class NavigationManager : MonoBehaviour {

	public bool moving = false;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (1)){
			moving = true;
		} else{
			if (Input.GetMouseButtonUp (1))
				moving = false;
		}


		if (moving){

		}
	
	}
}
