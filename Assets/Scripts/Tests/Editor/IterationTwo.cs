using UnityEngine;
using NUnit.Framework;

public class IterationTwoTest
{

	[Test]
	public void CantDamageMyself()
	{
		GameObject attacker = new GameObject ();
		var attackerCharacter = attacker.AddComponent<Character> ();

		attackerCharacter.DamageCharacter(attackerCharacter);

		Assert.AreEqual(Character.InitialHealth, attackerCharacter.Health);
	}

	[Test]
	public void CanHealMyself()
	{
		GameObject healer = new GameObject ();
		var healerCharacter = healer.AddComponent<Character> ();

		var initialHealth = 100;

		healerCharacter.Health = initialHealth;
		healerCharacter.HealCharacter(healerCharacter);

		Assert.AreEqual(initialHealth + healerCharacter.HealQuantity(), healerCharacter.Health);
	}

	[Test]
	public void CantHealEnemies()
	{
		GameObject healer = new GameObject ();
		var healerCharacter = healer.AddComponent<Character> ();

		GameObject enemy = new GameObject ();
		var enemyCharacter = enemy.AddComponent<Character> ();

		var initialHealth = 100;
		 
		enemyCharacter.Health = initialHealth;
		healerCharacter.HealCharacter(enemyCharacter);

		Assert.AreEqual(initialHealth, enemyCharacter.Health);
	}

	[Test]
	public void Target5LevelsAboveDamage()
	{
		GameObject attacker = new GameObject ();
		var attackerCharacter = attacker.AddComponent<Character> ();

		GameObject target;

		for (int lvl = 1; lvl <= 10; lvl++)
		{
			target = new GameObject ();
			var targetCharacter = target.AddComponent<Character> ();

			targetCharacter.Level = lvl;

			var initialHealth = targetCharacter.Health;
			attackerCharacter.DamageCharacter(targetCharacter);
			var damage = initialHealth - targetCharacter.Health;

			if (attackerCharacter.Level <= targetCharacter.Level - 5) {
				var damageExpected = attackerCharacter.DamageQuantity() * 0.5;
				Assert.AreEqual (damage, damageExpected);
			}
			else
			{
				Assert.AreEqual (damage, attackerCharacter.DamageQuantity());
			}
		}
	}

	[Test]
	public void Target5LevelsBelowDamage()
	{
		GameObject attacker = new GameObject ();
		var attackerCharacter = attacker.AddComponent<Character> ();

		GameObject target;

		for (int lvl = 1; lvl <= 10; lvl++)
		{
			target = new GameObject ();
			var targetCharacter = target.AddComponent<Character> ();

			attackerCharacter.Level = lvl;

			var initialHealth = targetCharacter.Health;
			attackerCharacter.DamageCharacter(targetCharacter);
			var damaged = initialHealth - targetCharacter.Health;

			if (attackerCharacter.Level >= targetCharacter.Level + 5) {
				var damageExpected = attackerCharacter.DamageQuantity() * 1.5;
				Assert.AreEqual (damaged, damageExpected);
			}
			else
			{
				Assert.AreEqual (damaged, attackerCharacter.DamageQuantity());
			}
		}
	}
}
