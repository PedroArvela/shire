using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;
using Scripts.AI.Emotions;

namespace Scripts.AI.Beliefs
{
	public class IExist : Belief
	{

		// Use this for initialization
		public IExist (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
            Name = "IExist";
            conditions = new List<string>();
            attributes = new SortedDictionary<string, float>();

        }

		public override void updateBelief (List<Perception> perceptions)
		{
			List<Perception> candidates = perceptions.FindAll (p => p.target.Equals (Subject));

			if (candidates.Count > 0) {
				Certainty = 1;

				attributes [Elements.HEALTH] = perceptions [0].attributes [Elements.HEALTH];
				attributes [Elements.RESOURCE] = perceptions [0].attributes [Elements.RESOURCE];
				attributes [Elements.MAX_HEALTH] = perceptions [0].attributes [Elements.MAX_HEALTH];
				attributes [Elements.MAX_RESOURCE] = perceptions [0].attributes [Elements.MAX_RESOURCE];

				Location = candidates [0].target.transform.position;
			}

            if((attributes[Elements.HEALTH] / attributes[Elements.MAX_HEALTH]) >= 0.7 && conditions.Count == 0)
            {
                conditions.Add("Healthy");

            } else if((attributes[Elements.HEALTH] / attributes[Elements.MAX_HEALTH]) < 0.7)
            {
                conditions.Clear();

            }

            if ((attributes[Elements.RESOURCE] / attributes[Elements.MAX_RESOURCE]) >= 0.7 && conditions.Count == 0)
            {
                conditions.Add("HasResources");

            }
            else if ((attributes[Elements.RESOURCE] / attributes[Elements.MAX_RESOURCE]) < 0.7)
            {
                conditions.Clear();

            }

        }

		public override void appraise (Emotion e)
		{
			// Make energetic or tired based on the amount of HP
			e.valence = 0f;
			e.intensity = ((attributes [Elements.HEALTH] / attributes [Elements.MAX_HEALTH]) * 2f) - 1f;
		}
	}
}