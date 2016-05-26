using UnityEngine;
using System.Collections;
using Scripts.AI.Actions;
using Scripts.AI.Perceptions;
using System;

namespace Scripts.AI.Deciders
{
	public class DeciderVillagerReactive : Decider
	{
		public override Actions.Action Decide (Perception[] perceptions)
		{
			// If there are Orcs, deal with them
			// Otherwise, deal with resources
			// If none of the above apply, wander around.

			if (Array.Exists (perceptions, p => p.Name == "SeeOrcs")) {
				SeeOrc[] orcs = (SeeOrc[]) Array.FindAll (perceptions, p => p.Name == "SeeOrcs");
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
			} else if (Array.Exists (perceptions, p => p.Name == "SeeResources")) {
				//TODO: Deal with resources
			} else {
				return new Wander ();
			}
		}
	}
}