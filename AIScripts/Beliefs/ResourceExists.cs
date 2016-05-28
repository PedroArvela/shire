using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;

namespace Scripts.AI.Beliefs
{
	public class ResourceExists : Belief
	{
		public ResourceExists (GameObject subject, Vector3 location) : base (subject, location, 1.0f)
		{
		}

		public override void updateBelief (List<Perception> perceptions)
		{
			// nothing to do here
		}
	}
}

