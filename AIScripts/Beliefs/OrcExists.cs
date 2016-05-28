using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;
using Scripts.AI.Emotions;

namespace Scripts.AI.Beliefs
{
	public class OrcExists : Belief
	{
		public OrcExists (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
		}

		public override void updateBelief (List<Perception> perceptions)
		{
			List<Perception> candidates = perceptions.FindAll (p => p.target.Equals (Subject));

			if (candidates.Count > 0) {
				Certainty = 1f;
				Location = candidates [0].target.transform.position;
			} else {
				Certainty -= 0.05f;
			}

			if (candidates.Exists (p => p.Name == Elements.ATTACK)) {
				attributes [Elements.ATTACK] = 1f;
			} else if (attributes.ContainsKey (Elements.ATTACK) && attributes [Elements.ATTACK] > 0f) {
				attributes [Elements.ATTACK] -= 0.1f;
			}
		}

		public override void appraise (Emotion e)
		{
			// Get angry if attacked
			if (attributes.ContainsKey (Elements.ATTACK)) {
				e.valence = Math.Min (-1f, e.valence - attributes [Elements.ATTACK]);
				e.intensity = Math.Max (1f, e.intensity + attributes [Elements.ATTACK]);
			}

			// Decrease the intensity based on the certainty
			e.valence *= Certainty;
			e.intensity *= Certainty;
		}
	}
}
