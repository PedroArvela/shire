using UnityEngine;
using System.Collections;
using Scripts.AI.Beliefs;
using System.Collections.Generic;

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

		public override void updateDesire (List<Belief> beliefs)
		{
			throw new System.NotImplementedException ();
		}
	}
}