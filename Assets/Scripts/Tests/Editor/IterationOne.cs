using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class IterationOneTest
{
	[Test]
	public void NewCharacterInitialHealth()
	{
		GameObject newGameObject = new GameObject ();
		var newCharacter = newGameObject.AddComponent<Character> ();

		Assert.AreEqual(Character.InitialHealth, newCharacter.Health);
	}

	[Test]
	public void NewCharacterInitialLevel()
	{
		GameObject newGameObject = new GameObject ();
		var newCharacter = newGameObject.AddComponent<Character> ();

		Assert.AreEqual(1, newCharacter.Level);
	}

	[Test]
	public void NewCharacterInitialAlive()
	{
		GameObject newGameObject = new GameObject ();
		var newCharacter = newGameObject.AddComponent<Character> ();

		Assert.AreEqual(true, newCharacter.Alive);
	}

	[Test]
	public void DamageHealth()
	{
		
		GameObject attacker = new GameObject ();
		var attackerCharacter = attacker.AddComponent<Character> ();

		GameObject target = new GameObject ();
		var targetCharacter = target.AddComponent<Character> ();

		attackerCharacter.DamageCharacter(targetCharacter);

		Assert.AreEqual(Character.InitialHealth, targetCharacter.Health + attackerCharacter.DamageQuantity());
	}

	[Test]
	public void KillCharacter()
	{
		GameObject attacker = new GameObject ();
		var attackerCharacter = attacker.AddComponent<Character> ();

		GameObject target = new GameObject ();
		var targetCharacter = target.AddComponent<Character> ();

		while (targetCharacter.Health > 0)
		{
			attackerCharacter.DamageCharacter(targetCharacter);
		}

		Assert.AreEqual(0, targetCharacter.Health);
		Assert.IsFalse(targetCharacter.Alive);
	}

	[Test]
	public void HealCharacter()
	{
		GameObject healer = new GameObject ();
		var healerCharacter = healer.AddComponent<Character> ();

		healerCharacter.Health = 100;

		healerCharacter.HealCharacter(healerCharacter);
		Assert.AreEqual(healerCharacter.Health, 100 + healerCharacter.HealQuantity());
	}

	[Test]
	public void MaximumHeal()
	{
		GameObject healer = new GameObject ();
		var healerCharacter = healer.AddComponent<Character> ();

		healerCharacter.Health = Character.InitialHealth - 1;

		healerCharacter.HealCharacter(healerCharacter);
		Assert.AreEqual(healerCharacter.Health, Character.InitialHealth);
	}

	[Test]
	public void MaximumHealTop()
	{
		GameObject healer = new GameObject ();
		var healerCharacter = healer.AddComponent<Character> ();

		GameObject healed = new GameObject ();
		var healedCharacter = healed.AddComponent<Character> ();

		healerCharacter.HealCharacter(healedCharacter);
		Assert.AreEqual(healedCharacter.Health, Character.InitialHealth);
	}
}
