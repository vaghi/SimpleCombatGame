using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffectComponent : MonoBehaviour {

	public GameObject character;
	public float speed;
	public float timeLife;

	private Rigidbody2D myRigidBody;
	private float initTime;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myRigidBody.velocity = transform.right * speed;
		initTime = Time.time;

		//TestMode
		var parent = this.gameObject.transform.parent.gameObject;
		var character = parent.GetComponent<Character> ();

		if (character.Fighter.Range == 2) {
			timeLife = 0.125f;
		} else if (character.Fighter.Range == 20) {
			timeLife = 1.25f;
		}
		//End TestMode

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > initTime + timeLife) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		var parent = this.gameObject.transform.parent.gameObject;
		var parentCharacter = parent.GetComponent<Character> ();

		if (parent.name != other.gameObject.name) {
			var characterTarget = other.gameObject.GetComponent<Character> ();
			if (characterTarget != null) {
				parentCharacter.DamageCharacter(characterTarget);
			}
		}
	}
}
