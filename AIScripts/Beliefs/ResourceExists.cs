using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;
using Scripts.AI.Emotions;

namespace Scripts.AI.Beliefs
{
	public class ResourceExists : Belief
	{
		public ResourceExists (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
            conditions = new List<string>();
            Name = "ResourceExists";
            attributes = new SortedDictionary<string, float>();
        }

		public override void updateBelief (List<Perception> perceptions)
		{
            Perception candidate = perceptions.Find(p => p.target.Equals(Subject));

            if (candidate != null)
            {
                attributes[Elements.RESOURCE] = candidate.attributes[Elements.RESOURCE];
                attributes[Elements.MAX_RESOURCE] = candidate.attributes[Elements.MAX_RESOURCE];
                conditions.Add("ResourceInSight");
            }   else
            {
                conditions.Clear();
            }

            


            


        }

		public override void appraise (Emotion e)
		{
		}
	}
}

