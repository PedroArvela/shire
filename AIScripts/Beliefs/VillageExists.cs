using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;
using Scripts.AI.Emotions;

namespace Scripts.AI.Beliefs
{
	public class VillageExists : Belief
	{
		public VillageExists (GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
            Name = "VillageExists";
            attributes = new SortedDictionary<string, float>();

		}

		public override void updateBelief (List<Perception> perceptions)
		{
            Perception candidate = perceptions.Find(p => p.target.Equals(Subject));

            if (candidate != null )
            {
                attributes[Elements.RESOURCE] =  candidate.attributes[Elements.RESOURCE];
            }
            

        }

		public override void appraise (Emotion e)
		{
		}
	}
}

