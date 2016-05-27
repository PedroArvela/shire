using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class CanSee : Perception
	{
		public CanSee (GameObject target)
		{
			Name = "CanSee";
			this.target = target;
			targetTag = target.tag;
		}
	}
}