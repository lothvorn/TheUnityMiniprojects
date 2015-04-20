using UnityEngine;
using System.Collections;

public class BFSDebugInstantiator : MonoBehaviour {

	public BFSPathFinding bfs;
	public BoardCell origin;
	public BoardCell destiny;

	//public bool processed = false;
	public bool readyToBegin = false;

	ArrayList newPath;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (destiny != null && origin != null && readyToBegin && bfs!= null){
			newPath = bfs.BFSMethod(origin,destiny);
			readyToBegin = false;
			Debug.Log ("final");
		}

	
	}
}
