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
				Debug.Log ("Decided Attack");
				List<Perception> orcs = perceptions.FindAll (p => p.Name == "SeeOrc");
				return new AttackTarget (ClosestPerception (orcs).perceptionTarget);
			} else if (perceptions.Exists (p => p.Name == "SeeResource") && CharVars ().currentResource <= CharVars ().maxResource) {
				Debug.Log ("Decided Gather");
				List<Perception> resources = perceptions.FindAll (p => p.Name == "SeeResource");
				return new GatherResource (ClosestPerception (resources).perceptionTarget);
			} else if (CharVars ().currentResource == CharVars ().maxResource) {
				Debug.Log ("Go To Village: " + GameObject.Find ("Green Village").transform.position);
				return new GoToTarget (GameObject.Find ("Green Village").transform.position);
			} else {
				Debug.Log ("Decided Wander");
				return new Wander ();
			}
		}
	}
}