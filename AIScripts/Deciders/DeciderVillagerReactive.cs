using UnityEngine;
using System.Collections;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System;
using Scripts.Utils;
using System.Collections.Generic;

namespace Scripts.AI.Deciders
{
	public class DeciderVillagerReactive : Decider
	{
		public override Actions.AIAction Decide (List<Perception> perceptions)
		{
			// If there are Orcs, deal with them
			// Otherwise, deal with resources
			// If none of the above apply, wander around.

			if (perceptions.Exists (p => p.Name == "SeeOrc")) {
                List<Perception> orcs = perceptions.FindAll (p => p.Name == "SeeOrc");
				GameObject closestOrc = orcs [0].perceptionTarget;

				// Find the closest orc
				foreach(SeeOrc orc in orcs) {
					float oldDistance = Vector3.Distance (this.transform.position, closestOrc.transform.position);
					float newDistance = Vector3.Distance (this.transform.position, orc.perceptionTarget.transform.position);
					if (newDistance <= oldDistance) {
						closestOrc = orc.perceptionTarget;
					}
				}

				return new AttackTarget (closestOrc);
			} else if (perceptions.Exists (p => p.Name == "SeeResource") && this.GetComponent<CharacterVars>().currentResource <= this.GetComponent<CharacterVars>().maxResource) {
                List<Perception> resources = perceptions.FindAll(p => p.Name == "SeeResource");
                GameObject closestResource = resources[0].perceptionTarget;

                // Find the closest orc
                foreach (SeeResource resource in resources)
                {
                    float oldDistance = Vector3.Distance(this.transform.position, closestResource.transform.position);
                    float newDistance = Vector3.Distance(this.transform.position, resource.perceptionTarget.transform.position);
                    if (newDistance <= oldDistance)
                    {
                        closestResource = resource.perceptionTarget;
                    }
                }

                return new GatherResource(closestResource);
            } else {
				return new Wander ();
			}
		}
	}
}