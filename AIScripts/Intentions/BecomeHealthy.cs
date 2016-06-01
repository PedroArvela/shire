using UnityEngine;
using System.Collections;

namespace Scripts.AI.Intentions
{
	public class BecomeHealthy : Intention
	{
		public BecomeHealthy ()
		{
			Goal = Elements.IS_HEALTHY;
		}
	}
}
