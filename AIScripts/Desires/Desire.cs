using UnityEngine;
using System.Collections;
using Scripts.AI.Beliefs;
using System.Collections.Generic;
using Scripts.AI.Emotions;

namespace Scripts.AI.Desires
{
	public enum DesireType {
		BeHealthy,
		ExterminateOrcs,
		GatherResources
	}

	public abstract class Desire
	{
		protected GameObject self;

		public string targetType;
		public string attribute;
		public FuzzyLogicGoal goal;

		public float intensity;

		public abstract DesireType Type ();
		public abstract void updateDesire (List<Belief> beliefs, Emotion emotion);
	}
}