using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class SeeOrc : Perception
	{
		public SeeOrc (GameObject target)
		{
			Name = "SeeOrc";
			this.target = target;
		}
	}
}