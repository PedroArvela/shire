﻿using UnityEngine;
using System.Collections.Generic;
using Scripts.AI.Perceptions;

namespace Scripts.AI.Beliefs
{
	public class Befief
	{
		public GameObject Subject;
		public Vector3 Location;
		public SortedDictionary<string, Tuple<float, float>> attributes;
		public float Certainty;

		public abstract void updateBelief (List<Perception> p);

		public bool Certain ()
		{
			return Certainty >= 0.8;
		}

		public bool Uncertain ()
		{
			return Certainty <= 0.2;
		}

		private Befief (GameObject subject, Vector3 location, float certainty)
		{
			Subject = subject;
			Location = location;
			Certainty = certainty;
		}
	}
}