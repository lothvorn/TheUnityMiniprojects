using UnityEngine;
using System.Collections;

/*
 * create and link board objects in
 */


public class BoardGenerator : MonoBehaviour {
	//public
	public int xSize=5;
	public int ySize=5;

	//references to other game objects
	public GameObject boardHolder;
	public GameObject cell;

	// Use this for initialization
	void Start () {
		Vector3 creationPointer = new Vector3 (0,0);

		GameObject [,] boardMatrix = new GameObject[xSize, ySize];

		//first create the cell game objects and use boardMatrix to track them
		for (int x = 0; x < xSize; x++){
			for (int y = 0; y < ySize; y++){
				GameObject newCell = (GameObject) Instantiate (cell, creationPointer, Quaternion.identity);
				newCell.transform.name = "Cell " + x + "-" + y;
				newCell.transform.parent = boardHolder.transform;
				newCell.GetComponentInChildren<TextMesh>().text = x + "-"+ y;
				boardMatrix [x,y] = newCell;

				creationPointer.x++;
			}
			creationPointer.x = 0;
			creationPointer.z++;
		}


		//now use boardMatrix to link each cell to its neighbours. Each cell will kwnow who are its neighbours
		for (int y = 0; y < ySize; y++){
			for (int x = 0; x < ySize; x++){
				SetNeighbours(x,y, boardMatrix);
			}
		}


	}


	private void SetNeighbours(int x, int y, GameObject [,] board){
		if (x > 0)
			board[y,x].GetComponent<BoardCell>().westN = board [y,x-1];
		if (x < xSize-1)
			board[y,x].GetComponent<BoardCell>().eastN = board [y,x+1];
		if (y>0)
			board [y,x].GetComponent<BoardCell>().southN = board [y-1,x];
		if (y<ySize-1)
			board [y,x].GetComponent<BoardCell>().northN = board [y+1,x];

	}



}
