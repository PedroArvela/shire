using UnityEngine;
using System.Collections;
using Scripts.AI.Beliefs;
using System.Collections.Generic;

namespace Scripts.AI.Desires
{
	public abstract class Desire
	{
		protected GameObject self;

		public string targetType;
		public string attribute;
		public FuzzyLogicGoal goal;

		public float intensity;

		public abstract string Type ();
		public abstract void updateDesire (List<Belief> beliefs);
		public abstract static Desire generateDesire(GameObject self, List<Belief> beliefs);
	}
}