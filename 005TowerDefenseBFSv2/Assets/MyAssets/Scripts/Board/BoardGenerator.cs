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
	public GameObject enemyInstantiator;
	public GameObject crystal;

	// Use this for initialization
	void Start () {
		Vector3 creationPointer = new Vector3 (0,0);




		BoardCell [,] boardMatrix = new BoardCell[xSize, ySize];

		//first create the cell game objects and use boardMatrix to track them
		for (int x = 0; x < xSize; x++){
			for (int y = 0; y < ySize; y++){
				GameObject newCell = (GameObject) Instantiate (cell, creationPointer, Quaternion.identity);
	
				newCell.transform.name = "Cell " + x + "-" + y;
				newCell.transform.parent = boardHolder.transform;
				newCell.GetComponentInChildren<TextMesh>().text = x + "-"+ y;
				//boardMatrix [x,y] = newCell;
				boardMatrix [x,y] = newCell.GetComponent<BoardCell>();


				creationPointer.x++;
			}
			creationPointer.x = 0;
			creationPointer.z++;
		}
	//for testing
		GameObject inst = (GameObject) Instantiate (enemyInstantiator,new Vector3 (0,0,0),Quaternion.identity);
		inst.transform.parent = boardHolder.transform;
		inst.GetComponent<Instantiator>().boardCell = boardMatrix [0,0];

		GameObject crys = (GameObject) Instantiate (crystal,new Vector3 (xSize-1,0,ySize-1),Quaternion.identity);
		crys.transform.parent = boardHolder.transform;
		crys.GetComponent<Crystal>().cell = boardMatrix [xSize-1,ySize-1];

		 crys = (GameObject) Instantiate (crystal,new Vector3 (2,0,3),Quaternion.identity);
		crys.transform.parent = boardHolder.transform;
		crys.GetComponent<Crystal>().cell = boardMatrix [3,2];

		 crys = (GameObject) Instantiate (crystal,new Vector3 (2,0,2),Quaternion.identity);
		crys.transform.parent = boardHolder.transform;
		crys.GetComponent<Crystal>().cell = boardMatrix [2,2];
	//for testing end

		//now use boardMatrix to link each cell to its neighbours. Each cell will kwnow who are its neighbours
		for (int y = 0; y < ySize; y++){
			for (int x = 0; x < ySize; x++){
				SetNeighbours(x,y, boardMatrix);
			}
		}


	}


	//private void SetNeighbours(int x, int y, GameObject [,] board){
	private void SetNeighbours(int x, int y, BoardCell [,] board){

		if (x > 0)
			board[y,x].GetComponent<BoardCell>().children[0] = board [y,x-1]; //west child
		if (x < xSize-1)
			board[y,x].GetComponent<BoardCell>().children[1] = board [y,x+1]; //east child
		if (y>0)
			board [y,x].GetComponent<BoardCell>().children[2] = board [y-1,x]; //south child
		if (y<ySize-1)
			board [y,x].GetComponent<BoardCell>().children[3] = board [y+1,x]; //north child
/*
		if (x > 0)
			board[y,x].GetComponent<BoardCell>().westN = board [y,x-1];
		if (x < xSize-1)
			board[y,x].GetComponent<BoardCell>().eastN = board [y,x+1];
		if (y>0)
			board [y,x].GetComponent<BoardCell>().southN = board [y-1,x];
		if (y<ySize-1)
			board [y,x].GetComponent<BoardCell>().northN = board [y+1,x];
*/
	}



}
