using UnityEngine;
using System.Collections;

namespace Scripts.AI.Desires
{
	public abstract class Desire
	{
		public string targetType;
		public string attribute;
		public FuzzyLogicGoal goal;

		public float intensity;
	}
}