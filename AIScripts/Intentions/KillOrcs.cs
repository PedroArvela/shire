using UnityEngine;
using System.Collections;

namespace Scripts.AI.Intentions
{
	public class KillOrcs : Intention
	{
		public KillOrcs ()
		{
			Goal = Elements.ORC_IS_DEAD;
		}
	}
}