using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;
using Scripts.AI.Emotions;

namespace Scripts.AI.Beliefs
{
	public class ResourceExists : Belief
	{
		public ResourceExists (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
		}

		public override void updateBelief (List<Perception> perceptions)
		{
			// TODO: update based on certainty of wether there are resources or not
		}

		public override void appraise (Emotion e)
		{
		}
	}
}

