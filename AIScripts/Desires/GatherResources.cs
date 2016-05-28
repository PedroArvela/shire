using UnityEngine;
using System.Collections;

namespace Scripts.AI.Desires
{
	public class GatherResources : Desire
	{
		public GatherResources (float intensity)
		{
			this.targetType = Elements.RESOURCE;
			this.attribute = Elements.COUNT;
			this.goal = FuzzyLogicGoal.Increase;

			this.intensity = intensity;
		}
	}
}