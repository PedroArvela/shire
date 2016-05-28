using UnityEngine;
using System.Collections;

namespace Scripts.AI.Desires
{
	public class BeHealthy : Desire
	{
		public BeHealthy (float intensity)
		{
			this.targetType = Elements.SELF;
			this.attribute = Elements.HEALTH;
			this.goal = FuzzyLogicGoal.Increase;

			this.intensity = intensity;
		}
	}
}