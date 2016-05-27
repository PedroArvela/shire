using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class SeeResource : Perception
	{
		public SeeResource (GameObject target)
		{
			Name = "SeeResource";
			this.target = target;
		}
	}
}