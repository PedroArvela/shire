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
        }

		public override void updateBelief (List<Perception> perceptions)
		{
            List<Perception> candidates = perceptions.FindAll(p => p.target.Equals(Subject));

            if (candidates.Count > 0 && conditions.Count == 0)
            {
                conditions.Add("ResourceInSight");
            }
            else if (candidates.Count == 0)
            {
                conditions.Clear();
            }

            


            


        }

		public override void appraise (Emotion e)
		{
		}
	}
}

