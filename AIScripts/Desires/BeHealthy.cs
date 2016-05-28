using UnityEngine;
using Scripts.AI.Beliefs;
using System.Collections.Generic;
using Scripts.Utils;

namespace Scripts.AI.Desires
{
	public class BeHealthy : Desire
	{
		public BeHealthy (GameObject self)
		{
			this.self = self;
			this.targetType = Elements.SELF;
			this.attribute = Elements.HEALTH;
			this.goal = FuzzyLogicGoal.Increase;
		}

		public override string Type ()
		{
			return "BeHealthy";
		}

		public override void updateDesire (List<Belief> beliefs)
		{
			Belief selfBelief = beliefs.Find (b => b.Subject.Equals (self));

			float currentHealth = selfBelief.attributes [Elements.HEALTH];
			float maxHealth = selfBelief.attributes [Elements.MAXHEALTH];

			this.intensity = 1f - (currentHealth / maxHealth);
		}
	}
}