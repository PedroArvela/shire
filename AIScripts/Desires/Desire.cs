using UnityEngine;
using System.Collections;

namespace Scripts.AI.Desires
{
	public enum Logic {
		Below,
		BelowEquals,
		Above,
		AboveEquals,
		Equals,
		Different
	}

	public class Desire
	{
		public GameObject target;
		public string attribute;
		public float limit;
		public Logic condition;
	}
}