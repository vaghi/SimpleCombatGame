using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeFighter : Fighter
{
	public override int Range { get { return 2; } }
	public override int Damage { get { return 5; } }
}
