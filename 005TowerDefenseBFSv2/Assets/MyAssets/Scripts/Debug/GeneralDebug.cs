using UnityEngine;
using System.Collections;

public class GeneralDebug : MonoBehaviour {
	public GameObject instantiate;

	// Use this for initialization
	void Start () {
		Debug.Log ("Pre instantiate");
		Instantiate (instantiate, Vector3.zero,Quaternion.identity);
		Debug.Log ("Post instantiate");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
