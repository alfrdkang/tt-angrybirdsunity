using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LauncherScript : MonoBehaviour
{
	public GameObject birdPrefab;   //which prefab will be spawned in
	public float firingSensitivity;
	public float maxTimeToHoldFire;
	public int maxBirdsToCreate;

	private float initialTime;
	private int birdsCreated = 0;
	private bool isFiring = false;
	private bool endGame = false;
	Vector3 firingVector;

	// Start is called before the first frame update
	void Start()
	{
		//nothing to do at the start, only do stuff when we click
	}

	// Update is called once per frame
	void Update()
	{
		//if game has ended we don't bother checking the rest
		if (endGame)
		{
			return;
		}


		//checking for mouseclick down to fire a bird
		if (Input.GetMouseButtonDown(0))
		{
			//get time when mouse is clicked
			Debug.Log("Mouse Button Down!");
            initialTime = Time.time;
            isFiring = true; //this bool is here because when you spam click the mouse button, you can GetMouseButtonUp to trigger but not GetMouseButtonDown sometimes
        }

		//when mouse button is released, create and fire a bird
		else if (Input.GetMouseButtonUp(0))
		{

			Debug.Log("Mouse Button Up!");

			//spawn the bird
			birdsCreated++;
			GameObject birdGameObject = Instantiate(birdPrefab, transform.position, transform.rotation);//similar Instantiate code exists in the dodgeball game

			//adjusting the position of the bird
			birdGameObject.transform.position -= transform.forward * 1f;
			birdGameObject.transform.position += transform.up * 1f;

			//check for how much force to fire the bird with
			float firingForceMultiplier;
			if (Time.time - initialTime > maxTimeToHoldFire)
			{
				firingForceMultiplier = maxTimeToHoldFire * firingSensitivity;
			}
			else
			{
				firingForceMultiplier = (Time.time - initialTime) * firingSensitivity;
			}

			//firing the bird
			firingVector = new Vector3(20, 20, 0);    //define the firingVector we will use for Rigidbody.AddForce, remember the bird needs to go up and forward!
            birdGameObject.GetComponent<Rigidbody>().AddForce(firingVector * firingForceMultiplier, ForceMode.Impulse);

            //if the player runs out of birds, end the game
            if (maxBirdsToCreate == birdsCreated)
			{
				endGame = true;
			}

			isFiring = false;
		}

		//if there are no more blocks left, end the game
		if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
		{
			endGame = true;
		}
	}
}
