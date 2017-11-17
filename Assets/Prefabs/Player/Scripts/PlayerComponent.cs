using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AssemblyCSharp;

public class PlayerComponent : Character {

	public float moveSpeed;

	private bool playerMoving;
	private Vector2 lastMove;
	private Rigidbody2D playerRigidBody;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		playerRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerMoving = false;

		if (Input.GetMouseButtonDown (0))
		{
			var mousePosition = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var characterPosition = (Vector2) transform.position;

			var angle = Utils.AngleBetweenVector2 (characterPosition,mousePosition);

			Attack (Quaternion.Euler(new Vector3(0,0,angle)));
		}

		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
		{
			//transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			playerRigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRigidBody.velocity.y);
			playerMoving = true;
			lastMove = new Vector2 (Input.GetAxisRaw("Horizontal"),0f);
		}

		if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
		{
			//transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
			playerMoving = true;
			lastMove = new Vector2 (0f,Input.GetAxisRaw("Vertical"));
		}

		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f)
		{
			playerRigidBody.velocity = new Vector2 (0f, playerRigidBody.velocity.y);
		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f)
		{
			playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, 0f);
		}

		animator.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		animator.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		animator.SetBool ("PlayerMoving", playerMoving);
		animator.SetFloat ("LastMoveX", lastMove.x);
		animator.SetFloat ("LastMoveY", lastMove.y);
	}
}
