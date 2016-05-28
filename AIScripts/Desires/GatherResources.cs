using UnityEngine;
using System.Collections;

namespace Scripts.AI.Desires
{
	public class GatherResources : Desire
	{
		public GatherResources (GameObject self, float intensity)
		{
			this.self = self;
			this.targetType = Elements.RESOURCE;
			this.attribute = Elements.COUNT;
			this.goal = FuzzyLogicGoal.Increase;

			this.intensity = intensity;
		}
	}
}