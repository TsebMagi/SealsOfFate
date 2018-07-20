using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TODO: Examine why there's a Player Controller Class
public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	    //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");
        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		player.GetComponent<Entity.EntityBehaviour>().MoveEntity(movement);

		if(Input.GetAxis("Fire1") !=0){
			player.GetComponent<Entity.EntityBehaviour>().CreateMeleeAttack(Camera.main.ScreenToWorldPoint(Input.mousePosition)-player.transform.position, player);
		}
	}
	private GameObject player;
}
