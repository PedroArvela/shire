﻿using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;

namespace Scripts.AI.Beliefs
{
	public class ResourceExists : Belief
	{
		public ResourceExists (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
		}

		public override void updateBelief (List<Perception> perceptions)
		{
			// nothing to do here
		}
	}
}
