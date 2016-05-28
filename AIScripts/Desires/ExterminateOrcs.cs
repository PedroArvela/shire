using UnityEngine;
using System.Collections;

namespace Scripts.AI.Desires
{
	public class ExterminateOrcs : Desire
	{
		public ExterminateOrcs (float intensity)
		{
			this.targetType = Elements.ORC;
			this.attribute = Elements.COUNT;
			this.goal = FuzzyLogicGoal.None;

			this.intensity = intensity;
		}
	}
}