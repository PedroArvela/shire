using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class IsNear : Perception
	{
		public IsNear (GameObject target)
		{
			Name = "IsNear";
			this.target = target;
			targetTag = target.tag;
		}
	}
}