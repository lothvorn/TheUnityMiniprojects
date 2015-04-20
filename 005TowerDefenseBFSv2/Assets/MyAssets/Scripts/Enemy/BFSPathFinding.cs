using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BFSPathFinding : MonoBehaviour {

	public GameObject []cells;

	// Use this for initialization
	void Start () {
		cells = GameObject.FindGameObjectsWithTag ("BoardCell");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public ArrayList BFSMethod (BoardCell start, BoardCell target){
		ArrayList calculatedPath = new ArrayList();

		//first reset cells flags
		ResetAllVerifiedFlags();
		BoardCell final = null;

		//check if start and targets are the same node and return the arraylist
		if (start == target){
			calculatedPath.Add (start);
			return calculatedPath;
		}

		//create neighbours queue and, for the beginning, put the start neighbours
		Queue <BoardCell> queue = new Queue <BoardCell>();
		BoardCell[] children = start.children;
		foreach (BoardCell bc in children){
			if (bc == null) continue;
			if (bc.blocked) continue;

			bc.parent = start;
			queue.Enqueue (bc);
		}

		//at this point all first node neighbours are equeued and ready to process
		start.verified = true;

		//and now keep going with the search
		while (queue.Count > 0){
			//get first cell
			BoardCell n = queue.Dequeue();
			n.verified = true;

			//check if it's the target
			if ( n == target){
				final = n;
				break;
			}

			//if loop enters here then the last checked vertex is not the target. Put its neighbours in queue
			BoardCell[] c = n.children;
			foreach ( BoardCell bc in c){
				if (bc == null) continue;
				if (bc.verified) continue;
				if (bc.blocked) continue;

				bc.parent = n;
				queue.Enqueue(bc);
				bc.verified = true;
			}

		}

		//if final = null then there is no valid path
		if (final == null)
			return null;

		//get last cell parent
		BoardCell parent = final.parent;
		//List <BoardCell> list = new List<BoardCell>();
		ArrayList list = new ArrayList();

		//and invert order to rebuild path
		while (parent != null){
			list.Add (final);
			final = parent;
			parent = final.parent;
		}

		//and finally add the last case
		list.Add (final);

		//at this point list is a list from target to origin. It has to be reversed
		list.Reverse ();



		return list; //delete this
	}

	private void ResetAllVerifiedFlags (){
		foreach (GameObject go in cells){
			go.GetComponent<BoardCell>().verified = false;
			go.GetComponent<BoardCell>().parent = null;
		}

	}
}
