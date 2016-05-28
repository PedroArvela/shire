using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class CanSee : Perception
	{
		public CanSee (GameObject target) : base()
		{
			Name = "CanSee";
			this.target = target;
			targetTag = target.tag;
		}
	}
}