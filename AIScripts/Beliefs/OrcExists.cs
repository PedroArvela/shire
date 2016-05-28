using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;

namespace Scripts.AI.Beliefs
{
	public class OrcExists : Belief
	{
		public OrcExists (GameObject subject, Vector3 location) : base (subject, location, 1.0f)
		{
		}

		public override void updateBelief (List<Perception> perceptions)
		{
			List<Perception> candidates = perceptions.FindAll (p => p.target.Equals (Subject));

			if (candidates.Count > 0) {
				Certainty = 1;
				Location = candidates [0].target.transform.position;
			} else {
				Certainty -= 0.05;
			}
		}
	}
}
