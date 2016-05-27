using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public class InVillage : Perception
	{
		public InVillage ()
		{
			Name = "InVillage";
			target = GameObject.FindGameObjectWithTag ("Village");
		}
	}
}