using UnityEngine;
using Scripts.AI.Beliefs;
using System.Collections.Generic;
using Scripts.Utils;
using Scripts.AI.Emotions;

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

		public override void updateDesire (List<Belief> beliefs, Emotion emotion)
		{
			float currentHealth = self.GetComponent<CharacterVars> ().currentHealth;
			float maxHealth = self.GetComponent<CharacterVars> ().maxHealth;

			this.intensity = 1f - (currentHealth / maxHealth);

			// Generic boost of intensity when emotive, penalization when depressed
			this.intensity += ((1f - this.intensity) * emotion.intensity);
		}
	}
}