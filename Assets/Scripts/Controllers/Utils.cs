using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public static class Utils
	{
		public static float AngleBetweenVector2(Vector2 myPos, Vector2 targetPos)
		{
			Vector2 direction = myPos - targetPos;
			var angle = Mathf.Atan2(direction.y,  direction.x) * Mathf.Rad2Deg;
			angle += 180f;

			return angle;
		}
	}
}

