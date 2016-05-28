using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class IsNear : Perception
	{
		public IsNear (GameObject target) : base()
		{
			Name = "IsNear";
			this.target = target;
			targetTag = target.tag;
		}
	}
}