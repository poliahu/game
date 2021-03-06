using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour {

	public int EnemySpeed;
	public int xMoveDirection;
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * EnemySpeed;
		if (hit.distance < 0.7f) {
			Flip ();
			if (hit.collider && hit.collider.tag == "Player") {
				Destroy (hit.collider.gameObject);
			}
		}
		if (gameObject.transform.position.y < -50){
			Destroy (gameObject);
		}
	}

	void Flip (){
		if(xMoveDirection > 0) {
			xMoveDirection = -1;
		} else {
			xMoveDirection = 1;	
		}
	}
}