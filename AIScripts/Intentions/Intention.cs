using UnityEngine;
using System.Collections;

namespace Scripts.AI.Intentions
{
	public class Intention
	{
		public GameObject target;
		public string attribute;
		public float limit;
		public Logic condition;
	}
}