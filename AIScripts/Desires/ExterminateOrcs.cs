using UnityEngine;
using System.Collections.Generic;
using Scripts.AI.Beliefs;
using Scripts.AI.Emotions;

namespace Scripts.AI.Desires
{
	public class ExterminateOrcs : Desire
	{
		public ExterminateOrcs (GameObject self)
		{
			this.self = self;
			this.targetType = Elements.ORC;
			this.attribute = Elements.COUNT;
			this.goal = FuzzyLogicGoal.None;
		}

		public override DesireType Type ()
		{
			return DesireType.ExterminateOrcs;
		}

		public override void updateDesire (List<Belief> beliefs, Emotion emotion)
		{
			List<Belief> orcBeliefs = beliefs.FindAll (b => b.Subject.tag == Elements.ORC);
			float maxDesire = 0;
			float desire = 0;

			if (orcBeliefs.Count == 0) {
				this.intensity = 0f;
				return;
			}

			// The intensity is as strong as you are sure how many Orcs there are
			// with a lot of health.
			foreach (Belief orcBelief in orcBeliefs) {
				float orcHealth = orcBelief.attributes [Elements.HEALTH];
				float maxOrcHealth = orcBelief.attributes [Elements.MAX_HEALTH];
				float certainty = orcBelief.Certainty;

				maxDesire += maxOrcHealth;
				desire += orcHealth * certainty;
			}

			this.intensity = desire / maxDesire;

			// If angry, give intensity, otherwise remove
			this.intensity -= (1f - this.intensity) * emotion.intensity * emotion.valence;
		}
	}
}