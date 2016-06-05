﻿using UnityEngine;
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
            attributes.Add(Elements.HEALTH, 0);
            attributes.Add(Elements.RESOURCE, 0);
            attributes.Add(Elements.MAXHEALTH, 0);
            attributes.Add(Elements.MAXRESOURCE, 0);

        }

		public override void updateBelief (List<Perception> perceptions)
		{
			List<Perception> candidates = perceptions.FindAll (p => p.target.Equals (Subject));

			if (candidates.Count > 0) {
				Certainty = 1;

				attributes [Elements.HEALTH] = perceptions [0].attributes [Elements.HEALTH];
				attributes [Elements.RESOURCE] = perceptions [0].attributes [Elements.RESOURCE];
				attributes [Elements.MAXHEALTH] = perceptions [0].attributes [Elements.MAXHEALTH];
				attributes [Elements.MAXRESOURCE] = perceptions [0].attributes [Elements.MAXRESOURCE];

				Location = candidates [0].target.transform.position;
			}

            if((attributes[Elements.HEALTH] / attributes[Elements.MAXHEALTH]) >= 0.7 && !conditions.Exists(p => p == "Healthy"))
            {
                conditions.Add("Healthy");

            } else if((attributes[Elements.HEALTH] / attributes[Elements.MAXHEALTH]) < 0.7)
            {
                conditions.Clear();

            }

            Debug.Log("Resources " + attributes[Elements.RESOURCE]);
            Debug.Log("MaxResources " + attributes[Elements.MAXRESOURCE]);
            Debug.Log("Ratio " + (attributes[Elements.RESOURCE] / attributes[Elements.MAXRESOURCE]));
            if ((attributes[Elements.RESOURCE] / attributes[Elements.MAXRESOURCE]) >= 0.7 && !conditions.Exists(p => p == "HasResources"))
            {
                conditions.Add("HasResources");

            }
            else if ((attributes[Elements.RESOURCE] / attributes[Elements.MAXRESOURCE]) < 0.7)
            {
                conditions.Clear();

            }

        }

		public override void appraise (Emotion e)
		{
			// Make energetic or tired based on the amount of HP
			e.valence = 0f;
			e.intensity = ((attributes [Elements.HEALTH] / attributes [Elements.MAXHEALTH]) * 2f) - 1f;
		}
	}
}