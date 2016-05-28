using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;
using Scripts.AI.Emotions;

namespace Scripts.AI.Beliefs
{
	public class IExist : Belief
	{

		// Use this for initialization
		public IExist (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
            
		}

		public override void updateBelief (List<Perception> perceptions)
		{
			List<Perception> candidates = perceptions.FindAll (p => p.target.Equals (Subject));

			if (candidates.Count > 0) {
				Certainty = 1;

				attributes [Elements.HEALTH] = perceptions [0].attributes [Elements.HEALTH];
				attributes [Elements.RESOURCE] = perceptions [0].attributes [Elements.RESOURCE];
				attributes [Elements.MAXHEALTH] = perceptions [0].attributes [Elements.MAXHEALTH];
				attributes [Elements.MAXRESOURCE] = perceptions [0].attributes [Elements.MAXRESOURCE];

				Location = candidates [0].target.transform.position;
			}
            
		}

		public override void appraise (Emotion e)
		{
			// Make energetic or depressed based on the amount of HP
			e.valence = ((attributes [Elements.HEALTH] / attributes [Elements.MAXHEALTH]) * 2) - 1;
			e.intensity = ((attributes [Elements.HEALTH] / attributes [Elements.MAXHEALTH]) * 2) - 1;
		}
	}
}