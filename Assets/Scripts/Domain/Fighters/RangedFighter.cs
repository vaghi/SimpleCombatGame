using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedFighter : Fighter
{
	public override int Range { get { return 20; } }
	public override int Damage { get { return 1; } }
}
