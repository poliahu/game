using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight= true;
	public int playerJumpPower = 1250;
	private float moveX;
	public bool isGrounded;
	public float distanceToBottomOfPlayer = 0.9f;



	// Update is called once per frame
	void Update () {
		PlayerMove ();
		PlayerRaycast ();
	}

	void PlayerMove() {
		//CONTROLS
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded == true){
			Jump();
		}
		//ANIMATIONS
		//PLAYER DIRECTION
		if (moveX > 0.0f && facingRight == false) {
			FlipPlayer ();
		} else if (moveX < 0.0f && facingRight == true) {
			FlipPlayer ();
		}
		//PHYSICS
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump() {
		//JUMPING CODE
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	void FlipPlayer () {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= 1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D (Collision2D col){
	
	}

	void PlayerRaycast () {
		//RayUp
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position,Vector2.up);
		if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer && rayUp.collider.name == "Box_2") {
			Destroy (rayUp.collider.gameObject);
		}
			//RayDown
			RaycastHit2D rayDown = Physics2D.Raycast (transform.position,Vector2.down);
		if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "Enemy") {
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 200);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 8;
			rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			rayDown.collider.gameObject.GetComponent<Enemy_Move> ().enabled = false;
			}
		if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag != "enemy") {
		isGrounded = true;
			}
		}
	}
