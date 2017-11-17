﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public const int InitialHealth = 1000;
	public const int InitialLevel = 1;
	public const int LevelMultiplicator = 50;

	public GameObject attack;
	public Transform attackSpawn;

	public int Health;
	public int Level;
	public bool Alive;
	public float AttackRate;
	public float HealRate;
	public Fighter Fighter;

	protected Animator animator;

	private float nextAttack;
	private float nextHeal;

	public Character() {
		Health = InitialHealth;
		Level = InitialLevel;
		Alive = true;
	}

	public void Attack(Quaternion quaternion) {

		GameObject attackInstantiated = null;

		if (Time.time > nextAttack) {
			
			attackInstantiated = Instantiate (attack, attackSpawn.position, quaternion);
			
			nextAttack = Time.time + AttackRate;

			attackInstantiated.transform.SetParent(gameObject.transform);
		}
	}

	public void HealCharacter(Character target) {
		if (IsEnemy(target) || !target.Alive) {
			return;
		}

		int heal = Level * LevelMultiplicator;
		target.Health = target.Health + heal >= InitialHealth ? InitialHealth : target.Health + heal;
	}

	public void DamageCharacter(Character target) {
		if (this.gameObject.GetInstanceID() == target.gameObject.GetInstanceID()) {
			return;
		}

		double damage = Level * LevelMultiplicator;

		if (target.Level - 5 >= this.Level) {
			damage = damage * 0.5;
		}
		else if (target.Level + 5 <= this.Level)
		{
			damage = damage * 1.5;
		}

		target.Health = damage <= target.Health ? target.Health - (int) damage : 0;

		if (target.Health.Equals(0)) {
			KillCharacter (target);
			this.Level++;
		}
	}

	public void KillCharacter(Character target)
	{
		target.Alive = false;
		target.gameObject.SetActive(false);
	}

	private bool IsEnemy(Character other)
	{
		return other.GetInstanceID() != this.GetInstanceID();
	}
}