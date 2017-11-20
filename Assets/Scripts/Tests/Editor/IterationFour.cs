using NUnit.Framework;
using UnityEngine;
using System;

public class IterationFourTest
{
	[Test]
	public void NewCharacterWithNoFaction()
	{
		GameObject newGameObject = new GameObject ();
		var newCharacter = newGameObject.AddComponent<Character> ();

		Assert.IsTrue(newCharacter.Factions.Count == 0);
	}

	[Test]
	public void CharacterJoinFactions()
	{
		GameObject newGameObject = new GameObject ();
		var newCharacter = newGameObject.AddComponent<Character> ();

		var factions = Enum.GetValues(typeof(Faction));

		foreach(Faction f in factions)
		{
			newCharacter.JoinFaction(f);
			Assert.IsTrue(newCharacter.Factions.Contains(f));
		}
	}

	[Test]
	public void CharacterLeaveFactions()
	{
		GameObject newGameObject = new GameObject ();
		var newCharacter = newGameObject.AddComponent<Character> ();

		var factions = Enum.GetValues(typeof(Faction));

		foreach(Faction f in factions)
		{
			newCharacter.JoinFaction(f);
			Assert.IsTrue(newCharacter.Factions.Contains(f));
		}

		foreach(Faction f in factions)
		{
			newCharacter.LeaveFaction(f);
			Assert.IsTrue(!newCharacter.Factions.Contains(f));
		}
	}

	[Test]
	public void SameFactionAreAllies()
	{
		GameObject newGameObject = new GameObject ();
		var newCharacter = newGameObject.AddComponent<Character> ();

		GameObject ally = new GameObject();
		var allyCharacter = ally.AddComponent<Character>();

		Assert.IsTrue(newCharacter.IsEnemy(allyCharacter));

		newCharacter.JoinFaction(Faction.Imperial);
		allyCharacter.JoinFaction(Faction.Renegade);

		Assert.IsTrue(newCharacter.IsEnemy(allyCharacter));

		allyCharacter.JoinFaction(Faction.Imperial);

		Assert.IsFalse(newCharacter.IsEnemy(allyCharacter));
	}

	[Test]
	public void AlliesCantAttackEachOther()
	{
		GameObject attacker = new GameObject ();
		var attackerCharacter = attacker.AddComponent<Character> ();

		GameObject ally = new GameObject();
		var allyCharacter = ally.AddComponent<Character>();

		attackerCharacter.JoinFaction(Faction.Renegade);
		allyCharacter.JoinFaction(Faction.Renegade);

		attackerCharacter.DamageCharacter(allyCharacter);

		Assert.AreEqual(Character.InitialHealth, allyCharacter.Health);
	}

	[Test]
	public void AlliesHealsEachOther()
	{
		GameObject healer = new GameObject ();
		var healerCharacter = healer.AddComponent<Character>();

		GameObject ally = new GameObject();
		var allyCharacter = ally.AddComponent<Character>();

		allyCharacter.Health = Character.InitialHealth - 1;
		healerCharacter.HealCharacter(allyCharacter);

		Assert.AreEqual(Character.InitialHealth - 1, allyCharacter.Health);

		healerCharacter.JoinFaction(Faction.Republican);
		allyCharacter.JoinFaction(Faction.Republican);

		healerCharacter.HealCharacter(allyCharacter);

		Assert.AreEqual(Character.InitialHealth, allyCharacter.Health);
	}
}

