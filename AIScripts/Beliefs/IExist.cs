using UnityEngine;
using System;
using System.Collections.Generic;
using Scripts.AI.Perceptions;

namespace Scripts.AI.Beliefs
{
    public class IExist : Belief
    {

        // Use this for initialization
        public IExist(GameObject subject) : base (subject, subject.transform.position, 1.0f)
		{
            
        }

        public override void updateBelief(List<Perception> perceptions)
        {
            List<Perception> candidates = perceptions.FindAll(p => p.target.Equals(Subject));

            if (candidates.Count > 0)
            {
                Certainty = 1;

                /** /
                if (attributes.ContainsKey(Elements.HEALTH))
                {
                    attributes[Elements.HEALTH] = perceptions[0].attributes[Elements.HEALTH];
                } else
                {
                    attributes.Add(Elements.HEALTH, perceptions[0].attributes[Elements.HEALTH]);

                }

                if (attributes.ContainsKey(Elements.RESOURCE))
                {
                    attributes[Elements.RESOURCE] = perceptions[0].attributes[Elements.RESOURCE];
                }
                else
                {
                    attributes.Add(Elements.RESOURCE, perceptions[0].attributes[Elements.RESOURCE]);

                }

                if (attributes.ContainsKey(Elements.MAXHEALTH))
                {
                    attributes[Elements.MAXHEALTH] = perceptions[0].attributes[Elements.MAXHEALTH];
                }
                else
                {
                    attributes.Add(Elements.MAXHEALTH, perceptions[0].attributes[Elements.MAXHEALTH]);

                }

                if (attributes.ContainsKey(Elements.MAXRESOURCE))
                {
                    attributes[Elements.MAXRESOURCE] = perceptions[0].attributes[Elements.MAXRESOURCE];
                }
                else
                {
                    attributes.Add(Elements.MAXRESOURCE, perceptions[0].attributes[Elements.MAXRESOURCE]);

                }

                /**/

                attributes[Elements.HEALTH] = perceptions[0].attributes[Elements.HEALTH];
                attributes[Elements.RESOURCE] = perceptions[0].attributes[Elements.RESOURCE];
                attributes[Elements.MAXHEALTH] = perceptions[0].attributes[Elements.MAXHEALTH];
                attributes[Elements.MAXRESOURCE] = perceptions[0].attributes[Elements.MAXRESOURCE];

                Location = candidates[0].target.transform.position;
            }
            
        }
    }
}