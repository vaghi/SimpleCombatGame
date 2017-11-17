using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcComponent : Character {

	public float moveSpeed;
	public float timeBetweenMove;
	public float timeToMove;

	private Rigidbody2D myRigidBody;
	private bool moving;
	private Vector3 moveDirection;
	private float timeBetweenMoveCounter;
	private float timeToMoveCounter;

	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (moving)
		{
			timeToMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = moveDirection;

			if (timeToMoveCounter < 0f)
			{
				moving = false;
				animator.SetFloat ("MoveX", 0f);
				animator.SetFloat ("MoveY", 0f);

				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidBody.velocity = Vector3.zero;

			if (timeBetweenMoveCounter < 0f)
			{
				moving = true;
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

				moveDirection = new Vector3(Random.Range(-1f,1f) * moveSpeed, Random.Range(-1f,1f) * moveSpeed, 0f);
				animator.SetFloat ("MoveX", moveDirection.x);
				animator.SetFloat ("MoveY", moveDirection.y);

				animator.SetFloat ("LastMoveX", moveDirection.x);
				animator.SetFloat ("LastMoveY", moveDirection.y);
			}
		}

		animator.SetBool("Moving" , moving);
	}
}
