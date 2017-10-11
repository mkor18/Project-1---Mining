using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public int bronzePlayer;
	public int silverPlayer;
	public int goldPlayer;
	public int bronzeSupply;
	public int silverSupply;
	public int goldSupply;
	public int miningSpeed;
	public int timeToMine;

	public GameObject currentCube;
	public GameObject cubePrefab;
	public Vector3 cubePosition; //made this public, not sure if that helps
	public int xPosition;

	// Use this for initialization
	void Start () {
		bronzePlayer = 0;
		silverPlayer = 0;
		goldPlayer = 0;
		miningSpeed = 3;
		bronzeSupply = 100;
		silverSupply = 100;
		goldSupply = 100;
		timeToMine = miningSpeed;
		xPosition = 0;
		cubePosition = new Vector3 (xPosition, 0, 0); //this doesn't work for some reason

	}

	// Update is called once per frame
	void Update () {

		if (Time.time > timeToMine) {
			// mine some ore and update the amount of ore
			xPosition++; //increments 1

			if (bronzeSupply >= 1) {
				bronzeSupply = bronzeSupply - 1;
				bronzePlayer = bronzePlayer + 1;

				currentCube = Instantiate (cubePrefab, new Vector3 (xPosition, 0, 0), Quaternion.identity); //if i put the new Vector3 (xPosition, 0, 0) here, it works... not sure why your cubePosition doesn't work :/
				currentCube.GetComponent<Renderer> ().material.color = Color.red;


			}


			// only mine silver if there's no bronze and we have at least 1 silver 
			if (bronzePlayer >= 4 && silverSupply > 0) {
				silverSupply -= 1;
				silverPlayer += 1;

				currentCube = Instantiate (cubePrefab, new Vector3 (xPosition, 0, 0), Quaternion.identity); //for some reason (i think the else if) the silver position restarts.. not sure you can do else if unless you store xPosition somewhere else as well? no idea!
				currentCube.GetComponent<Renderer> ().material.color = Color.white;
			} else if (bronzePlayer == 2 && silverPlayer > 2) {
				goldSupply -= 1;
				goldPlayer += 1;

				currentCube = Instantiate (cubePrefab, new Vector3 (xPosition, 0, 0), Quaternion.identity); //for some reason (i think the else if) the silver position restarts.. not sure you can do else if unless you store xPosition somewhere else as well? no idea!
				currentCube.GetComponent<Renderer> ().material.color = Color.yellow;
			}

			// tell the player how much ore they have
			print ("Bronze: " +bronzePlayer + "...Silver: " +silverPlayer + "...Gold:" +goldPlayer);

			timeToMine += miningSpeed;



		}


	}
}
