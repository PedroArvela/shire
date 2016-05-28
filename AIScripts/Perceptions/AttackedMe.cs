using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class AttackedMe : Perception
	{
		public AttackedMe (GameObject target)
		{
			Name = "AttackedMe";
			this.target = target;
			targetTag = target.tag;
		}
	}
}

