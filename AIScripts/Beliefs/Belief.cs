using UnityEngine;
using System.Collections.Generic;
using Scripts.AI.Perceptions;
using Scripts.AI.Emotions;

namespace Scripts.AI.Beliefs
{
	public abstract class Belief
	{
		public GameObject Subject;
		public Vector3 Location;
		public SortedDictionary<string, float> attributes;
		public float Certainty;

		public abstract void updateBelief (List<Perception> p);
		public abstract void appraise (Emotion e);

		public bool Certain ()
		{
			return Certainty >= 0.8;
		}

		public bool Uncertain ()
		{
			return Certainty <= 0.2;
		}

		protected Belief (GameObject subject, Vector3 location, float certainty)
		{
			Subject = subject;
			Location = location;
			Certainty = certainty;
            attributes = new SortedDictionary<string, float>();
        }
	}
}