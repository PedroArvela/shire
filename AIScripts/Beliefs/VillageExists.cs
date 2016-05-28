using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;

namespace Scripts.AI.Beliefs
{
	public class VillageExists : Belief
	{
		public VillageExists (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
		}

		public override void updateBelief (List<Perception> perceptions)
		{
			// nothing to do here
		}
	}
}

