using UnityEngine;
using System.Collections;
using Scripts.AI.Beliefs;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Desires
{
	public class BeHealthy : Desire
	{
		public BeHealthy (GameObject self, float intensity)
		{
			this.self = self;
			this.targetType = Elements.SELF;
			this.attribute = Elements.HEALTH;
			this.goal = FuzzyLogicGoal.Increase;

			this.intensity = intensity;
		}

		public override void updateDesire (List<Belief> beliefs)
		{
			Belief selfBelief = beliefs.Find (b => b.Subject.Equals (self));

			float currentHealth = selfBelief.attributes [Elements.HEALTH];
			float maxHealth = selfBelief.attributes [Elements.MAX_HEALTH];

			this.intensity = 1 - (currentHealth / maxHealth);
		}
	}
}