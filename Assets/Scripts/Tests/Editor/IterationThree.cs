using NUnit.Framework;
using UnityEngine;

public class IterationThreeTest
{
    [Test]
    public void MeleeFighterRange()
    {
        GameObject attacker = new GameObject();
        var attackerCharacter = attacker.AddComponent<Character>();
        attackerCharacter.Fighter = new MeleeFighter();

        GameObject target = new GameObject();
        var targetCharacter = target.AddComponent<Character>();

        //Test in 10 x 10 square, randomly positioned - 20 times
        for (var i = 0; i < 20; i++)
        {
            attacker.transform.position = new Vector3(Random.Range(0,9), Random.Range(0,9), 0);
            target.transform.position = new Vector3(Random.Range(0,9), Random.Range(0,9), 0);

            float dist = Vector3.Distance(attacker.transform.position, target.transform.position);

			var attackInitiated = attackerCharacter.Attack(target.transform.position);

            if(dist > attackerCharacter.Fighter.Range)
            {
				Assert.IsFalse (attackInitiated);
            }
            else
            {
				Assert.IsTrue (attackInitiated);
            }
        }
    }

	[Test]
	public void RangedFighterRange()
	{
		GameObject attacker = new GameObject();
		var attackerCharacter = attacker.AddComponent<Character>();
		attackerCharacter.Fighter = new RangedFighter();

		GameObject target = new GameObject();
		var targetCharacter = target.AddComponent<Character>();

		//Test in 10 x 10 square, randomly positioned - 20 times
		for (var i = 0; i < 20; i++)
		{
			attacker.transform.position = new Vector3(Random.Range(0,9), Random.Range(0,9), 0);
			target.transform.position = new Vector3(Random.Range(0,9), Random.Range(0,9), 0);

			float dist = Vector3.Distance(attacker.transform.position, target.transform.position);

			var attackInitiated = attackerCharacter.Attack(target.transform.position);

			if(dist > attackerCharacter.Fighter.Range)
			{
				Assert.IsFalse (attackInitiated);
			}
			else
			{
				Assert.IsTrue (attackInitiated);
			}
		}
	}
}

