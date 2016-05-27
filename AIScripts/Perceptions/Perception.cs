using UnityEngine;
using System.Collections;

namespace Scripts.AI.Perceptions
{
	public abstract class Perception
	{
		public string Name;
		public GameObject target;
		public string targetTag;
	}
}