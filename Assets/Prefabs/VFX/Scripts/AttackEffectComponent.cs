﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffectComponent : MonoBehaviour {

	public float speed;
	public float timeLife;
	public Vector2 originPosition;

	private GameObject parent;
	private Character parentCharacter;
	private Rigidbody2D myRigidBody;
	private float initTime;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myRigidBody.velocity = transform.right * speed;
		initTime = Time.time;
		parent = this.gameObject.transform.parent.gameObject;
		parentCharacter = parent.GetComponent<Character> ();
	}
	
	// Update is called once per frame
	void Update () {
		var range = parentCharacter.Fighter.Range;

		if (Vector2.Distance (originPosition, this.transform.position) > range)
		{
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (parent.GetInstanceID() != other.gameObject.GetInstanceID()) {

			var otherGameObject = other.gameObject;

			var characterTarget = otherGameObject.GetComponent<Character> ();
			if (characterTarget != null) {
				parentCharacter.DamageCharacter(characterTarget);
			}
			else if(otherGameObject.GetComponent<InteractibleObject>() != null)
			{
				var interactibleObject = otherGameObject.GetComponent<InteractibleObject> ();
				var u = interactibleObject.Health;
			}
		}
	}
}
