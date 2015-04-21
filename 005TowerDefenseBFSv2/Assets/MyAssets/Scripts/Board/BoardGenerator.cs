using UnityEngine;
using System.Collections;

/*
 * create and link board objects in
 */


public class BoardGenerator : MonoBehaviour {
	//public
	public int xSize=5;
	public int ySize=5;
	public float spawnerFrequency = .7f;
	public float blockerFrequency = .1f;

	//references to other game objects
	public GameObject boardHolder;
	public GameObject cell;
	public GameObject enemyInstantiator;
	public GameObject crystal;
	public GameObject blocker;
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
				boardMatrix [x,y] = newCell.GetComponent<BoardCell>();


				creationPointer.x++;
			}
			creationPointer.x = 0;
			creationPointer.z++;
		}
	
		//now instantiate crystals and spanwers
		InstantiateAllSpawners(boardMatrix);
		InstantiateAllCrystals (boardMatrix);
		InstantiateAllBlockers (boardMatrix);
/*
		 crys = (GameObject) Instantiate (crystal,new Vector3 (2,0,3),Quaternion.identity);
		crys.transform.parent = boardHolder.transform;
		crys.GetComponent<Crystal>().cell = boardMatrix [3,2];

		 crys = (GameObject) Instantiate (crystal,new Vector3 (2,0,2),Quaternion.identity);
		crys.transform.parent = boardHolder.transform;
		crys.GetComponent<Crystal>().cell = boardMatrix [2,2];
*/
	//for testing end

		//now use boardMatrix to link each cell to its neighbours. Each cell will kwnow who are its neighbours
		for (int y = 0; y < ySize; y++){
			for (int x = 0; x < xSize; x++){
				SetNeighbours(x,y, boardMatrix);
			}
		}


	}


	//private void SetNeighbours(int x, int y, GameObject [,] board){
	private void SetNeighbours(int x, int y, BoardCell [,] board){
		if (x>0)
			board [x,y].GetComponent<BoardCell>().children[0] = board[x-1,y]; //south child


		if (x < xSize-1)
			board[x,y].GetComponent<BoardCell>().children[1] = board [x+1,y]; //north child
	
		if (y>0)
			board [x,y].GetComponent<BoardCell>().children[2] = board [x,y-1]; //south child
		if (y<ySize-1)
			board [x,y].GetComponent<BoardCell>().children[3] = board [x,y+1]; //north child

	}



	private void InstantiateBoardElement (GameObject be, Vector3 position, BoardCell [,] board){
		GameObject inst = (GameObject) Instantiate (be,position,Quaternion.identity);
		inst.transform.parent = boardHolder.transform;
		
		inst.GetComponent<BoardElement>().boardCell = board [(int)position.z,(int)position.x];
		inst.GetComponent<BoardElement>().boardCell.collider.enabled = false;
	}

	


	private void InstantiateAllSpawners(BoardCell [,] board){
		//first spawner is mandatory
		InstantiateBoardElement (enemyInstantiator, new Vector3 (0,0,0), board);
		for (int i = 1; i < ySize; i++){
			if (Random.Range (0,100)<=spawnerFrequency){
				InstantiateBoardElement ( enemyInstantiator,new Vector3 (i,0,0), board);
			}
		}
	}

	private void InstantiateAllCrystals(BoardCell [,] board){
		for (int i = 0; i < ySize; i++){
			InstantiateBoardElement (crystal, new Vector3 (i, 0, xSize - 1), board);
			//InstantiateSingleChrystal (new Vector3 (i,0,xSize-1),board);
		}
	}

	private void InstantiateAllBlockers (BoardCell [,] board){
		for (int i = 0; i < ySize; i++){
			for (int j = 2; j < xSize -1; j++){
				if (Random.Range (0,100) <= blockerFrequency){
					InstantiateBoardElement (blocker, new Vector3 (i, 0, j), board);
				}
			}
		}
	}
		 

}
