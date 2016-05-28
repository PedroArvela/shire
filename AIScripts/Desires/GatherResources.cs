using UnityEngine;
using Scripts.AI.Beliefs;
using System.Collections.Generic;
using System;

namespace Scripts.AI.Desires
{
	public class GatherResources : Desire
	{
		public GatherResources (GameObject self)
		{
			this.self = self;
			this.targetType = Elements.RESOURCE;
			this.attribute = Elements.COUNT;
			this.goal = FuzzyLogicGoal.Increase;
		}

		public override string Type ()
		{
			return "GatherResources";
		}

		public override void updateDesire (List<Belief> beliefs)
		{
			List<Belief> resourceBeliefs = beliefs.FindAll (b => b.Subject.tag == Elements.RESOURCE);
			Belief villageBelief = beliefs.Find (b => b.Subject.tag == Elements.VILLAGE);
			Belief selfBelief = beliefs.Find (b => b.Subject.Equals (self));

			if (selfBelief.attributes [Elements.RESOURCE] >= selfBelief.attributes [Elements.MAXRESOURCE]) {
				this.intensity = 0f;
				return;
			}

			// Have the intensity be inverse to the proportion of resources believed to be in the village
			if (villageBelief != null) {
				// TODO: Have in mind the certainty about this
				this.intensity = 1f / (float)Math.Sqrt (villageBelief.attributes [Elements.RESOURCE]);
				return;
			}

			float intensity = 0;
			foreach (Belief belief in resourceBeliefs) {
				intensity += belief.attributes [Elements.RESOURCE];
			}

			this.intensity = Math.Min (1f, intensity / (selfBelief.attributes [Elements.MAXRESOURCE] - selfBelief.attributes [Elements.RESOURCE]));
		}
	}
}