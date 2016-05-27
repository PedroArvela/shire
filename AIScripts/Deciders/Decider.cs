using UnityEngine;
using System.Collections.Generic;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using Scripts.Utils;
using System.Linq;


namespace Scripts.AI.Deciders
{
	public abstract class Decider : MonoBehaviour
	{
		public string Name;

		public abstract AIAction Decide (List<Perception> perceptions);

		protected CharacterVars CharVars ()
		{
			return this.GetComponent<CharacterVars> ();
		}

		protected Perception ClosestPerception (List<Perception> perceptions)
		{
			Perception closestPerception = null;

			foreach (Perception perception in perceptions) {
				if (closestPerception == null) {
					closestPerception = perception;
					continue;
				}

				float oldDistance = Vector3.Distance (this.transform.position, closestPerception.target.transform.position);
				float newDistance = Vector3.Distance (this.transform.position, perception.target.transform.position);

				if (newDistance <= oldDistance) {
					closestPerception = perception;
				}
			}

			return closestPerception;
		}
	}
}